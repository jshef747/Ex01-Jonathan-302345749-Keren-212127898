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
            int largestDigit = 0;
            int tempNumber = Math.Abs(m_Number);
            for(int digitToCheck = 0; digitToCheck < k_NumberLength; digitToCheck++)
            {
                int currentDigit = tempNumber % 10;
                if(currentDigit > largestDigit)
                {
                    largestDigit = currentDigit;
                }
                tempNumber /= 10;
            }
            return largestDigit;
        }
        
        private int getSmallestDigit()
        {
            int smallestDigit = 10;
            int tempNumber = Math.Abs(m_Number);
            for(int digitToCheck = 0; digitToCheck < k_NumberLength; digitToCheck++)
            {
                int currentDigit = tempNumber % 10;
                if(currentDigit < smallestDigit)
                {
                    smallestDigit = currentDigit;
                }
                tempNumber /= 10;
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
            int dividedBy3WithoutRemainder = 0;
            int tempNumber = Math.Abs(m_Number);
            for(int digitToCheck = 0; digitToCheck < k_NumberLength; digitToCheck++)
            {
                
                int currentDigit = tempNumber % 10;
                if(currentDigit < dividedBy3WithoutRemainder)
                {
                    dividedBy3WithoutRemainder++;
                }
                tempNumber /= 10;
            }
            return dividedBy3WithoutRemainder;
        }

        private int differenceBetweenLargestAndSmallestDigit()
        {
            return getLargestDigit() - getSmallestDigit();
        }
        
        private int getTheDigitThatAppearsTheMostAndItsNumberOfAppearances(out int i_NumberOfAppearences)
        {
            int maxDigit = 0;
            int maxAppearances = 0;
            int tempNumber = m_Number;

            for (int digitToCheck = 0; digitToCheck < k_NumberLength; digitToCheck++)
            {
                int appearances = 0;
                int numberCopy = tempNumber;

                while (numberCopy > 0)
                {
                    int lastDigit = numberCopy % 10;
                    if (lastDigit == digitToCheck)
                    {
                        appearances++;
                    }
                    numberCopy /= 10;
                }

                if(appearances <= maxAppearances)
                {
                    continue;
                }

                maxAppearances = appearances;
                maxDigit = digitToCheck;
            }

            i_NumberOfAppearences = maxAppearances;
            return maxDigit;
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