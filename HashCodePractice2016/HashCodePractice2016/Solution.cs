using System;
using System.Collections.Generic;
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
    }
}
