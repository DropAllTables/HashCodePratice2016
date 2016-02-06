using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace HashCodePractice2016
{
    public static class PictureReader
    {
        public static PictureDescription ReadFromFile(string filename)
        {
            using (var reader = File.OpenText(filename))
            {
                string descLine = reader.ReadLine();

                var match = Regex.Match(descLine, "^([0-9]+) ([0-9]+)$");
                int nRows = int.Parse(match.Groups[1].Value);
                int nCols = int.Parse(match.Groups[2].Value);

                var desc = new PictureDescription(nRows, nCols);

                for (int i = 0; i < nRows; ++i)
                {
                    var line = reader.ReadLine();

                    for (int j = 0; j < nCols; ++j)
                    {
                        char ch = line[j];

                        if (ch == '.')
                        {
                            // Do nothing
                        } else if (ch == '#')
                        {
                            desc.Fill(j, i);
                        } else
                        {
                            throw new NotImplementedException();
                        }
                    }
                }

                return desc;
            }
        }
    }
}
