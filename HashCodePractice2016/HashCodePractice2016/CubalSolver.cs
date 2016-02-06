using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePractice2016
{
    public static class CubalSolver
    {
        public static Solution Solve(PictureDescription descriptor)
        {
            var solution = new Solution(descriptor);

            while (!solution.Covers(descriptor))
            {
                int bestScore = int.MinValue;
                Command? bestCommand = null;

                TryHorizontalLines(descriptor, solution, ref bestCommand, ref bestScore);

                solution.AddCommand(bestCommand.Value);
            }

            solution.AddClearCommands(descriptor);

            return solution;
        }

        private static void TryHorizontalLines(PictureDescription descriptor, Solution solution, ref Command? bestCommand, ref int bestScore)
        {
            for (int y = 0; y < descriptor.NumRows; ++y)
            {
                for (int x = 0; x < descriptor.NumCols;)
                {
                    int startX = x;
                    int skippedPositions = 0;
                    int score = 0;
                    while (x < descriptor.NumCols && descriptor.IsFilled(x, y) || (score > 0 && skippedPositions++ == 0))
                    {
                        if (!solution.IsFilled(x, y))
                        {
                            ++score;
                        }

                        ++x;
                    }
                    int endX = x;
                    score -= skippedPositions;

                    int len = endX - startX + 1;

                    if (len > 0 && score > 0 && score > bestScore)
                    {
                        var command = solution.MakeHorizontalLine(x, y, len);

                        if (score > bestScore)
                        {
                            bestCommand = command;
                            bestScore = score;
                        }
                    }
                }
            }
        }
    }
}
