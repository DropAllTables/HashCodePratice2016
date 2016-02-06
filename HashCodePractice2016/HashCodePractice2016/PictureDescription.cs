using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePractice2016
{
    public sealed class PictureDescription
    {
        private bool[,] data;

        public PictureDescription(int nRows, int nCols)
        {
            data = new bool[nRows, nCols];
        }

        public int NumRows
            => data.GetLength(0);

        public int NumCols
            => data.GetLength(1);

        public bool IsFilled(int x, int y)
        {
            return data[y, x];
        }

        public void Fill(int x, int y)
        {
            data[y, x] = true;
        }
    }
}
