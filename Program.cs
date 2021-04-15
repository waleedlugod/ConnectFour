using System;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            bool turn = true;
            int column;
            TokenState state;

            do
            {
                Console.Clear();
                Board.Draw();

                Console.WriteLine("Player " + (turn ? 1 : 2));

                do
                {
                    column = Prompt.GetMove(1, 7);
                    state = turn ? TokenState.X : TokenState.O;
                } while (!Board.DropToken(state, column) && !Board.IsFull());
                
                turn = turn ? false : true;
            } while (!Board.IsWin() && !Board.IsFull());
            
            Console.Clear();
            Board.Draw();

            if (Board.IsFull())
            {
                Console.WriteLine("Tie!");
            }
            else
            {
                Console.WriteLine("Player " + (turn ? 2 : 1) + " wins!");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
