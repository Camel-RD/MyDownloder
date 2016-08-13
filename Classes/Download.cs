using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.ComponentModel;
using System.Xml.Serialization;
using MyLIB.Misc;

namespace MyDownloader
{
    [Serializable]
    public enum EDownloadStatus
    {
        None,
        Checking, 
        Preparing, Prepared,
        Ready,
        Running,
        Stopping, Stopped,
        Completing, Completed,
        Reseting,
        Removing,
        Error
    }

    public class Download : INotifyPropertyChanged
    {
        //public event System.EventHandler OnProgress;
        private EDownloadStatus _Status = EDownloadStatus.None;
        private string _Url = null;
        private string _FileName = null;
        private string _Folder = TopManager.st.Settings.DownloadTo;
        private string _FullFileName = null;
        private string _StatusText = null;
        private long _FileSize = 0;
        private string _FileSizeText = null;
        private long _BytesRead = 0;
        private long _Speed = 0; //in BPS
        private bool _Enabled = true;
        private string _ErrorText = null;
        private bool _StopRequested = false;
        private bool _DisableRequested = false;

        [XmlIgnore]
        public bool Removing = false;

        [XmlIgnore]
        public bool Reseting = false;

        public Download()
        {
        }

        public Download Copy()
        {
            var cp = new Download()
            {
                _Status = this._Status,
                _Url = this._Url,
                _FileName = this._FileName,
                _Folder = this._Folder,
                _FullFileName = this._FullFileName,
                _StatusText = this._StatusText,
                _FileSize = this._FileSize,
                _FileSizeText = this._FileSizeText,
                _BytesRead = this._BytesRead,
                _Speed = this._Speed,
                _Enabled = this._Enabled,
                _ErrorText = this._ErrorText
            };

            return cp;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && !(obj is Download)) return false;
            Download o = obj as Download;
            if (object.ReferenceEquals(this, o)) return true;
            if (o == null) return false;
            return
                _Status == o._Status &&
                _Url == o._Url &&
                _FileName == o._FileName &&
                _Folder == o._Folder &&
                _FullFileName == o._FullFileName &&
                _StatusText == o._StatusText &&
                _FileSize == o._FileSize &&
                _BytesRead == o._BytesRead &&
                _Enabled == o._Enabled &&
                _ErrorText == o._ErrorText;
        }

        public EDownloadStatus Status
        {
            get { return _Status; }
            set
            {
                if (value == _Status) return;
                var oldstatus = _Status;
                _Status = value;
                OnPropertyChanged("Status");
                UpdateStatusText();

                if (!TopManager.st.Deserializing && _Status != EDownloadStatus.None)
                    LogMsg("Status: " + StatusText);

                if (Status == EDownloadStatus.Completed ||
                    Status == EDownloadStatus.Stopped ||
                    Status == EDownloadStatus.Error ||
                    Status == EDownloadStatus.Ready)
                {
                    OnPropertyChanged("BytesReadText");
                    OnPropertyChanged("Progress");
                    Speed = 0;
                }
                TopManager.st.OnStatusChenged(this, oldstatus, _Status);
            }
        }

        public string Url
        {
            get { return _Url; }
            set
            {
                if (object.Equals(value, _Url)) return;
                _Url = value;
                OnPropertyChanged("Url");
            }
        }

        public string FileName
        {
            get { return _FileName; }
            set
            {
                if (object.Equals(value, _FileName)) return;
                _FileName = value;
                OnPropertyChanged("FileName");
                UpdateFullFileName();
            }
        }

        public string Folder
        {
            get { return _Folder; }
            set
            {
                if (string.IsNullOrEmpty(value)) value = TopManager.st.Settings.DownloadTo;
                if (object.Equals(value, _Folder)) return;
                _Folder = value;
                OnPropertyChanged("Folder");
                UpdateFullFileName();
            }
        }

        [XmlIgnore]
        public string FullFileName
        {
            get { return _FullFileName; }
            private set
            {
                if (object.Equals(value, _FullFileName)) return;
                _FullFileName = value;
                OnPropertyChanged("FullFileName");
            }
        }

        [XmlIgnore]
        public string StatusText
        {
            get { return _StatusText; }
            private set
            {
                if (object.Equals(value, _StatusText)) return;
                _StatusText = value;
                OnPropertyChanged("StatusText");
            }
        }

        public long FileSize
        {
            get { return _FileSize; }
            set
            {
                if (value == _FileSize) return;
                _FileSize = value;
                OnPropertyChanged("FileSize");
                FileSizeText = Utils.GetFileSizeString(_FileSize);
            }
        }

        [XmlIgnore]
        public string FileSizeText
        {
            get { return _FileSizeText; }
            private set
            {
                if (object.Equals(value, _FileSizeText)) return;
                _FileSizeText = value;
                OnPropertyChanged("FileSizeText");
            }
        }

        private DateTime lastBytesReadText = DateTime.Now;

        public long BytesRead
        {
            get { return _BytesRead; }
            set
            {
                if (value == _BytesRead) return;
                _BytesRead = value;
                if(Status == EDownloadStatus.Running)
                {
                    var ms = (DateTime.Now - lastBytesReadText).TotalMilliseconds;
                    if(ms > 1000)
                    {
                        lastBytesReadText = DateTime.Now;
                        OnPropertyChanged("BytesRead");
                        OnPropertyChanged("BytesReadText");
                        OnPropertyChanged("Progress");
                    }
                }
                else
                {
                    OnPropertyChanged("BytesRead");
                    OnPropertyChanged("BytesReadText");
                    OnPropertyChanged("Progress");
                }
            }
        }

        [XmlIgnore]
        public string BytesReadText
        {
            get { return Utils.GetFileSizeString(_BytesRead);}
        }

        [XmlIgnore]
        public int Progress //percents
        {
            get { return FileSize == 0 ? 0 : (int)(_BytesRead * 100 / FileSize); }
        }

        private DateTime lastSpeedText = DateTime.Now;


        [XmlIgnore]
        public long SpeedX
        {
            get
            {
                if (Status != EDownloadStatus.Running) return 0;
                long b = 0;
                double ms = 0d;
                for (int i = 0; i < 10; i++)
                {
                    b += bytesReadHistory[i];
                    ms += timeMsHistory[i];
                }
                if (ms < 100d) return 0;
                return (long)((double)b * 1000d / ms);
            }
        }

        [XmlIgnore]
        public TimeSpan TimeLeft
        {
            get
            {
                if (Status != EDownloadStatus.Running) return TimeSpan.Zero;
                long bytesleft = FileSize - BytesRead;
                long speed = SpeedX;
                if (speed < 100) return TimeSpan.Zero;
                return TimeSpan.FromSeconds((double)bytesleft / (double)speed);
            }
        }

        [XmlIgnore]
        public long Speed
        {
            get { return _Speed; }
            private set
            {
                if (value == _Speed) return;
                _Speed = value;
                if (Status == EDownloadStatus.Running)
                {
                    var ms = (DateTime.Now - lastSpeedText).TotalMilliseconds;
                    if (ms > 1000)
                    {
                        lastSpeedText = DateTime.Now;
                        OnPropertyChanged("Speed");
                        OnPropertyChanged("SpeedText");
                        OnPropertyChanged("TimeLeft");
                    }
                }
                else
                {
                    OnPropertyChanged("Speed");
                    OnPropertyChanged("SpeedText");
                    OnPropertyChanged("TimeLeft");
                }
            }
        }

        [XmlIgnore]
        public string SpeedText
        {
            get { return Utils.GetFileSizeString(_Speed) + "/s"; }
        }

        [XmlIgnore]
        public string ErrorText
        {
            get { return _ErrorText; }
            set
            {
                if (object.Equals(value, _ErrorText)) return;
                _ErrorText = value;
                OnPropertyChanged("ErrorText");
                UpdateStatusText();
            }
        }

        public bool Enabled
        {
            get { return _Enabled; }
            set
            {
                if (value == _Enabled) return;
                if(!_Enabled) _DisableRequested = false;
                _Enabled = value;
                OnPropertyChanged("Enabled");
                UpdateStatusText();
            }
        }

        private Stream ns = null;
        private Stream fs = null;
        private bool acceptRanges = false;
        private Thread thStart;
        private Thread thPrepare;
        private Stopwatch sw = new Stopwatch();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propname)
        {
            if (PropertyChanged == null) return;
            if (TopManager.st.MainForm != null &&
                !TopManager.st.MainForm.Disposing &&
                !TopManager.st.MainForm.IsDisposed &&
                TopManager.st.MainForm.InvokeRequired)
            {
                try
                {
                    TopManager.st.MainForm.Invoke((Action<string>)OnPropertyChangedA,
                        new[] { propname });
                }
                catch (Exception ) { }
            }
            else
                OnPropertyChangedA(propname);
        }

        public void OnPropertyChangedA(string propname)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }


        public void LogMsg(string msg)
        {
            var s = string.Format("{0}\n----Filename: [{1}]\n----Url: [{2}]"
                , msg.Nz(), FileName.Nz(), Url.Nz());
            TopManager.st.LogMsg(s);
        }

        public void LogError(string msg, string tag = "Error")
        {
            var s = string.Format("{0}: {1}\n----Filename: [{2}]\n----Url: [{3}]"
                , tag.Nz(), msg.Nz(), FileName.Nz(), Url.Nz());
            TopManager.st.LogMsg(s);
        }

        private void UpdateStatusText()
        {
            if (!Enabled)
            {
                StatusText = "disabled";
                return;
            }
            switch (Status)
            {
                case EDownloadStatus.None:
                    StatusText = "";
                    return;
                case EDownloadStatus.Checking:
                    StatusText = "checking";
                    return;
                case EDownloadStatus.Preparing:
                    StatusText = "preparing";
                    return;
                case EDownloadStatus.Prepared:
                    StatusText = "prepared";
                    return;
                case EDownloadStatus.Ready:
                    StatusText = "ready";
                    return;
                case EDownloadStatus.Running:
                    StatusText = "downloading";
                    return;
                case EDownloadStatus.Stopping:
                    StatusText = "stopping";
                    return;
                case EDownloadStatus.Stopped:
                    StatusText = "stopped";
                    return;
                case EDownloadStatus.Completing:
                    StatusText = "completing";
                    return;
                case EDownloadStatus.Completed:
                    StatusText = "completed";
                    return;
                case EDownloadStatus.Error:
                    if(string.IsNullOrEmpty(_ErrorText))
                        StatusText = "error";
                    else
                        StatusText = "error: " + _ErrorText;
                    return;
            }
        }

        public void UpdateFullFileName()
        {
            if (string.IsNullOrEmpty(FileName))
            {
                FullFileName = null;
                return;
            }

            var folder = _Folder;
            if (string.IsNullOrEmpty(folder)) folder = TopManager.st.Settings.DownloadTo;
            if (string.IsNullOrEmpty(folder))
            {
                FullFileName = null;
                return;
            }

            FullFileName = folder + "\\" + FileName;
        }

        public bool IsRunning()
        {
            return (thStart != null && 
                thStart.ThreadState == System.Threading.ThreadState.Running);
        }

        public bool CanGetFileInfo()
        {
            return Status == EDownloadStatus.Ready ||
                Status == EDownloadStatus.Error ||
                Status == EDownloadStatus.None ;
        }

        public bool CanStartDownload()
        {
            if (!Enabled || _StopRequested || 
                _DisableRequested || Removing) return false;

            return  Status == EDownloadStatus.Ready ||
                Status == EDownloadStatus.Stopped;
        }

        public bool CanDisable()
        {
            if (!Enabled || _DisableRequested || Removing) return false;
            return Status == EDownloadStatus.None ||
                Status == EDownloadStatus.Error ||
                Status == EDownloadStatus.Ready ||
                Status == EDownloadStatus.Completed ||
                Status == EDownloadStatus.Stopped;
        }

        public bool CanReset()
        {
            return Status == EDownloadStatus.Ready ||
                Status == EDownloadStatus.Stopped ||
                Status == EDownloadStatus.None ||
                Status == EDownloadStatus.Error;
        }

        public bool CanRemove()
        {
            return Status == EDownloadStatus.Ready ||
                Status == EDownloadStatus.Stopped ||
                Status == EDownloadStatus.None ||
                Status == EDownloadStatus.Error ||
                Status == EDownloadStatus.Completed;
        }

        public bool IsStill()
        {
            return Status == EDownloadStatus.None ||
                Status == EDownloadStatus.Error ||
                Status == EDownloadStatus.Ready ||
                Status == EDownloadStatus.Completed ||
                Status == EDownloadStatus.Stopped ||
                Status == EDownloadStatus.Removing;
        }

        public void Enable()
        {
            lock (this)
            {
                if (_Enabled) return;
                Enabled = true;
                return;
            }
        }

        public void Disable()
        {
            lock (this)
            {
                if (!_Enabled) return;
                if (CanDisable())
                {
                    Enabled = false;
                    return;
                }
                _DisableRequested = true;
            }
            Stop();
        }

        public void Reset()
        {
            lock (this)
            {
                if (CanReset())
                {
                    ResetA();
                    return;
                }
                Reseting = true;
            }
            Stop();
        }

        public void ResetA()
        {
            Status = EDownloadStatus.Reseting;
            BytesRead = 0;
            Reseting = false;
            if (!string.IsNullOrEmpty(FullFileName) &&
                File.Exists(FullFileName))
            {
                try
                {
                    File.Delete(FullFileName);
                }
                catch (Exception e)
                {
                    ErrorText = "Cant delete file.";
                    LogError(e.Message, ErrorText);
                    Status = EDownloadStatus.Error;
                    return;
                }
            }
            Enabled = false;
            Status = EDownloadStatus.Ready;
        }

        public void Recover()
        {
            lock (this)
            {
                if (Status != EDownloadStatus.Error) return;
                RecoverA();
            }
        }

        public void RecoverA()
        {
            if (string.IsNullOrEmpty(FullFileName)) return;
            if (!File.Exists(FullFileName)) return;
            var fi = new FileInfo(FullFileName);
            if (fi.Length > FileSize) return;
            BytesRead = fi.Length;
            ErrorText = "";
            Status = EDownloadStatus.Stopped;
        }

        public void Remove()
        {
            lock (this)
            {
                if (CanRemove())
                {
                    RemoveA();
                    return;
                }

                Removing = true;
            }
            Stop();
        }

        public void RemoveA()
        {
            Status = EDownloadStatus.Removing;
            Removing = false;
            TopManager.st.MainForm.Invoke((Action)(()=>
            {
                TopManager.st.Queue.Remove(this);
            }));
            return;
        }

        public void GetFileInfo()
        {
            lock (this)
            {
                GetFileInfoA();
            }
        }

        public void GetFileInfoA()
        {
            if (!CanGetFileInfo()) return;

            LogMsg("Requesting file info.");
            Status = EDownloadStatus.Checking;
            try
            {
                Uri uri = new Uri(Url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Timeout = 3000;
                WebResponse response = request.GetResponse();
                FileSize = response.ContentLength;
                FileName = null;
                bool acceptRanges = String.Compare(response.Headers["Accept-Ranges"], "bytes", true) == 0;
                string cd = response.Headers.Get("Content-Disposition");
                if (cd != null)
                {
                    int k1 = cd.IndexOf('"') + 1;
                    if (k1 > 0)
                    {
                        int k2 = cd.IndexOf('"', k1) - 1;
                        if (k2 > k1)
                            FileName = cd.Substring(k1, k2 - k1 + 1);
                    }
                }
                if (string.IsNullOrEmpty(FileName))
                {
                    FileName = Path.GetFileName(uri.LocalPath);
                }

                string ct = response.Headers.Get("Content-Type");
                if (ct != null && ct.IndexOf("text/html") > -1)
                {
                    ErrorText = "No file found in Url.";
                    LogError(ErrorText);
                    Status = EDownloadStatus.Error;
                    return;
                }

                acceptRanges = String.Compare(response.Headers["Accept-Ranges"], "bytes", true) == 0;
            }
            catch (Exception e)
            {
                ErrorText = "Url check failed.";
                LogError(e.Message, ErrorText);
                Status = EDownloadStatus.Error;
                return;
            }

            LogMsg("Got file info for.");
            Status = EDownloadStatus.Ready;
        }

        private void CreateStreams(bool resuming)
        {
            if (!resuming)
            {
                fs = new FileStream(this.FullFileName, FileMode.Create, FileAccess.Write);
                //fs.SetLength(FileSize);
            }
            else
            {
                fs = new FileStream(this.FullFileName, FileMode.Append, FileAccess.Write);
                fs.Position = BytesRead;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            if (BytesRead > 0) request.AddRange(BytesRead);
            request.Timeout = 3000;

            WebResponse response = request.GetResponse();
            //result.MimeType = res.ContentType;
            //result.LastModified = response.LastModified;
            if (!resuming)//(FileSize == 0)
            {
                FileSize = response.ContentLength;
            }
            acceptRanges = String.Compare(response.Headers["Accept-Ranges"], "bytes", true) == 0;

            ns = response.GetResponseStream();
        }


        public void Start()
        {
            lock (this)
            {
                if (!CanStartDownload()) return;
                thStart = new Thread(StartThread);
                try
                {
                    thStart.Start();
                    LogMsg("Download started");
                }
                catch (ThreadInterruptedException e)
                {
                    NullStreams();
                    sw.Stop();
                    LogMsg("ThreadInterrupted.");
                    Status = EDownloadStatus.Stopped;
                }
                catch(Exception e)
                {
                    NullStreams();
                    sw.Stop();
                    LogError(e.Message);
                    Status = EDownloadStatus.Error;
                }
            }
        }

        private void Prepare(bool resuming)
        {
            try
            {
                Status = EDownloadStatus.Preparing;

                FileInfo fi = new FileInfo(FullFileName);

                if (resuming)
                {
                    if (!File.Exists(FullFileName))
                    {
                        ErrorText = "Cant resume download, file dosnt exist";
                        LogError(ErrorText);
                        Status = EDownloadStatus.Error;
                        return;
                    }
                    if (fi.Length != BytesRead || BytesRead > FileSize)
                    {
                        ErrorText = "Cant resume download, bad file size";
                        LogError(ErrorText);
                        Status = EDownloadStatus.Error;
                        return;
                    }
                }
                else
                {
                    if (!Directory.Exists(fi.DirectoryName))
                        Directory.CreateDirectory(fi.DirectoryName);

                    string fext = Path.GetExtension(FullFileName);
                    if (File.Exists(FullFileName))
                    {
                        int c = 0;
                        string fname_woe = Path.GetFileNameWithoutExtension(FullFileName);
                        string ffname = "";
                        do
                        {
                            ffname = fi.Directory.FullName + Path.DirectorySeparatorChar + fname_woe + string.Format("({0})", c++) + fext;
                        } while (File.Exists(ffname));

                        FullFileName = ffname;
                    }

                    this.FileName = Path.GetFileNameWithoutExtension(FullFileName) + fext;
                }

                CreateStreams(resuming);

                if (BytesRead > FileSize)
                {
                    NullStreams();
                    ErrorText = "Cant resume download, bad file size";
                    LogError(ErrorText);
                    Status = EDownloadStatus.Error;
                    return;
                }

                Status = EDownloadStatus.Prepared;
            }
            catch (Exception e)
            {
                NullStreams();
                LogError(e.Message);
                Status = EDownloadStatus.Error;
            }
        }

        private void NullStreams()
        {
            try
            {
                if (fs != null)
                {
                    fs.Flush();
                    fs.Close();
                    fs = null;
                }
                if (ns != null)
                {
                    ns.Close();
                    ns = null;
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
        }

        private static int SpeedTestInterval = 1000;
        private long LastSpeedCheckTime = int.MinValue;
        private long BytesForSpeedCheck = 0;

        private long[] bytesReadHistory = new long[10];
        private double[] timeMsHistory = new double[10];
        private int historyPos = 0;

        private void CheckSpeed(long bytesread)
        {
            if (!sw.IsRunning) return;
            BytesForSpeedCheck += bytesread;
            long t = sw.ElapsedMilliseconds - LastSpeedCheckTime;

            if (t < SpeedTestInterval) return;

            Speed = (long)((double)BytesForSpeedCheck * 1000d / ((double)t));

            bytesReadHistory[historyPos] = BytesForSpeedCheck;
            timeMsHistory[historyPos] = (double)t;
            historyPos++;
            if (historyPos == 10) historyPos = 0;

            LastSpeedCheckTime = sw.ElapsedMilliseconds;
            BytesForSpeedCheck = 0;
        }

        private void ResetSpeedData()
        {
            for(int i = 0; i < 10; i++)
            {
                bytesReadHistory[i] = 0;
                timeMsHistory[i] = 0d;
            }
            historyPos = 0;
        }

        private void StartThread()
        {
            lock (this)
            {
                _StopRequested = false;

                Prepare(BytesRead > 0);

                if (Status == EDownloadStatus.Error)
                {
                    NullStreams();
                    return;
                }
                if (_StopRequested)
                {
                    NullStreams();
                    _StopRequested = false;
                    Status = EDownloadStatus.Stopped;
                    return;
                }

                Status = EDownloadStatus.Running;
            }

            BytesForSpeedCheck = 0;
            LastSpeedCheckTime = 0;
            sw.Start();
            bool done = false;
            byte[] buffer = new byte[4096];
            long bytesToRead = FileSize;

            try
            {
                while (true) 
                {
                    if (_StopRequested) break;

                    int n = ns.Read(buffer, 0, buffer.Length);

                    if (_StopRequested) break;

                    if (n == 0)
                    {
                        done = true;
                        break;
                    }
                    fs.Write(buffer, 0, n);
                    fs.Flush();

                    BytesRead += n;
                    bytesToRead -= n;

                    CheckSpeed(n);
                }

            }
            catch (Exception e)
            {
                sw.Stop();
                NullStreams();
                ErrorText = "Download error";
                LogError(e.Message);
                Status = EDownloadStatus.Error;
                return;
            }

            ResetSpeedData();

            lock (this)
            {
                sw.Stop();
                NullStreams();
                if (done)
                {
                    Status = EDownloadStatus.Completed;
                }
                else if (_StopRequested)
                {
                    if (_DisableRequested || Removing || Reseting) Enabled = false;
                    //File.Delete(FullFileName);
                    _StopRequested = false;
                    Status = EDownloadStatus.Stopped;
                }
            }
        }

        public void Stop(bool disable = false)
        {
            lock (this)
            {
                if (Status != EDownloadStatus.Running) return;
                Status = EDownloadStatus.Stopping;

                if (thStart == null 
                    /*|| thStart.ThreadState != System.Threading.ThreadState.Running*/)
                {
                    LogMsg("Thread not running.");
                    Status = EDownloadStatus.Stopped;
                    return;
                }

                _StopRequested = true;
            }

            try
            {
                if (thStart.Join(5 * 1000))
                {
                    LogMsg("Thread ended well.");
                }
                else
                {
                    thStart.Abort();

                    LogMsg("Thread Aborted.");
                    if (_DisableRequested || Removing || Reseting) Enabled = false;
                    _StopRequested = false;
                    Status = EDownloadStatus.Stopped;
                }
            }
            catch(Exception e)
            {
                NullStreams();
                sw.Stop();
                LogMsg("Thread abort with error.");
                if (_DisableRequested || Removing || Reseting) Enabled = false;
                _StopRequested = false;
                Status = EDownloadStatus.Stopped;
            }
        }

    }

    public class StatusChengeEventArgs : EventArgs
    {
        public EDownloadStatus OldStatus, NewStatus;
        public StatusChengeEventArgs(EDownloadStatus oldstatus, EDownloadStatus newstatus)
        {
            OldStatus = oldstatus;
            NewStatus = newstatus;
        }
    }

    public delegate void StatusChengeEventHandler(object sender, StatusChengeEventArgs e);

}

