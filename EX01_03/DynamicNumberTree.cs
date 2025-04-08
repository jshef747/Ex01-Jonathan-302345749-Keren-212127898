using System;

namespace EX01_03
{
    class DynamicNumberTree
    {
        const int MINIMUM_HEIGHT = 4;
        const int MAXIMUM_HEIGHT = 15;
        public static int GetHeightFromUser()
        {
            int userInputInt;
            while (!int.TryParse(Console.ReadLine(), out userInputInt) || userInputInt < MINIMUM_HEIGHT || userInputInt > MAXIMUM_HEIGHT)
            {
                Console.WriteLine($"Invalid input! Please enter a number between {MINIMUM_HEIGHT} and {MAXIMUM_HEIGHT}:");
            }
            return userInputInt;
        }
    }
}
