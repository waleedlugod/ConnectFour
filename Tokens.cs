using System;
using System.Collections.Generic;

namespace ConnectFour
{
    public enum TokenState
    {
        Empty,
        X,
        O
    }
    interface ITokens
    {
    }

    public class Tokens : ITokens
    {
        public const int MAX_WIDTH = 7;
        public const int MIN_WIDTH = 1;
        public const int MAX_HEIGHT = 6;
        public const Int16 MIN_HEIGHT = 1;
        TokenState[,] tokens = new TokenState[MAX_WIDTH + 1, MAX_HEIGHT + 1];

        public TokenState this[int x, int y]
        {
            get {return tokens[x, y];}
            set {tokens[x, y] = value;}
        }
    }
}