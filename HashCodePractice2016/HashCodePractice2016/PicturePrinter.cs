using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HashCodePractice2016
{
    public class PicturePrinter : UserControl
    {
        public PictureDescription pic;

        public PicturePrinter()
        {
            DoubleBuffered = true;
            Visible = true;

            Paint += PicturePrinter_Paint;
            Resize += (sender, e) => Invalidate();
        }

        private void PicturePrinter_Paint(object sender, PaintEventArgs e)
        {
            if (pic == null) return;

            var w = Width;
            var h = Height;

            var cw = ((float)w) / pic.NumCols;
            var ch = ((float)h) / pic.NumRows;

            for (int i = 0; i < pic.NumRows; ++i)
            {
                for (int j = 0; j < pic.NumCols; ++j)
                {
                    if (pic.IsFilled(j, i))
                    {
                        e.Graphics.FillRectangle(Brushes.CornflowerBlue, new Rectangle((int)(j * cw), (int)(i * ch), (int)cw+1, (int)ch+1));
                    }
                }
            }

            for (int i = 1; i < pic.NumCols; ++i)
            {
                e.Graphics.DrawLine(Pens.Black,
                    new Point((int)(i * cw), 0),
                    new Point((int)(i * cw), h));
            }

            for (int i = 1; i < pic.NumCols; ++i)
            {
                e.Graphics.DrawLine(Pens.Black,
                    new Point(0, (int)(i * ch)),
                    new Point(w, (int)(i * ch)));
            }
        }
    }
}
