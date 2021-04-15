using System;

namespace ConnectFour
{
    public static class Prompt
    {
        public static int GetMove(int min, int max)
        {
            int result;
            bool isValid = false;
            do
            {
                Console.WriteLine("Enter which column to drop token:");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out result);
                if (isValid)
                    isValid = (result >= min && result <= max);
            } while (!isValid);

            return result;
        }
    }
}