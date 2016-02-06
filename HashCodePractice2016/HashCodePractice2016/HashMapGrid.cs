using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePractice2016
{
    public sealed class HashMapGrid
    {
        private int[,] data;

        public HashMapGrid(int nRows, int nCols)
        {
            data = new int[nRows, nCols];
        }

        public int NumRows
            => data.GetLength(0);

        public int NumCols
            => data.GetLength(1);

        public int GetValue(int x, int y)
        {
            return data[y, x];
        }

        public void SetValue(int x, int y, int value)
        {
            data[y, x] = value;
        }
    }
}
