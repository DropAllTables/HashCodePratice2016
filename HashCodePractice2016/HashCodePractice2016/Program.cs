using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashCodePractice2016
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var pic = PictureReader.ReadFromFile("learn_and_teach.in");

            var ponteSolution = LinesAlgorithm.solve(pic);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(pic));
        }
    }
}
