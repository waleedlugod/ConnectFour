using System;

namespace ConnectFour
{
    public static class Board
    {
        private static Tokens tokens = new Tokens();
        public static Tokens Tokens => tokens;


        public static void Draw()
        {
            for (int y = Tokens.MAX_HEIGHT; y >= Tokens.MIN_HEIGHT; y--)
            {
                for (int x = Tokens.MIN_WIDTH; x <= Tokens.MAX_WIDTH; x++)
                {
                    if (Tokens[x, y] is TokenState.Empty)
                    {
                        Console.Write(". ");
                    }
                    else
                    {
                        Console.Write(Tokens[x, y] + " ");
                    }
                }
                Console.WriteLine();
            }
            
            for (int i = 1; i <= Tokens.MAX_WIDTH; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static bool DropToken(TokenState state, int x)
        {
            for (int y = Tokens.MIN_HEIGHT; y <= Tokens.MAX_HEIGHT; y++)
            {
                if (tokens[x, y] == TokenState.Empty)
                {
                    tokens[x, y] = state;
                    return true;
                }
            }
            return false;
        }

        public static bool IsFull()
        {
            for (int x = Tokens.MIN_WIDTH; x <= Tokens.MAX_WIDTH; x++)
            {
                if (Tokens[x, Tokens.MAX_HEIGHT] == TokenState.Empty)
                    return false;
            }
            return true;
        }

        public static bool IsWin()
        {
            for (int x = Tokens.MIN_WIDTH; x <= Tokens.MAX_WIDTH; x++)
            {
                for (int y = Tokens.MIN_HEIGHT; y <= Tokens.MAX_HEIGHT; y++)
                {
                    if (tokens[x, y] != TokenState.Empty)
                    {
                        int longestLineLength = GetLongestLineLength(x, y);

                        if (longestLineLength >= 4)
                            return true;
                    }
                }
            }

            return false;
        }

        public static int LineLength(int x, int y, int xOffSet, int yOffSet)
        {
            // The token itself counts in the line
            int lineLength = 1;

            if (tokens[x, y] != TokenState.Empty &&
                IsInBounds(x, xOffSet, Tokens.MIN_WIDTH, Tokens.MAX_WIDTH) &&
                IsInBounds(y, yOffSet, Tokens.MIN_WIDTH, Tokens.MAX_HEIGHT) &&
                tokens[x, y] == tokens[x + xOffSet, y + yOffSet])
            {
                return lineLength += LineLength(x + xOffSet, y + yOffSet, xOffSet, yOffSet);
            }

            return lineLength;
        }

        public static int GetLongestLineLength(int x, int y)
        {
            int longestLineLength = 1;

            for (int xOffSet = 0; xOffSet < 2; xOffSet++)
            {
                for (int yOffSet = -1 ; yOffSet < 2; yOffSet++)
                {
                    if (xOffSet != 0 || yOffSet != 0)
                    {
                        int lineLength = LineLength(x, y, xOffSet, yOffSet);

                        if (lineLength > longestLineLength)
                            longestLineLength = lineLength;
                    }
                }
            }
            return longestLineLength;
        }


        static bool IsInBounds(int i, int offSet, int min, int max) => (i + offSet >= min) && (i + offSet <= max);
    }
}