using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HashCodePractice2016
{
    public static class PictureReader
    {
        public static PictureDescription ReadFromFile(string filename)
        {
            using (var reader = File.OpenText(filename))
            {
                string descLine = reader.ReadLine();

                return new PictureDescription(1, 1);
            }
        }
    }
}
