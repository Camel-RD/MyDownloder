using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MyLIB.Misc;

namespace MyDownloader
{
    public enum EDownloaderState
    {
        None,
        Running,
        Stopping, Stopped,
        Completed
    }

    public class TopManager
    {
        public static TopManager st = null;
        public MySettings Settings = new MySettings();
        public MyLog Log = new MyLog();
        public Form1 MainForm = null;

        public EDownloaderState DownloaderState = EDownloaderState.None;

        public static string MyFolder = Utils.GetMyFolderX();
        public static string SettingsFileName = MyFolder + "\\Config.xml";
        public static string DataFileName = MyFolder + "\\Data.xml";
        public static string LogFileName = MyFolder + "\\Log.txt";

        public int MaxParalelDownloads = 1;

        private MyData MyData = null;

        public BindingList<Download> PreQueue = new BindingList<Download>();
        public BindingList<Download> Queue = new BindingList<Download>();
        public List<Download> RunningDownloads = new List<Download>();

        public bool Deserializing { get; private set; } = false;

        static TopManager()
        {
            st = new TopManager();
            System.Net.WebRequest.DefaultWebProxy = null;
            System.Net.ServicePointManager.DefaultConnectionLimit = 100;
            System.Net.ServicePointManager.Expect100Continue = false;
        }

        private TopManager()
        {
            if (st != null) throw new Exception("Bad call.");
            st = this;
        }

        public void LogMsg(string msg)
        {
            if (MainForm != null && MainForm.InvokeRequired)
                MainForm.Invoke((Action<string>)LogMsgA, new[] { msg });
            else
                LogMsgA(msg);
        }

        void LogMsgA(string msg)
        {
            Log.Add(msg);
        }

        public void OnStatusChenged(Download d, EDownloadStatus oldstatus, EDownloadStatus newstatus)
        {
            if (Deserializing) return;

            if (MainForm != null &&
                !MainForm.Disposing &&
                !MainForm.IsDisposed &&
                MainForm.InvokeRequired)
            {
                try
                {
                    MainForm.Invoke((Action<Download, EDownloadStatus, EDownloadStatus>)OnStatusChengedA,
                        new object[] { d, oldstatus, newstatus });
                }
                catch (Exception) { }
            }
            else
                OnStatusChengedA(d, oldstatus, newstatus);
        }

        public void OnStatusChengedA(Download d, EDownloadStatus oldstatus, EDownloadStatus newstatus)
        {
            if (Deserializing) return;

            if (newstatus == EDownloadStatus.Running)
            {
                if (RunningDownloads.Contains(d)) return;
                RunningDownloads.Add(d);
                if (d.Reconnecting) d.Reconnecting = false;
                DownloaderState = EDownloaderState.Running;
            }
            else if (newstatus == EDownloadStatus.Completed)
            {
                if (!RunningDownloads.Contains(d)) return;
                RunningDownloads.Remove(d);
                if (IsCompleted())
                    OnAllCompleted();
                else if (RunningDownloads.Count < MaxParalelDownloads)
                    StartNext();
            }
            else if (newstatus == EDownloadStatus.Stopped)
            {
                if (!RunningDownloads.Contains(d)) return;
                RunningDownloads.Remove(d);

                if (d.Reseting)
                    d.ResetA();

                if (d.Removing)
                    d.RemoveA();

                if (DownloaderState == EDownloaderState.Stopping)
                {
                    if(RunningDownloads.Count == 0)
                        DownloaderState = EDownloaderState.Stopped;
                }
                else if (DownloaderState == EDownloaderState.Running)
                {
                    if (IsCompleted())
                        OnAllCompleted();
                    else if (d.Reconnecting)
                    {
                        StartNext();
                    }
                    else if (RunningDownloads.Count < MaxParalelDownloads)
                        StartNext();
                }
            }
            else if (newstatus == EDownloadStatus.Error)
            {
                if (!RunningDownloads.Contains(d)) return;
                RunningDownloads.Remove(d);
                if (DownloaderState == EDownloaderState.Stopping)
                {
                    if (RunningDownloads.Count == 0)
                        DownloaderState = EDownloaderState.Stopped;
                }
                else if (DownloaderState == EDownloaderState.Running)
                {
                    if (Settings.ReconnectAfterError == 1)
                    {
                        if (d.Reconnecting)
                        {
                            d.Reconnecting = false;
                        }
                        else if (oldstatus == EDownloadStatus.Running)
                        {
                            d.Reconnecting = true;
                            RunningDownloads.Add(d);
                            d.Recover();
                            return;
                        }
                    }

                    if (IsCompleted())
                    {
                        OnAllCompleted();
                    }
                    else if (RunningDownloads.Count < MaxParalelDownloads)
                    {
                        StartNext();
                    }
                }
            }
        }

        public void Start()
        {
            if (DownloaderState == EDownloaderState.Running) return;
            foreach (var d in Queue)
            {
                if (RunningDownloads.Contains(d)) continue;
                if (!d.CanStartDownload()) continue;
                Task.Run(()=> d.Start());
                break;
            }
        }

        public void StartNext()
        {
            if (DownloaderState != EDownloaderState.Running) return;
            foreach (var d in Queue)
            {
                if (RunningDownloads.Contains(d)) continue;
                if (!d.CanStartDownload()) continue;
                Task.Run(() => d.Start());
                break;
            }
        }

        public void RestartCurrent()
        {
            if (DownloaderState != EDownloaderState.Running) return;
            foreach (var d in Queue)
            {
                if (RunningDownloads.Contains(d)) continue;
                if (!d.CanStartDownload()) continue;
                Task.Run(() => d.Start());
                break;
            }
        }

        public async Task Stop()
        {
            if (DownloaderState != EDownloaderState.Running) return;
            DownloaderState = EDownloaderState.Stopping;
            await Task.Run(() =>
            {
                var dl = RunningDownloads.ToArray();
                foreach (var d in dl)
                {
                    d.Stop();
                }
            });
        }

        public void OnAllCompleted()
        {
            DownloaderState = EDownloaderState.Completed;
            if(Settings.ShutDown)
                ShutDown();
        }

        public void ShutDown()
        {
            var fm = new FormShutdown();
            fm.Show(MainForm);
            //System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
            /*
            var psi = new System.Diagnostics.ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            System.Diagnostics.Process.Start(psi);
            */
        }

        public bool IsCompleted()
        {
            if (RunningDownloads.Count > 0) return false;
            foreach (var d in Queue)
            {
                if (RunningDownloads.Contains(d)) continue;
                if (d.CanStartDownload()) return false; 
            }
            return true;
        }

        public void AddLinksToPreQueue(List<string> links)
        {
            if (links == null || links.Count == 0) return;
            List<Download> dl = new List<Download>();
            foreach(var s in links)
            {
                if (PreQueue.Where(pd => pd.Url == s).FirstOrDefault() != null) continue;

                var d = new Download()
                {
                    Url = s,
                    Folder = Settings.DownloadTo
                };
                dl.Add(d);
                PreQueue.Add(d);
            }
            CheckStatus(dl);
        }

        public void CheckStatus(List<Download> downloads)
        {
            if (downloads == null || downloads.Count == 0) return;
            Task.Run(()=>
            {
                foreach (var d in downloads)
                {
                    try
                    {
                        d.GetFileInfo();
                    }
                    catch(Exception e)
                    {
                        LogMsg(e.Message);
                    }
                }
            });
        }

        public bool IsLinkInQueue(string url)
        {
            return Queue.Where(d => object.Equals(d.Url, url)).FirstOrDefault() != null;
        }

        public void AddFromPreQueue(List<Download> dl)
        {
            var rd = dl.Where(d => !IsLinkInQueue(d.Url)).ToArray();
            foreach (var d in rd)
            {
                Queue.Add(d);
                PreQueue.Remove(d);
            }
            SaveData();
        }

        public void RemoveFromQueue(List<Download> dl)
        {
            Task.Run(() =>
            {
                foreach (var d in dl)
                    d.Remove();
            });
        }

        public void ReSetInQueue(List<Download> dl)
        {
            Task.Run(() =>
            {
                foreach (var d in dl)
                    d.Reset();
            });
        }

        public void RecoverInQueue(List<Download> dl)
        {
            Task.Run(() =>
            {
                foreach (var d in dl)
                    d.Recover();
            });
        }

        public void DisableInQueue(List<Download> dl)
        {
            Task.Run(() =>
            {
                foreach (var d in dl)
                    d.Disable();
            });
        }

        public void EnableInQueue(List<Download> dl)
        {
            Task.Run(() =>
            {
                foreach (var d in dl)
                    d.Enable();
            });
        }

        public void GetSumms(out long totalbytes, out long leftbytes, out long speed)
        {
            totalbytes = 0;
            leftbytes = 0;
            speed = 0;
            foreach (var d in Queue)
            {
                if (!d.Enabled || d.Status == EDownloadStatus.Error ||
                    d.Status == EDownloadStatus.Completed ||
                    d.Status == EDownloadStatus.None) continue;

                totalbytes += d.FileSize;
                leftbytes += d.FileSize - d.BytesRead;
                speed += d.SpeedX;
            }
        }

        private void CheckAfterLoad()
        {
            foreach(var d in Queue)
            {
                if(d.Status == EDownloadStatus.Running ||
                    d.Status == EDownloadStatus.Prepared ||
                    d.Status == EDownloadStatus.Preparing ||
                    d.Status == EDownloadStatus.Stopping ||
                    d.Status == EDownloadStatus.Completing)
                {
                    d.Status = EDownloadStatus.Stopped;
                }
            }
        }

        public void LoadSettings()
        {
            Settings = new MySettings();
            if (!File.Exists(SettingsFileName)) return;
            XmlSerializer xs = null;
            FileStream fs = null;
            try
            {
                xs = new XmlSerializer(typeof(MySettings));
                fs = new FileStream(SettingsFileName, FileMode.Open);
                Settings = (MySettings)xs.Deserialize(fs);
                if (string.IsNullOrEmpty(Settings.DownloadTo))
                    Settings.DownloadTo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            catch (Exception e)
            {
                LogMsg(e.Message);
                Settings = new MySettings();
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        public void SaveSetings()
        {
            if (!Settings.HasChanged) return;

            XmlSerializer xs = new XmlSerializer(typeof(MySettings));
            TextWriter wr = null;
            try
            {
                wr = new StreamWriter(SettingsFileName);
                xs.Serialize(wr, Settings);
                Settings.HasChanged = false;
            }
            catch (Exception e)
            {
                LogMsg(e.Message);
            }
            finally
            {
                if (wr != null) wr.Close();
            }
        }



        public void LoadData()
        {
            MyData = new MyData();
            if (!File.Exists(DataFileName)) return;
            XmlSerializer xs = null;
            FileStream fs = null;
            try
            {
                xs = new XmlSerializer(typeof(MyData));
                fs = new FileStream(DataFileName, FileMode.Open);
                Deserializing = true;
                MyData = (MyData)xs.Deserialize(fs);
                MyData.CopyToTM();
                CheckAfterLoad();
            }
            catch (Exception e)
            {
                LogMsg(e.Message);
                MyData = new MyData();
            }
            finally
            {
                if (fs != null) fs.Close();
                Deserializing = false;
            }
        }

        public void SaveData()
        {
            var newdata = new MyData();
            newdata.CopyFromTM();
            if (MyData.Equals(newdata)) return;
            MyData = newdata;

            var xs = Utils.CreateDefaultXmlSerializer(typeof(MyData));
            //XmlSerializer xs = new XmlSerializer(typeof(MyData));
            TextWriter wr = null;
            try
            {
                wr = new StreamWriter(DataFileName);
                xs.Serialize(wr, MyData);
            }
            catch (Exception e)
            {
                LogMsg(e.Message);
            }
            finally
            {
                if (wr != null) wr.Close();
            }
        }

        public void SaveLog()
        {
            var s = Log.GetAsString();
            if (string.IsNullOrEmpty(s)) return;
            if (File.Exists(LogFileName))
                File.Delete(LogFileName);
            File.WriteAllText(LogFileName, s);
        }

    }

}
