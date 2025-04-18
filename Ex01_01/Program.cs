using System;

namespace Ex01_01
{
    class Program
    {
        private static string[] BinaryNumberInStringArray;
        private static int[] BinaryNumbersInDecimalArray = { 0, 0, 0, 0 };
        private static int[] longestSeriesOfOnesPerNumber = { 0, 0, 0, 0 };
        private static int[] numberOfOnesPerNumber = { 0, 0, 0, 0 };
        private static int[] numberOfChangesBetween0And1PerNumber = { 0, 0, 0, 0 };

        private static int getTotalNumberOfOnes()
        {
            int totalNumberOfOnes = 0;
            for (int i = 0; i < 4; i++)
            {
                totalNumberOfOnes += numberOfOnesPerNumber[i];
            }
            return totalNumberOfOnes;
        }

        private static void getNumberOfOnesPerNumber()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (BinaryNumberInStringArray[i][j] == '1')
                    {
                        numberOfOnesPerNumber[i]++;
                    }
                }
            }
        }

        private static void getNumberOfChangesBetween0And1PerNumber()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    if (BinaryNumberInStringArray[i][j - 1] != BinaryNumberInStringArray[i][j])
                    {
                        numberOfChangesBetween0And1PerNumber[i]++;
                    }
                }
            }
        }

        private static void getLongestSeriesOfOnesPerNumber()
        {
            for (int i = 0; i < 4; i++)
            {
                int longestSeriesOfOnes = 0;
                int currentSeriesOfOnes = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (BinaryNumberInStringArray[i][j] == '1')
                    {
                        currentSeriesOfOnes++;
                    }
                    else
                    {
                        longestSeriesOfOnes = Math.Max(longestSeriesOfOnes, currentSeriesOfOnes);
                        currentSeriesOfOnes = 0;
                    }
                }
                longestSeriesOfOnes = Math.Max(longestSeriesOfOnes, currentSeriesOfOnes);
                longestSeriesOfOnesPerNumber[i] = longestSeriesOfOnes;
            }
        }

        private static void convertBinaryToDecimal()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (BinaryNumberInStringArray[i][j] == '1')
                    {
                        BinaryNumbersInDecimalArray[i] += (int)Math.Pow(2, 7 - 1 - j);
                    }
                }
            }
            Array.Sort(BinaryNumbersInDecimalArray);
            Array.Reverse(BinaryNumbersInDecimalArray);
        }

        private static void printDecimalsInDescendingOrder()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write(string.Format("{0} ", BinaryNumbersInDecimalArray[i]));
            }
            Console.WriteLine();
        }

        private static float getAverageFromBinaryArray()
        {
            int sum = 0;
            for (int i = 0; i < 4; i++)
            {
                sum += BinaryNumbersInDecimalArray[i];
            }
            return (float)sum / 4;
        }

        private static bool checkStrBinaryNumInput(string i_StrBinaryNumInput)
        {
            bool returnValue = (i_StrBinaryNumInput.Length == 7);

            for (int i = 0; i < 7 && returnValue == true; i++)
            {
                if (i_StrBinaryNumInput[i] != '0' && i_StrBinaryNumInput[i] != '1')
                {
                    returnValue = false;
                }
            }
            return returnValue;
        }

        private static void getUserInputAndCheckIt()
        {
            BinaryNumberInStringArray = new string[4];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Please Enter 7 digit binary number:");
                string binaryNumberInStringToCheck = Console.ReadLine();
                while (!checkStrBinaryNumInput(binaryNumberInStringToCheck))
                {
                    Console.WriteLine("invalid binary number, please try again:");
                    binaryNumberInStringToCheck = Console.ReadLine();
                }
                BinaryNumberInStringArray[i] = binaryNumberInStringToCheck;
            }
        }

        private static void PrintBinarySetDetails()
        {
            convertBinaryToDecimal();
            printDecimalsInDescendingOrder();

            getNumberOfOnesPerNumber();
            getLongestSeriesOfOnesPerNumber();
            getNumberOfChangesBetween0And1PerNumber();

            float average = getAverageFromBinaryArray();
            int indexWithLongestSeries = 0;
            int indexWithMostOnes = 0;

            for (int i = 1; i < 4; i++)
            {
                if (longestSeriesOfOnesPerNumber[i] > longestSeriesOfOnesPerNumber[indexWithLongestSeries])
                {
                    indexWithLongestSeries = i;
                }
                if (numberOfOnesPerNumber[i] > numberOfOnesPerNumber[indexWithMostOnes])
                {
                    indexWithMostOnes = i;
                }
            }

            Console.WriteLine(
                string.Format(
                    @"the average in decimal is: {0}
the longest series of ones is: {1} from the binary number: {2}",
                    average,
                    longestSeriesOfOnesPerNumber[indexWithLongestSeries],
                    BinaryNumberInStringArray[indexWithLongestSeries]));

            Console.WriteLine("The number of changes between 0 and 1 for each binary number is:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("number of changes: {0} for binary number: {1}",
                    numberOfChangesBetween0And1PerNumber[i],
                    BinaryNumberInStringArray[i]);
            }

            Console.WriteLine(
                string.Format(
                    @"the largest number of ones is: {0} from the binary number: {1}",
                    numberOfOnesPerNumber[indexWithMostOnes],
                    BinaryNumberInStringArray[indexWithMostOnes]));

            Console.WriteLine("the total number of ones in the set is: {0}", getTotalNumberOfOnes());
        }

        public static void Main()
        {
            getUserInputAndCheckIt();
            PrintBinarySetDetails();
        }
    }
}
