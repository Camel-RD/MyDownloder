using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace MyLIB.Components
{
    public class DataGridViewProgressColumn : DataGridViewImageColumn
    {
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }
    }


    class DataGridViewProgressCell : DataGridViewImageCell
    {
        // Used to make custom cell consistent with a DataGridViewImageCell
        static Image emptyImage;
        static DataGridViewProgressCell()
        {
            emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public DataGridViewProgressCell()
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


        private Color GetColorBetween(Color a, Color b, float f)
        {
            byte R = (byte)(a.R + (byte)((float)(b.R - a.R) * f));
            byte G = (byte)(a.G + (byte)((float)(b.G - a.G) * f));
            byte B = (byte)(a.B + (byte)((float)(b.B - a.B) * f));
            return Color.FromArgb(R, G, B);
        }

        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                int progressVal = (int)value;
                if(progressVal < 0) progressVal = 0;
                if(progressVal > 100) progressVal = 100;
                float percentage = ((float)progressVal / 100.0f);

                Brush backColorBrush = new SolidBrush(cellStyle.BackColor);
                Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);
                Brush barColorBrush = new SolidBrush(GetColorBetween(cellStyle.BackColor, 
                    cellStyle.ForeColor, progressVal == 100 ? 0.2f : 0.3f));

                base.Paint(g, clipBounds, cellBounds,
                    rowIndex, cellState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

                var s = progressVal.ToString() + "%";
                var sz = g.MeasureString(s, cellStyle.Font);
                int dy = (cellBounds.Height - this.DataGridView.RowTemplate.Height) / 2;

                g.FillRectangle(barColorBrush, cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4);
                g.DrawString(s, cellStyle.Font, foreColorBrush, cellBounds.X + (cellBounds.Width / 2) - sz.Width / 2 - 5, cellBounds.Y + 2 + dy);
            }
            catch (Exception e) { }

        }
    }
}
