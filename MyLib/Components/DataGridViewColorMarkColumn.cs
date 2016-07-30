using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace MyDownloader.MyLib.Components
{
    public class DataGridViewColorMarkColumn : DataGridViewImageColumn
    {
        public event DataGridViewColorMarkColumnEvent ColorMarkNeeded;

        public DataGridViewColorMarkColumn()
        {
            CellTemplate = new DataGridViewColorMarkCell();
        }

        public bool GetColorMark(int row, out Color c)
        {
            c = Color.White;
            if (ColorMarkNeeded == null) return false;
            var ea = new DataGridViewColorMarkColumnEventArgs(c, row);
            ColorMarkNeeded(this, ea);
            c = ea.MarkColor;
            return true;
        }
    }

    public class DataGridViewColorMarkColumnEventArgs : EventArgs
    {
        public Color MarkColor = Color.White;
        public int RowNr = -1;
        public DataGridViewColorMarkColumnEventArgs(Color c, int rnr)
        {
            MarkColor = c;
            RowNr = rnr;
        }
    }

    public delegate void DataGridViewColorMarkColumnEvent(object sender, DataGridViewColorMarkColumnEventArgs e);

    public class DataGridViewColorMarkCell : DataGridViewImageCell
    {
        // Used to make custom cell consistent with a DataGridViewImageCell
        static Image emptyImage;
        static DataGridViewColorMarkCell()
        {
            emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public DataGridViewColorMarkCell()
        {
            this.ValueType = typeof(int);
        }
        // Method required to make the Progress Cell consistent with the default Image Cell. 
        // The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an int.
        protected override object GetFormattedValue(object value,
                            int rowIndex, ref DataGridViewCellStyle cellStyle,
                            TypeConverter valueTypeConverter,
                            TypeConverter formattedValueTypeConverter,
                            DataGridViewDataErrorContexts context)
        {
            return emptyImage;
        }

        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                string text = value == null ? "" : (string)value;
                Brush backColorBrush = new SolidBrush(cellStyle.BackColor);
                Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);
                var col = this.OwningColumn as DataGridViewColorMarkColumn;
                Color markcolor = cellStyle.ForeColor;
                bool hasmark = col.GetColorMark(rowIndex, out markcolor);
                Brush markColorBrush = new SolidBrush(markcolor);

                base.Paint(g, clipBounds, cellBounds,
                    rowIndex, cellState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

                int rsz = cellBounds.Height - 8;
                g.FillEllipse(markColorBrush, cellBounds.X + 2, cellBounds.Y + 4, rsz, rsz);
                //g.FillRectangle(markColorBrush, cellBounds.X + 2, cellBounds.Y + 4, rsz, rsz);
                g.DrawString(text, cellStyle.Font, foreColorBrush, cellBounds.X + 4 + rsz, cellBounds.Y + 2);
            }
            catch (Exception e) { }

        }
    }

}
