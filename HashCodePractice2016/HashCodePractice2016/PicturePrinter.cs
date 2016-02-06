using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashCodePractice2016
{
    public class PicturePrinter : UserControl
    {
        public PicturePrinter()
        {
            DoubleBuffered = true;
            Visible = true;

            Paint += PicturePrinter_Paint;
            Resize += (sender, e) => Invalidate();
        }

        private void PicturePrinter_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(System.Drawing.Brushes.Red, new System.Drawing.Rectangle(0, 0, 200, 200));
        }
    }
}
