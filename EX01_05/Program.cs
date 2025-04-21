using System;

namespace EX01_05
{
    class Program
    {
        private const int k_NumberLength = 8;
        private static int s_Number;
        private static string s_NumberStr;

        static void Main()
        {
            getUserInput();
            PrintNumberDetails();
        }

        private static void getUserInput()
        {
            Console.WriteLine("Please enter number with 8 digits:");
            s_NumberStr = Console.ReadLine();

            while (!checkIfInputIsValid(s_NumberStr))
            {
                Console.WriteLine("Invalid input! Please enter number with 8 digits:");
                s_NumberStr = Console.ReadLine();
            }
        }

        private static bool checkIfInputIsValid(string i_NumberStr)
        {
            bool isValid = int.TryParse(i_NumberStr, out s_Number);
            if (i_NumberStr.Length != k_NumberLength)
            {
                isValid = false;
            }
            return isValid;
        }

        private static int getLargestDigit()
        {
            int largestDigit = 0;
            int tempNumber = Math.Abs(s_Number);
            for (int digitToCheck = 0; digitToCheck < k_NumberLength; digitToCheck++)
            {
                int currentDigit = tempNumber % 10;
                if (currentDigit > largestDigit)
                {
                    largestDigit = currentDigit;
                }
                tempNumber /= 10;
            }
            return largestDigit;
        }

        private static int getSmallestDigit()
        {
            int smallestDigit = 10;
            int tempNumber = Math.Abs(s_Number);
            for (int digitToCheck = 0; digitToCheck < k_NumberLength; digitToCheck++)
            {
                int currentDigit = tempNumber % 10;
                if (currentDigit < smallestDigit)
                {
                    smallestDigit = currentDigit;
                }
                tempNumber /= 10;
            }
            return smallestDigit;
        }

        private static int numberOfDigitsSmallerThenTheFirstDigit()
        {
            int smallerThenFirstDigit = 0;
            int firstDigit = Math.Abs(s_Number / (int)Math.Pow(10, k_NumberLength - 1));
            int tempNumber = Math.Abs(s_Number);
            for (int digitToCheck = 1; digitToCheck < k_NumberLength; digitToCheck++)
            {
                int currentDigit = tempNumber % 10;
                if (currentDigit < firstDigit)
                {
                    smallerThenFirstDigit++;
                }
                tempNumber /= 10;
            }
            return smallerThenFirstDigit;
        }

        private static int numberOfDigitsDividedBy3WithoutRemainder()
        {
            int dividedBy3WithoutRemainder = 0;
            int tempNumber = Math.Abs(s_Number);
            for (int digitToCheck = 0; digitToCheck < k_NumberLength; digitToCheck++)
            {
                int currentDigit = tempNumber % 10;
                if (currentDigit % 3 == 0)
                {
                    dividedBy3WithoutRemainder++;
                }
                tempNumber /= 10;
            }
            return dividedBy3WithoutRemainder;
        }

        private static int differenceBetweenLargestAndSmallestDigit()
        {
            return getLargestDigit() - getSmallestDigit();
        }

        private static int getTheDigitThatAppearsTheMostAndItsNumberOfAppearances(out int i_NumberOfAppearances)
        {
            char maxChar = s_NumberStr[0];
            int maxAppearances = 0;
            for (int i = 0; i < k_NumberLength; i++)
            {
                int appearances = 0;
                char currentChar = s_NumberStr[i];
                for (int j = 0; j < k_NumberLength; j++)
                {
                    if (currentChar == s_NumberStr[j])
                    {
                        appearances++;
                    }
                }

                if (appearances > maxAppearances)
                {
                    maxAppearances = appearances;
                    maxChar = currentChar;
                }
            }
            i_NumberOfAppearances = maxAppearances;
            return maxChar - '0';
        }

        private static void PrintNumberDetails()
        {
            int digitWithMostNumberOfAppearances;
            int mostFrequentDigit = getTheDigitThatAppearsTheMostAndItsNumberOfAppearances(out digitWithMostNumberOfAppearances);

            Console.WriteLine(string.Format(@"Number Details:
the left digit: {0} number of digits smaller than it: {1}
number of digits divided by 3 without remainder: {2}
difference between largest and smallest digit: {3}
the digit with the most appearances: {4} with {5} appearances",
                s_Number / (int)Math.Pow(10, k_NumberLength - 1),
                numberOfDigitsSmallerThenTheFirstDigit(),
                numberOfDigitsDividedBy3WithoutRemainder(),
                differenceBetweenLargestAndSmallestDigit(),
                mostFrequentDigit,
                digitWithMostNumberOfAppearances));
        }
    }
}
