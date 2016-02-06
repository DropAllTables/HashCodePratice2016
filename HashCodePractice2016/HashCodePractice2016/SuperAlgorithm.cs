using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePractice2016
{
    class SuperAlgorithm
    {

        public static HashMapGrid hashmapSquares(PictureDescription grid)
        {
            HashMapGrid gridToReturn = new HashMapGrid(grid.NumRows, grid.NumCols);

            for (int y = 0; y < grid.NumRows; y++)
            {
                for (int x = 0; x < grid.NumCols; x++)
                {
                    if (!grid.IsFilled(x, y))
                    {
                        gridToReturn.SetValue(x, y, 0);
                    }
                    else
                    {
                        gridToReturn.SetValue(x, y, 0);
                        for (int width = 1; x + width < grid.NumCols && x - width >= 0
                            && y + width < grid.NumRows && y - width >= 0; width++)
                        {
                            Boolean valid = true;
                            for (int xx = x - width; xx <= x + width; xx++)
                            {
                                for (int yy = y - width; yy <= y + width; y++)
                                {
                                    if (!grid.IsFilled(xx, yy))
                                    {
                                        valid = false;
                                        goto terminate;
                                    }
                                }
                            }
                            terminate:
                            if (valid)
                            {
                                gridToReturn.SetValue(x, y, width);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return gridToReturn;
        }

        public static HashMapGrid hashmapHorizontalLines(PictureDescription grid)
        {
            HashMapGrid gridToReturn = new HashMapGrid(grid.NumRows, grid.NumCols);

            for (int y = 0; y < grid.NumRows; y++)
            {
                for (int x = 0; x < grid.NumCols; x++)
                {
                    if (!grid.IsFilled(x, y))
                    {
                        gridToReturn.SetValue(x, y, 0);
                    }
                    else
                    {

                        int count = 1;

                        for (int xx = x + 1; xx < grid.NumCols; xx++)
                        {
                            if (grid.IsFilled(xx, y))
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        for (int xx = x - 1; xx >= 0; xx--)
                        {
                            if (grid.IsFilled(xx, y))
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        gridToReturn.SetValue(x, y, count);
                    }
                }
            }
            return gridToReturn;
        }

        public static HashMapGrid hashmapVerticalLines(PictureDescription grid)
        {
            HashMapGrid gridToReturn = new HashMapGrid(grid.NumRows, grid.NumCols);

            for (int x = 0; x < grid.NumCols; x++)
            {
                for (int y = 0; y < grid.NumRows; y++)
                {
                    if (!grid.IsFilled(x, y))
                    {
                        gridToReturn.SetValue(x, y, 0);
                    }
                    else
                    {

                        int count = 1;

                        for (int yy = y + 1; yy < grid.NumRows; yy++)
                        {
                            if (grid.IsFilled(x, yy))
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        for (int yy = y - 1; yy >= 0; yy--)
                        {
                            if (grid.IsFilled(x, yy))
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        gridToReturn.SetValue(x, y, count);
                    }
                }
            }
            return gridToReturn;
        }
    }
}
