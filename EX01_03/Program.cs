using System;
using Ex01_02;

namespace EX01_03
{
    class Program
    {
        static void Main() 
        {
            Ex01_02.Program.PrintNumberTree(GetHeightFromUser());
        }

        const int k_MinimumHeightForTree = 4;
        const int k_MaximumHeightForTree = 15;

        public static int GetHeightFromUser()
        {
            Console.WriteLine(string.Format("Enter a number between {0} and {1}:", k_MinimumHeightForTree, k_MaximumHeightForTree));

            int userInputInt;
            while (!int.TryParse(Console.ReadLine(), out userInputInt) || userInputInt < k_MinimumHeightForTree || userInputInt > k_MaximumHeightForTree)
            {
                Console.WriteLine(string.Format("Invalid input! Please enter a number between {0} and {1}:", k_MinimumHeightForTree, k_MaximumHeightForTree));
            }
            return userInputInt;
        }
    }
}
 