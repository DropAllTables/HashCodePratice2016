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
            /*
            var sol = new Solution(pic);
            sol.AddCommand(sol.MakeVerticalLine(3, 2, 4));
            sol.AddCommand(sol.MakeHorizontalLine(3, 2, 4));
            sol.AddCommand(sol.MakeSquare(4, 4, 3));
            sol.AddCommand(sol.MakeClear(2, 2));
            sol.WriteToFile("out.txt");*/
            var pic = PictureReader.ReadFromFile("learn_and_teach.in");
            var ponteSolution = LinesAlgorithm.solve(pic);
            Console.WriteLine(Validator.Validate(ponteSolution, pic));
            ponteSolution.WriteToFile("ponte.txt");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(pic));
        }
    }
}
