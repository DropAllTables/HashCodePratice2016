using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePractice2016
{
    public static class Validator
    {

        public static bool Validate(Solution solution, PictureDescription pd)
        {
            for (int row = 0; row < pd.NumRows; row++)
            {
                for (int column = 0; column < pd.NumCols; column++)
                {
                    if(solution.IsFilled(column, row) != pd.IsFilled(column, row))
                    {
                        Console.WriteLine(row + " " + column);
                        return false;
                    }
                }
            }
            return true;
        }

        public static int Score(Solution solution, PictureDescription pd)
        {
            if(!Validate(solution, pd))
            {
                return 0;
            }
            return 0;
        }
    }
}
