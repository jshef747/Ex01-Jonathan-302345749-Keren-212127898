using System;

namespace EX01_03
{
    class DynamicNumberTree
    {
        const int MINIMUM_HEIGHT_FOR_TREE = 4;
        const int MAXIMUM_HEIGHT_FOR_TREE = 15;

        public static int GetHeightFromUser()
        {
            Console.WriteLine(string.Format("Enter a number between {0} and {1}:", MINIMUM_HEIGHT_FOR_TREE, MAXIMUM_HEIGHT_FOR_TREE));

            int userInputInt;
            while (!int.TryParse(Console.ReadLine(), out userInputInt) || userInputInt < MINIMUM_HEIGHT_FOR_TREE || userInputInt > MAXIMUM_HEIGHT_FOR_TREE)
            {
                Console.WriteLine(string.Format("Invalid input! Please enter a number between {0} and {1}:", MINIMUM_HEIGHT_FOR_TREE, MAXIMUM_HEIGHT_FOR_TREE));
            }
            return userInputInt;
        }
    }
}
