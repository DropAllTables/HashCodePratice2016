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
            var sol = new Solution();
            sol.AddCommand(Solution.MakeVerticalLine(3, 2, 4));
            sol.AddCommand(Solution.MakeHorizontalLine(3, 2, 4));
            sol.AddCommand(Solution.MakeSquare(4, 4, 3));
            sol.AddCommand(Solution.MakeClear(2, 2));
            sol.WriteToFile("out.txt");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(pic));
        }
    }
}
