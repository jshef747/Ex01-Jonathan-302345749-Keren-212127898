using System;

namespace EX01_03
{
    class DynamicNumberTree
    {
        const int k_MinimumHeight = 4;
        const int k_MaximumHeight = 15;
        public static int GetHeightFromUser()
        {
            Console.WriteLine("Enter a number between {MINIMUM_HEIGHT} and {MAXIMUM_HEIGHT}:");

            int userInputInt;
            while (!int.TryParse(Console.ReadLine(), out userInputInt) || userInputInt < k_MinimumHeight || userInputInt > k_MaximumHeight)
            {
                Console.WriteLine($"Invalid input! Please enter a number between {k_MinimumHeight} and {k_MaximumHeight}:");
            }
            return userInputInt;
        }
    }
}
