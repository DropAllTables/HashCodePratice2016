using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePractice2016
{
    public static class LinesAlgorithm
    {
        enum DrawState
        {
            EMPTY,
            FILL
        }
        public static Solution solve(PictureDescription pd)
        {
            Solution solution = new Solution(pd);
            //PictureDescription auxPd = new PictureDescription(pd.NumRows, pd.NumCols);
            for (int row = 0; row < pd.NumRows; row++)
            {
                DrawState currentState = DrawState.EMPTY;
                int[] from = new int[2];
                int length = 0;

                for (int column = 0; column < pd.NumCols; column++)
                {
                    switch (currentState)
                    {
                        case DrawState.EMPTY:
                            if (pd.IsFilled(column, row))
                            {
                                from[0] = column;
                                from[1] = row;
                                length = 1;
                                currentState = DrawState.FILL;
                                if (column == pd.NumCols - 1)
                                {
                                    solution.AddCommand(solution.MakeHorizontalLine(from[0], from[1], length));
                                    currentState = DrawState.EMPTY;
                                }
                            }

                            break;
                        case DrawState.FILL:
                            if (!pd.IsFilled(column, row))
                            {
                                solution.AddCommand(solution.MakeHorizontalLine(from[0], from[1], length));
                                currentState = DrawState.EMPTY;
                            }else if (column == pd.NumCols - 1)
                            {
                                solution.AddCommand(solution.MakeHorizontalLine(from[0], from[1], ++length));
                                currentState = DrawState.EMPTY;
                            }
                            else
                            {
                                length++;
                            }
                            break;
                    }
                }
            }

            return solution;
        }
    }
}
