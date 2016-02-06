using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodePractice2016
{
    public class Solution
    {
        public enum CommandType
        {
            HorizontalLine,
            VerticalLine,
            Square,
            Clear
        }

        public struct Command
        {
            public CommandType type;
            public int x, y;
            public int len;
        }

        public static Command MakeClear(int x, int y)
        {
            return new Command { type = CommandType.Clear, x = x, y = y };
        }

        public static Command MakeHorizontalLine(int x, int y, int length)
        {
            return new Command { type = CommandType.HorizontalLine, x = x, y = y, len = length };
        }

        public static Command MakeVerticalLine(int x, int y, int length)
        {
            return new Command { type = CommandType.VerticalLine, x = x, y = y, len = length };
        }

        public static Command MakeSquare(int centerX, int centerY, int sideLength)
        {
            if (sideLength % 2 == 0)
            {
                throw new ArgumentException(nameof(sideLength));
            }
            return new Command { type = CommandType.Square, x = centerX, y = centerY, len = sideLength };
        }

        public List<Command> commands = new List<Command>();

        public void AddCommand(Command command)
        {
            commands.Add(command);
        }

        public bool IsFilled(int x, int y)
        {
            for (int i = commands.Count - 1; i >= 0; --i)
            {
                var command = commands[i];

                switch (command.type)
                {
                    case CommandType.Clear:
                        if (command.x == x && command.y == y) return false;
                        break;
                    case CommandType.HorizontalLine:
                        if (command.x <= x && command.x + command.len > x && command.y == y) return true;
                        break;
                    case CommandType.VerticalLine:
                        if (command.y <= y && command.y + command.len > y && command.x == x) return true;
                        break;
                    case CommandType.Square:
                        int dist = command.len / 2; // truncate
                        if (Math.Abs(command.x - x) <= dist && Math.Abs(command.y - y) <= dist)
                        {
                            return true;
                        }

                        break;
                }
            }

            return false;
        }

        public bool Solves(PictureDescription desc)
        {
            for (int y = 0; y < desc.NumRows; ++y)
            {
                for (int x = 0; x < desc.NumCols; ++x)
                {
                    if (desc.IsFilled(x, y) != IsFilled(x, y))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Covers(PictureDescription desc)
        {
            for (int y = 0; y < desc.NumRows; ++y)
            {
                for (int x = 0; x < desc.NumCols; ++x)
                {
                    if (desc.IsFilled(x, y) && !IsFilled(x, y))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void AddClearCommands(PictureDescription desc)
        {
            for (int y = 0; y < desc.NumRows; ++y)
            {
                for (int x = 0; x < desc.NumCols; ++x)
                {
                    if (!desc.IsFilled(x, y) && IsFilled(x, y))
                    {
                        AddCommand(MakeClear(x, y));
                    }
                }
            }
        }

        public void WriteToFile(string path)
        {
            using (var stream = File.OpenWrite(path))
            {
                using (var writer = new StreamWriter(stream, Encoding.ASCII))
                {
                    writer.Write(commands.Count);
                    writer.Write("\n");

                    foreach (var command in commands)
                    {
                        switch (command.type)
                        {
                            case CommandType.Square:
                                writer.Write($"PAINT_SQUARE {command.x} {command.y} {command.len / 2}");
                                break;
                            case CommandType.HorizontalLine:
                                writer.Write($"PAINT_LINE {command.x} {command.y} {command.x + command.len - 1} {command.y}");
                                break;
                            case CommandType.VerticalLine:
                                writer.Write($"PAINT_LINE {command.x} {command.y} {command.x} {command.y + command.len - 1}");
                                break;
                            case CommandType.Clear:
                                writer.Write($"ERASE_CELL {command.x} {command.y}");
                                break;
                        }

                        writer.Write("\n");
                    }
                }
            }
        }
    }
}
