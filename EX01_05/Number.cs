using System;

namespace EX01_05
{
    public class Number
    {
        private const int k_NumberLength = 8;
        private int m_Number;

        public Number()
        {
            Console.WriteLine("Please enter number with 8 digits:");
            string numberStr = Console.ReadLine();
            while(!checkIfInputIsValid(numberStr))
            {
                Console.WriteLine("Invalid input! Please enter number with 8 digits:");
                numberStr = Console.ReadLine();
            }
        }
        
        private bool checkIfInputIsValid(string i_NumberStr)
        {
            bool isValid = int.TryParse(i_NumberStr, out m_Number);
            if (i_NumberStr.Length != k_NumberLength)
            {
                isValid = false;
            }
            return isValid;
        }

        private int getLargestDigit()
        {
            int largestDigit = m_Number / (int) Math.Pow(10, k_NumberLength - 1);
            int dividedNumber = m_Number;
            for(int i = 1; i < k_NumberLength; i++)
            {
                int divideBy = (int) Math.Pow(10, k_NumberLength - i);
                int currentDigit = dividedNumber / divideBy;
                dividedNumber = dividedNumber % divideBy;
                if(currentDigit > largestDigit)
                {
                    largestDigit = currentDigit;
                }
            }
            return largestDigit;
        }
        
        private int getSmallestDigit()
        {
            int smallestDigit = m_Number / (int) Math.Pow(10, k_NumberLength - 1);
            int dividedNumber = m_Number;
            for(int i = 1; i < k_NumberLength; i++)
            {
                int divideBy = (int) Math.Pow(10, k_NumberLength - i);
                int currentDigit = dividedNumber / divideBy;
                dividedNumber = dividedNumber % divideBy;
                if(currentDigit < smallestDigit)
                {
                    smallestDigit = currentDigit;
                }
            }
            return smallestDigit;
        }

        private int NumberOfDigitsSmallerThenTheFirstDigit()
        {
            int smallerThenFirstDigit = 0;
            int firstDigit = m_Number / (int) Math.Pow(10, k_NumberLength - 1);
            int dividedNumber = m_Number;
            for(int i = 1; i < k_NumberLength; i++)
            {
                int divideBy = (int) Math.Pow(10, k_NumberLength - i);
                int currentDigit = dividedNumber / divideBy;
                dividedNumber = dividedNumber % divideBy;
                if(currentDigit < firstDigit)
                {
                    smallerThenFirstDigit++;
                }
            }
            return smallerThenFirstDigit;
        }

        private int NumberOfDigitsDividedBy3WithoutRemainder()
        {
            int dividedBy3 = 0;
            int dividedNumber = m_Number;
            for(int i = 0; i < k_NumberLength; i++)
            {
                int divideBy = (int) Math.Pow(10, k_NumberLength - 1 - i);
                int currentDigit = dividedNumber / divideBy;
                dividedNumber = dividedNumber % divideBy;
                if(currentDigit % 3 == 0)
                {
                    dividedBy3++;
                }
            }
            return dividedBy3;
        }

        private int DifferenceBetweenLargestAndSmallestDigit()
        {
            return getLargestDigit() - getSmallestDigit();
        }

        private int GetTheDigitThatAppearsTheMostAndItsNumberOfAppearances(out int numberOfAppearences)
        {
            int[] digitCount = new int[10];
            int dividedNumber = m_Number;
            for(int i = 0; i < k_NumberLength; i++)
            {
                int divideBy = (int)Math.Pow(10, k_NumberLength - 1 - i);
                int currentDigit = dividedNumber / divideBy;
                dividedNumber = dividedNumber % divideBy;
                digitCount[currentDigit]++;
            }
            int digitWithMostNumberOfAppearances = 0;
            numberOfAppearences = digitCount[digitWithMostNumberOfAppearances];
            for(int i = 1; i < 10; i++)
            {
                int currentAppearances = digitCount[i];
                if(currentAppearances > digitCount[digitWithMostNumberOfAppearances])
                {
                    digitWithMostNumberOfAppearances = i;
                    numberOfAppearences = digitCount[digitWithMostNumberOfAppearances];
                }
            }
            return digitWithMostNumberOfAppearances;
        }

        public void printNumberDetails()
        {
            int digitWithMostNumberOfAppearances;
            Console.WriteLine(string.Format(@"Number Details:
the left digit: {0} number of digits smaller than it: {1}
number of digits divided by 3 without remainder: {2}
difference between largest and smallest digit: {3}
the digit with the most appearances: {4} with {5} appearances", m_Number / (int) Math.Pow(10, k_NumberLength - 1), NumberOfDigitsSmallerThenTheFirstDigit(),NumberOfDigitsDividedBy3WithoutRemainder(),DifferenceBetweenLargestAndSmallestDigit(),GetTheDigitThatAppearsTheMostAndItsNumberOfAppearances(out digitWithMostNumberOfAppearances), digitWithMostNumberOfAppearances));
        }
    }
}