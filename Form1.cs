using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Threading;
using MyLIB.Misc;

namespace MyDownloader
{
    public partial class Form1 : Form
    {
        public TopManager TopManager = TopManager.st;

        public Form1()
        {
            InitializeComponent();
            TopManager.MainForm = this;
            TopManager.LoadSettings();
            this.Font = new Font(this.Font.FontFamily, TopManager.Settings.FontSize);
        }

        public List<string> FoundLinks = new List<string>();

        private bool EnableTextChangeMonitor = true;
        private bool TextNotParsed = false;


        private void Form1_Load(object sender, EventArgs e)
        {
            dgvQueue.ContextMenuStrip = menuDgvQueue;

            TopManager.LoadData();

            dgvLog.AutoGenerateColumns = false;
            dgvPreQueue.AutoGenerateColumns = false;

            bsLog.DataSource = TopManager.Log;
            bsQueue.DataSource = TopManager.Queue;
            bsPreQueue.DataSource = TopManager.PreQueue;

            UpdateStatusBar();
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            await TopManager.Stop();
            TopManager.SaveSetings();
            TopManager.SaveData();
        }

        private void btDownloadTo_Click(object sender, EventArgs e)
        {
            var fb = new FolderBrowserDialog();
            if (fb.ShowDialog(this) != DialogResult.OK) return;
            tbDownloadTo.Text = fb.SelectedPath;
        }

        public void RefreshSettingsView()
        {
            tbDownloadTo.Text = TopManager.Settings.DownloadTo;
            chShutdown.Checked = TopManager.Settings.ShutDown;
            int fs = TopManager.Settings.FontSize;
            if (fs < 8) fs = 8;
            if (fs > 16) fs = 16;
            cbFontSize.SelectedIndex = fs - 8;
        }

        public void UpdateSettings()
        {
            TopManager.Settings.DownloadTo = tbDownloadTo.Text;
            TopManager.Settings.ShutDown = chShutdown.Checked;
            int fs = int.Parse(cbFontSize.SelectedValue as string);
            TopManager.Settings.FontSize = fs;

        }

        private void tpSettings_Enter(object sender, EventArgs e)
        {
            RefreshSettingsView();
        }

        private void tpSettings_Leave(object sender, EventArgs e)
        {
            UpdateSettings();
        }


        public void PresentLinks()
        {
            EnableTextChangeMonitor = false;
            tbText.Text = "";
            foreach (var s in FoundLinks)
                tbText.AppendText(s + "\r\n");
            EnableTextChangeMonitor = true;
            TextNotParsed = false;
        }

        private Regex LinkScrubber = null;

        public bool ScrubLinks(string text)
        {
            if(LinkScrubber == null)
                LinkScrubber = new Regex(@"(?i)\b((?:https?:(?:/{1,3}|[a-z0-9%])|[a-z0-9.\-]+[.](?:com|net|org|edu|gov|mil|aero|asia|biz|cat|coop|info|int|jobs|mobi|museum|name|post|pro|tel|travel|xxx|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|ax|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cs|cu|cv|cx|cy|cz|dd|de|dj|dk|dm|do|dz|ec|ee|eg|eh|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|me|mg|mh|mk|ml|mm|mn|mo|mp|mq|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|om|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ro|rs|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|Ja|sk|sl|sm|sn|so|sr|ss|st|su|sv|sx|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw)/)(?:[^\s()<>{}\[\]]+|\([^\s()]*?\([^\s()]+\)[^\s()]*?\)|\([^\s]+?\))+(?:\([^\s()]*?\([^\s()]+\)[^\s()]*?\)|\([^\s]+?\)|[^\s`!()\[\]{};:'"".,<>?«»“”‘’])|(?:(?<!@)[a-z0-9]+(?:[.\-][a-z0-9]+)*[.](?:com|net|org|edu|gov|mil|aero|asia|biz|cat|coop|info|int|jobs|mobi|museum|name|post|pro|tel|travel|xxx|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|ax|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cs|cu|cv|cx|cy|cz|dd|de|dj|dk|dm|do|dz|ec|ee|eg|eh|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|me|mg|mh|mk|ml|mm|mn|mo|mp|mq|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|om|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ro|rs|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|Ja|sk|sl|sm|sn|so|sr|ss|st|su|sv|sx|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw)\b/?(?!@)))", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            FoundLinks.Clear();
            foreach (Match m in LinkScrubber.Matches(text))
            {
                if (m.Value.EndsWith("/")) continue;
                if (FoundLinks.Contains(m.Value)) continue;
                FoundLinks.Add(m.Value);
            }
            return FoundLinks.Count > 0;
        }

        public bool ScrubLinksA(string text)
        {
            ScrubLinks(text);
            if (FoundLinks.Count == 0)
            {
                MessageBox.Show("Links not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            PresentLinks();
            return true;
        }

        private void tsbGetClipboard_Click(object sender, EventArgs e)
        {
            string text = null;
            if (Clipboard.ContainsData(DataFormats.Html))
            {
                text = (string)Clipboard.GetData(DataFormats.Html);
            }
            else if (Clipboard.ContainsData(DataFormats.Text))
            {
                text = (string)Clipboard.GetData(DataFormats.Text);
            }
            if (text == null)
            {
                MessageBox.Show("Nothing found.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ScrubLinksA(text);
        }

        private void tsbParse_Click(object sender, EventArgs e)
        {
            ScrubLinksA(tbText.Text);
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            tbText.Text = "";
            FoundLinks.Clear();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (TextNotParsed)
                ScrubLinksA(tbText.Text);

            if (FoundLinks.Count == 0) return;

            TopManager.AddLinksToPreQueue(FoundLinks.ToList());
            FoundLinks.Clear();
            tbText.Text = "";
            tabControl.SelectedTab = tpPreQueue;
            TopManager.SaveData();
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            if (!EnableTextChangeMonitor) return;
            TextNotParsed = true;
            FoundLinks.Clear();
        }

        private void tsbClearPreQueue_Click(object sender, EventArgs e)
        {
            TopManager.PreQueue.Clear();
        }

        private List<Download> GetSelectedInPreQueue()
        {
            var dl = new List<Download>();
            if (dgvPreQueue.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dgvPreQueue.Rows.Count; i++)
                    if(dgvPreQueue.Rows[i].Selected)
                        dl.Add((Download)dgvPreQueue.Rows[i].DataBoundItem);
            }
            else if (dgvPreQueue.CurrentRow != null)
            {
                dl.Add((Download)dgvPreQueue.CurrentRow.DataBoundItem);
            }
            return dl;
        }

        private List<Download> GetSelectedInQueue()
        {
            var dl = new List<Download>();
            if (dgvQueue.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dgvQueue.Rows.Count; i++)
                    if (dgvQueue.Rows[i].Selected)
                        dl.Add((Download)dgvQueue.Rows[i].DataBoundItem);
            }
            else if (dgvQueue.CurrentRow != null)
            {
                dl.Add((Download)dgvQueue.CurrentRow.DataBoundItem);
            }
            return dl;
        }

        public void RemoveFromPreQueueSelected()
        {
            var dl = GetSelectedInPreQueue();
            dgvPreQueue.ClearSelection();
            foreach (var d in dl)
                TopManager.PreQueue.Remove(d);
        }

        public void RemoveFromQueueSelected()
        {
            var dl = GetSelectedInQueue();
            dgvQueue.ClearSelection();
            foreach (var d in dl)
                TopManager.Queue.Remove(d);
        }

        private void tsbDeleteFromPrequeue_Click(object sender, EventArgs e)
        {
            RemoveFromPreQueueSelected();
        }

        private void tsbPreQueueSetFolder_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInPreQueue();
            if (dl.Count == 0) return;
            var fm = new FolderBrowserDialog();
            if (fm.ShowDialog(this) != DialogResult.OK) return;
            foreach (var d in dl)
                d.Folder = fm.SelectedPath;
        }

        private void tsbPreQueueStartAll_Click(object sender, EventArgs e)
        {
            var dl = TopManager.PreQueue.ToList();
            if (dl.Count == 0) return;
            TopManager.AddFromPreQueue(dl);
            tabControl.SelectedTab = tpQueue;
        }

        private void tsbStartSelected_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInPreQueue();
            if (dl.Count == 0) return;
            dgvPreQueue.ClearSelection();
            TopManager.AddFromPreQueue(dl);
            tabControl.SelectedTab = tpQueue;
        }

        private void tsbPrequeueCheck_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInPreQueue();
            if (dl.Count == 0) return;
            TopManager.CheckStatus(dl);
        }

        public void MoveUpPreQueueSelected()
        {
            var dl = GetSelectedInPreQueue();
            if (dl.Count == 0) return;
            int toppos = int.MaxValue; ;
            if (dgvPreQueue.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dgvPreQueue.SelectedRows.Count; i++)
                    if (dgvPreQueue.SelectedRows[i].Index < toppos)
                        toppos = dgvPreQueue.SelectedRows[i].Index;
            }
            else if (dgvPreQueue.CurrentRow != null)
            {
                toppos = dgvPreQueue.CurrentRow.Index;
            }
            if (toppos == int.MaxValue) return;
            if (toppos == 0) return;
            toppos--;
            dgvPreQueue.ClearSelection();
            foreach (var d in dl)
                TopManager.PreQueue.Remove(d);
            foreach (var d in dl)
            {
                TopManager.PreQueue.Insert(toppos, d);
                dgvPreQueue.Rows[toppos].Selected = true;
                toppos++;
            }
        }

        public void MoveDownPreQueueSelected()
        {
            var dl = GetSelectedInPreQueue();
            if (dl.Count == 0) return;
            int toppos = int.MinValue;
            if (dgvPreQueue.SelectedRows.Count > 0)
            {
                for (int i = dgvPreQueue.Rows.Count-1; i >= 0; i--)
                    if (dgvPreQueue.Rows[i].Selected)
                    {
                        toppos = i;
                        break;
                    }
            }
            else if (dgvPreQueue.CurrentRow != null)
            {
                toppos = dgvPreQueue.CurrentRow.Index;
            }
            if (toppos == int.MinValue) return;
            if (toppos == TopManager.PreQueue.Count -1) return;
            toppos = toppos - dl.Count() + 2;
            dgvPreQueue.ClearSelection();
            foreach (var d in dl)
                TopManager.PreQueue.Remove(d);
            foreach (var d in dl)
            {
                TopManager.PreQueue.Insert(toppos, d);
                dgvPreQueue.Rows[toppos].Selected = true;
                toppos++;
            }
        }

        public void MoveUpQueueSelected()
        {
            var dl = GetSelectedInQueue();
            if (dl.Count == 0) return;
            int toppos = int.MaxValue; ;
            if (dgvQueue.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dgvQueue.SelectedRows.Count; i++)
                    if (dgvQueue.SelectedRows[i].Index < toppos)
                        toppos = dgvQueue.SelectedRows[i].Index;
            }
            else if (dgvQueue.CurrentRow != null)
            {
                toppos = dgvQueue.CurrentRow.Index;
            }
            if (toppos == int.MaxValue) return;
            if (toppos == 0) return;
            toppos--;
            foreach (var d in dl)
                TopManager.Queue.Remove(d);
            foreach (var d in dl)
            {
                TopManager.Queue.Insert(toppos, d);
                toppos++;
            }
            SelectQueueRows(dl);
        }

        public void MoveDownQueueSelected()
        {
            var dl = GetSelectedInQueue();
            if (dl.Count == 0) return;
            int toppos = int.MinValue;
            if (dgvQueue.SelectedRows.Count > 0)
            {
                for (int i = dgvQueue.Rows.Count - 1; i >= 0; i--)
                    if (dgvQueue.Rows[i].Selected)
                    {
                        toppos = i;
                        break;
                    }
            }
            else if (dgvQueue.CurrentRow != null)
            {
                toppos = dgvQueue.CurrentRow.Index;
            }
            if (toppos == int.MinValue) return;
            if (toppos == TopManager.Queue.Count - 1) return;
            toppos = toppos - dl.Count() + 2;
            foreach (var d in dl)
                TopManager.Queue.Remove(d);
            foreach (var d in dl)
            {
                TopManager.Queue.Insert(toppos, d);
                toppos++;
            }
            SelectQueueRows(dl);
        }

        public void SelectQueueRows(List<Download> dl)
        {
            if (dl == null || dl.Count == 0) return;
            dgvQueue.ClearSelection();
            for (int i = 0; i < dgvQueue.Rows.Count; i++)
            {
                if (!dl.Contains(dgvQueue.Rows[i].DataBoundItem)) continue;
                dgvQueue.Rows[i].Selected = true;
            }
        }

        private void dgvPreQueue_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                RemoveFromPreQueueSelected();
                e.Handled = true;
                return;
            }
        }

        private void dgvPreQueue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && e.Control && !e.Shift)
            {
                MoveUpPreQueueSelected();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Down && e.Control && !e.Shift)
            {
                MoveDownPreQueueSelected();
                e.Handled = true;
                return;
            }
        }

        private void tsbPreQueueUp_Click(object sender, EventArgs e)
        {
            MoveUpPreQueueSelected();
        }

        private void tsbPreQueueDown_Click(object sender, EventArgs e)
        {
            MoveDownPreQueueSelected();
        }

        private void dgvQueue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveFromQueueSelected();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Up && e.Control && !e.Shift)
            {
                MoveUpQueueSelected();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Down && e.Control && !e.Shift)
            {
                MoveDownQueueSelected();
                e.Handled = true;
                return;
            }
        }

        private void tsbQueueUp_Click(object sender, EventArgs e)
        {
            MoveUpQueueSelected();
        }

        private void tsbQueueDown_Click(object sender, EventArgs e)
        {
            MoveDownQueueSelected();
        }

        private void tsbQueueStart_Click(object sender, EventArgs e)
        {
            TopManager.Start();
        }

        private void tsbQueueStop_Click(object sender, EventArgs e)
        {
            TopManager.Stop();
        }

        private void tsbQueueRemove_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInQueue();
            TopManager.RemoveFromQueue(dl);
        }

        private void miQueueRemove_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInQueue();
            TopManager.RemoveFromQueue(dl);
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInQueue();
            TopManager.ReSetInQueue(dl);
        }

        private void miQueueReset_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInQueue();
            TopManager.ReSetInQueue(dl);
        }

        private void tsbRecover_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInQueue();
            TopManager.RecoverInQueue(dl);
        }

        private void miQueueRecover_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInQueue();
            TopManager.RecoverInQueue(dl);
        }

        private void tsbQueueDisable_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInQueue();
            TopManager.DisableInQueue(dl);
        }

        private void tsbQueueEnable_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInQueue();
            TopManager.EnableInQueue(dl);
        }

        private void miQueueEnable_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInQueue();
            TopManager.EnableInQueue(dl);
        }

        private void miQueueDisable_Click(object sender, EventArgs e)
        {
            var dl = GetSelectedInQueue();
            TopManager.DisableInQueue(dl);
        }

        public string FormatTime(TimeSpan tsp)
        {
            string stime = "";

            if (tsp.TotalDays < 10d)
            {
                if (tsp.TotalHours < 1d)
                    stime = string.Format("{0:00}:{1:00}", tsp.Minutes, tsp.Seconds);
                else if (tsp.TotalHours < 24d)
                    stime = string.Format("{0:00}.{1:00}:{2:00}", tsp.Hours, tsp.Minutes, tsp.Seconds);
                else
                    stime = string.Format("{0:0}d {1:00}:{2:00}:{3:00}", 
                        (int)Math.Floor(tsp.TotalDays), tsp.Hours, tsp.Minutes, tsp.Seconds);
            }

            return stime;
        }

        public void UpdateStatusBar()
        {
            long totalbytes = 0;
            long leftbytes = 0;
            long speed = 0;
            TimeSpan tsp = TimeSpan.Zero;
            string stime = "";

            TopManager.GetSumms(out totalbytes, out leftbytes, out speed);
            if (speed > 100)
            {
                tsp = TimeSpan.FromSeconds((double)leftbytes / (double)speed);
                stime = FormatTime(tsp);
            }

            stTotal.Text = Utils.GetFileSizeString(totalbytes);
            stLeft.Text = Utils.GetFileSizeString(leftbytes);
            stSpeed.Text = Utils.GetFileSizeString(speed) + "/s";
            stTime.Text = stime;
            if (totalbytes > 0)
                stProgress.Value = 100 - (int)(leftbytes * 100 / totalbytes);
            else
                stProgress.Value = 0;
        }

        private void bsQueue_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateStatusBar();
        }

        private void dgvQueue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgcQueueETL.Index)
            {
                var tsp = (TimeSpan)e.Value;
                if(tsp.TotalSeconds == 0)
                {
                    e.Value = "??:??";
                }
                else
                {
                    e.Value = FormatTime(tsp);
                }
                e.FormattingApplied = true;
                return;
            }
        }

        private void dgvLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var m = (MyLogMsg)dgvLog.Rows[e.RowIndex].DataBoundItem;
            MessageBox.Show(m.Msg);
        }

        private void chShutdown_CheckedChanged(object sender, EventArgs e)
        {
            TopManager.Settings.ShutDown = chShutdown.Checked;
        }

        private void cbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFontSize.SelectedIndex == -1) return;
            int fs = int.Parse(cbFontSize.SelectedValue as string);
            TopManager.Settings.FontSize = fs;
            this.Font = new Font(this.Font.FontFamily, TopManager.Settings.FontSize);
        }

        private void dgcQueueStatus_ColorMarkNeeded(object sender, MyLib.Components.DataGridViewColorMarkColumnEventArgs e)
        {
            if (e.RowNr < 0) return;
            var d = (Download)dgvQueue.Rows[e.RowNr].DataBoundItem;
            if (!d.Enabled)
            {
                e.MarkColor = someConfig1.ColorDisabled;
                return;
            }
            switch (d.Status)
            {
                case EDownloadStatus.Error:
                    e.MarkColor = someConfig1.ColorError;
                    break;
                case EDownloadStatus.Completed:
                    e.MarkColor = someConfig1.ColorCompleted;
                    break;
                case EDownloadStatus.Ready:
                case EDownloadStatus.Stopped:
                    e.MarkColor = someConfig1.ColorReady;
                    break;

                default:
                    e.MarkColor = someConfig1.ColorRunning;
                    break;
            }
        }

    }
}
