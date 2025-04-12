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

        private int numberOfDigitsSmallerThenTheFirstDigit()
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

        private int numberOfDigitsDividedBy3WithoutRemainder()
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

        private int differenceBetweenLargestAndSmallestDigit()
        {
            return getLargestDigit() - getSmallestDigit();
        }

        private int getTheDigitThatAppearsTheMostAndItsNumberOfAppearances(out int i_NumberOfAppearences)
        {
            int maxNumberOfAppearences = 0;
            int maxDigitThatAppears = m_Number % 10;
            int currentNumberOfAppearences = 0;
            int number = m_Number;
            int numberChecker = m_Number;
            for(int i = 0; i < k_NumberLength; i++)
            {
                int currentDigit = number % 10;
                numberChecker = number;
                for (int j = 0; j < k_NumberLength; j++)
                {
                    if(numberChecker % 10 == currentDigit)
                    {
                        currentNumberOfAppearences++;
                    }
                    numberChecker /= 10;
                }

                if(currentNumberOfAppearences > maxNumberOfAppearences)
                {
                    maxNumberOfAppearences = currentNumberOfAppearences;
                    maxDigitThatAppears = currentDigit;
                }
                number /= 10;
                currentNumberOfAppearences = 0;
            }
            i_NumberOfAppearences = maxNumberOfAppearences;
            return maxDigitThatAppears;
        }

        public void PrintNumberDetails()
        {
            Console.WriteLine(string.Format(@"Number Details:
the left digit: {0} number of digits smaller than it: {1}
number of digits divided by 3 without remainder: {2}
difference between largest and smallest digit: {3}
the digit with the most appearances: {4} with {5} appearances", m_Number / (int) Math.Pow(10, k_NumberLength - 1), numberOfDigitsSmallerThenTheFirstDigit(),numberOfDigitsDividedBy3WithoutRemainder(),differenceBetweenLargestAndSmallestDigit(),getTheDigitThatAppearsTheMostAndItsNumberOfAppearances(out int digitWithMostNumberOfAppearances), digitWithMostNumberOfAppearances));
        }
    }
}