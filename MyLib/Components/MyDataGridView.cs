﻿using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyLIB.Misc;
using System.Reflection;

namespace MyLIB.Components
{
    public class MyDataGridView : DataGridView
    {
        private ContextMenuStrip myContextMenuStrip = null;
        private bool _useMyContextmenu = true;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool GoingToDialog { get; set; }

        [DefaultValue(true),
        Category("Behavior")]
        public bool TakeCtrlTabKey { get; set; }

        [DefaultValue(true)]
        [Category("Data")]
        public bool AutoSave { get; set; }

        [Category("My")]
        public event KeyEventHandler MyKeyDown;

        [Category("My")]
        public event EventHandler MyCheckForChanges;

        [Category("My")]
        [DefaultValue(true)]
        public bool UseMyContextmenu
        {
            get
            {
                return _useMyContextmenu;
            }
            set
            {
                if (value == _useMyContextmenu) return;
                _useMyContextmenu = value;
                if (value)
                {
                    this.ContextMenuStrip = myContextMenuStrip;
                }
                else
                {
                    this.ContextMenuStrip = null;
                }
            }
        } 

        public MyDataGridView() : base()
        {
            GoingToDialog = false;
            TakeCtrlTabKey = true;
            DoubleBuffered = true;
            AutoSave = true;
            DataError += MyDataGridView_DataError;
            this.BackgroundColor = SystemColors.Control;

            myContextMenuStrip = new ContextMenuStrip();
            myContextMenuStrip.Items.Add("Copy (Ctrl + C)", null, OnCopy);
            this.ContextMenuStrip = myContextMenuStrip;

            SetMyToolTip();
        }

        protected void SetMyToolTip()
        {
            var fi = Utils.GetField(this.GetType(), "toolTipControl");
            var dtt = fi.GetValue(this);
            var fi2 = Utils.GetField(dtt.GetType(), "toolTip");
            var dToolTip = new MyToolTip();
            dToolTip.ShowAlways = true;
            dToolTip.InitialDelay = 0;
            dToolTip.UseFading = false;
            dToolTip.UseAnimation = false;
            dToolTip.AutoPopDelay = 0;
            fi2.SetValue(dtt, dToolTip);
        }

        private void OnCopy(object sender, EventArgs e)
        {
            Copy();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            clickTimer.Interval = SystemInformation.DoubleClickTime + 10;
            clickTimer.Tick += new EventHandler(OnClickTimerTick);
            //clickTimer.SynchronizingObject = this.FindForm();
            if (!DesignMode)
            {
                CheckSizes(10.0f);
            }
            Form f = this.FindForm();
            if(f != null)
                f.FormClosing += My_FormClosing;
        }

        protected override void DestroyHandle()
        {
            this.GetClipboardContent();
            clickTimer.Stop();
            clickTimer.Tick -= new EventHandler(OnClickTimerTick);
            clickTimer.Dispose();
            this.FindForm().FormClosing -= My_FormClosing;
            base.DestroyHandle();
        }


        protected SizeF _ScaleFactor = new SizeF(1.0f, 1.0f);
        public SizeF ScaleFactor { get { return _ScaleFactor; } }
        
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);

            float width = factor.Width;
            float height = factor.Height;
            _ScaleFactor.Width *= width;
            _ScaleFactor.Height *= height;

            if (width != 1.0f)
            {
                foreach (DataGridViewColumn cmn in Columns)
                {
                    cmn.MinimumWidth = (int)Math.Max(((float)cmn.MinimumWidth * width), 2);
                    cmn.Width = (int) ((float) cmn.Width*width);
                }
            }

            if (height != 1.0f)
            {
                foreach (var row in Rows)
                {
                    var r = row as DataGridViewRow;
                    if (r != null)
                        r.Height = (int) ((float) (r.Height - 0)*height) + 0;
                }
                this.RowTemplate.Height = (int) ((float)(RowTemplate.Height - 2) * height) + 2;
            }
        }

        public void CheckSizes(float basefontaize)
        {
            // ---- no need for this
            /*
            float f1 = 1.0f;
            if (MyFormBase.DPIFactor != -1.0f) 
                f1 = MyFormBase.DPIFactor;
            if (f1 == 1.0f) return;
            _ScaleFactor.Width *= f1;
            _ScaleFactor.Height *= f1;
            float w;
            foreach (DataGridViewColumn cmn in Columns)
            {
                w = (float)cmn.Width * f1;
                cmn.Width = (int)Math.Round(w, 0);
            }
            w = (float)this.RowTemplate.Height;
            w = w * f1;
            this.RowTemplate.Height = (int)Math.Round(w, 0);
            */
        }

        public int[] GetColumnWidths(float basefontaize)
        {
            float w, fs = DefaultCellStyle.Font.SizeInPoints;
            int[] cw = new int[Columns.Count];
            for (int i = 0; i < Columns.Count; i++)
            {
                w = (float) Columns[i].Width/ScaleFactor.Width;
                cw[i] = (int) Math.Round(w, 0);
            }
            return cw;
        }
        
        public void SetColumnWidths(int[] widths)
        {
            if (widths.Length != Columns.Count) return;
            for (int i = 0; i < Columns.Count; i++)
            {
                Columns[i].Width = (int)Math.Round((float)widths[i] * ScaleFactor.Width, 0);
            }
        }
        

        private int FirstVisibleColumn()
        {
            for (int i = 0; i < this.ColumnCount; i++)
            {
                if (this.Columns[i].Visible) return i;
            }
            return -1;
        }

        public void MoveToNewRow(int columnindex = -1)
        {
            if (!this.AllowUserToAddRows || this.ReadOnly) return;
            if (columnindex == -1)
            {
                columnindex = FirstVisibleColumn();
                if (columnindex == -1) return;
            }
            this.CurrentCell = this[columnindex, this.NewRowIndex];
        }

        public DataRow GetCurrentDataRow()
        {
            if (this.CurrentRow == null || 
                this.CurrentRow.IsNewRow) return null;
            try
            {
                object o = this.CurrentRow.DataBoundItem;
                if (o == null) return null;
                var drv = o as DataRowView;
                if (drv == null) return null;
                return drv.Row;
            }
            catch (Exception){}
            return null;
        }

        public DataRow GetDataRow(int k)
        {
            object o = GetDataItem(k);
            if (o == null) return null;
            var drv = o as DataRowView;
            if (drv == null) return null;
            return drv.Row;
        }

        public object GetCurrentDataItem()
        {
            if (this.CurrentRow == null || this.CurrentRow.Index == -1 ||
                this.CurrentRow.IsNewRow) return null;
            try
            {
                CurrencyManager cm = (CurrencyManager)this.BindingContext[this.DataSource, this.DataMember];
                if (cm == null || this.CurrentRow.Index >= cm.Count) return null;
                return this.CurrentRow.DataBoundItem;
            }
            catch (Exception){}
            return null;
        }

        public object GetDataItem(int k)
        {
            try
            {
                if (k < 0 || k >= this.Rows.Count ||
                    k == this.NewRowIndex) return null;
                return this.Rows[k].DataBoundItem;
            }
            catch (Exception) { }
            return null;
        }

        private void My_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.EndEdit();
        }


        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Tab:
                    if (e.Control && TakeCtrlTabKey)
                    {
                        e.IsInputKey = true;
                        return;
                    }
                    break;
            }
            base.OnPreviewKeyDown(e);
        }

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    if (e.Control)
                    {
                        OnMyKeyDown(e);
                        return true;
                    }
                    break;
                case Keys.Enter:
                    if (!e.Control)
                    {
                        return ProcessRightKey(e.KeyData & ~(Keys.Control | Keys.Shift));
                        //return ProcessTabKey(e.KeyData & ~(Keys.Control | Keys.Shift));
                    }
                    break;
                case Keys.Delete:
                    if (e.Control)
                    {
                        OnMyKeyDown(e);
                        return true;
                    }
                    break;
                case Keys.Insert:
                    if (e.Control || e.Shift)
                    {
                        OnMyKeyDown(e);
                        return true;
                    }
                    break;
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                return Copy();
            }

            return base.ProcessDataGridViewKey(e);
        }

        private object lastCurrentRow = null;
        private static DateTime lastCheckCurrentRowTime = DateTime.MinValue;

        protected void CheckCurrentRowChanged()
        {
            var o = GetCurrentDataItem();
            if (o == lastCurrentRow) return;
            if (lastCurrentRow == null)
            {
                lastCurrentRow = o;
                return;
            }
            lastCurrentRow = o;
            if (o != null && MyCheckForChanges != null)
                MyCheckForChanges(this, new EventArgs());
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            CheckCurrentRowChanged();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            CheckCurrentRowChanged();
        }

        /*
        private bool AllowUserToAddRowsA = true;
        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex != this.NewRowIndex)
            {
                AllowUserToAddRowsA = this.AllowUserToAddRows;
                this.AllowUserToAddRows = false;
            }
            base.OnCellBeginEdit(e);
        }

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            this.AllowUserToAddRows = AllowUserToAddRowsA;
            base.OnCellEndEdit(e);
        }
        */

        public bool Copy()
        {
            try
            {
                //DataFormats.UnicodeText - has tab separeted values
                string csv = (string) this.GetClipboardContent().GetData(DataFormats.UnicodeText);

                /*
                var dataObject = new DataObject();
                var bytes = System.Text.Encoding.UTF8.GetBytes(csv);
                var stream = new System.IO.MemoryStream(bytes);
                dataObject.SetData(DataFormats.CommaSeparatedValue, stream);
                Clipboard.SetDataObject(dataObject, true);
                 */
                Clipboard.SetText(csv);
            }
            catch (Exception)
            {
                
            }
            return true;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            Keys key = (keyData & Keys.KeyCode);
            switch (key)
            {
                case Keys.F3:
                case Keys.F5:
                    OnMyKeyDown(new KeyEventArgs(keyData));
                    return true;

                case Keys.Enter:
                    /*
                    if (ProcessNextKey(keyData & ~(Keys.Control | Keys.Shift)))
                    {
                        return true;
                    }*/
                    if ((keyData & Keys.Control) == 0)
                    {
                        if (ProcessRightKey(keyData & ~(Keys.Control | Keys.Shift)))
                        {
                            return true;
                        }
                    }
                    break;
            }

            var ret = base.ProcessDialogKey(keyData);
            CheckCurrentRowChanged();
            return ret;
        }

        public void RefreshCurrent()
        {
            if (CurrentRow == null || CurrentRow.IsNewRow) return;
            this.InvalidateRow(CurrentRow.Index);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            var pen = new Pen(this.ForeColor, 1);
            pevent.Graphics.DrawRectangle(pen, 0, 0, Width-1, Height-1);
        }

        public bool EndEditX()
        {
            if (!EndEdit()) return false;
            var bs = DataSource as BindingSource;
            if (bs == null || CurrentRow == null ||
                CurrentRow.IsNewRow ||
                bs.Current == null) return true;

            var drv = bs.Current as DataRowView;
            if (drv == null) return true;
            if (drv.Row.RowState == DataRowState.Detached) return true;

            try
            {
                bs.EndEdit();
                this.InvalidateRow(CurrentRow.Index);
                return true;
            }
            catch (Exception e)
            {
                //Form_Error.ShowException(e, this);
                return false;
            }
        }




        private const int WM_CHAR = 0x0102;

        protected override void OnValidating(CancelEventArgs e)
        {
            if (GoingToDialog) return;
            base.OnValidating(e);
        }
        public void OnMyKeyDown(KeyEventArgs e)
        {
            if (MyKeyDown != null)
                MyKeyDown(this, e);
        }

        private void MyDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                //MyException mex = ExceptionHelper.TranslateException(e.Exception, this);
                //Form_Error.ShowException(mex);
            }
            e.Cancel = true;
        }


        private Timer clickTimer = new Timer();
        private DataGridViewCellEventArgs cellClickEventArgs = null;
        
        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            //base.OnCellClick(e);
            //return;

            if (clickTimer.Enabled)
            {
                clickTimer.Stop();
                if (e.ColumnIndex == cellClickEventArgs.ColumnIndex
                    && e.RowIndex == cellClickEventArgs.RowIndex)
                {
                    OnCellDoubleClick(e);
                    return;
                }
            }
            cellClickEventArgs = new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex);
            clickTimer.Start();
        }

        protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            clickTimer.Stop();
            base.OnCellDoubleClick(e);
        }
        
        private void OnClickTimerTick(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated) return;
            if (this.RowCount == 0) return;
            clickTimer.Stop();
            if (CurrentCell == null) return;
            if (cellClickEventArgs.RowIndex < 0) return;
            if (cellClickEventArgs.RowIndex >= Rows.Count) return;
            base.OnCellClick(cellClickEventArgs);
        }
    }
}
