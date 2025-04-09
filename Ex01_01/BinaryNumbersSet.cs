using System;


namespace Ex01_01
{
    class BinaryNumbersSet
    {
        private const int k_LengthOfSet = 4;
        private BinaryNumber[] m_BinaryNumberArray;
        private int m_NumOfOnes = 0;
        public BinaryNumbersSet()
        {
            m_BinaryNumberArray = new BinaryNumber[k_LengthOfSet];
            for(int i = 0; i < k_LengthOfSet; i++)
            {
                m_BinaryNumberArray[i] = new BinaryNumber();
                m_BinaryNumberArray[i].GetBinaryNumberFromUser();
                m_NumOfOnes += m_BinaryNumberArray[i].GetNumberOfOnes();
            }
        }
        
        private int binarySetAverage()
        {
            int sum = 0;
            for(int i = 0; i < k_LengthOfSet; i++)
            {
                sum += m_BinaryNumberArray[i].GetBinaryNumInDecimal();
            }

            return sum / k_LengthOfSet;
        }

        private BinaryNumber GetLongestSeriesOfOnes()
        {
            int maxIndex = 0;
            int max = m_BinaryNumberArray[0].GetLengthOfLongestSeriesOfOnes();
            int[] arrayOfSeriesOfOnes = new int[k_LengthOfSet];
            for(int i = 0; i < k_LengthOfSet; i++)
            {
                if(m_BinaryNumberArray[i].GetLengthOfLongestSeriesOfOnes() > max)
                {
                    max = m_BinaryNumberArray[i].GetLengthOfLongestSeriesOfOnes();
                    maxIndex = i;
                }
            }

            return m_BinaryNumberArray[maxIndex];
        }

        private BinaryNumber GetLargestNumOfOnes()
        {
            int maxIndex = 0;
            int max = m_BinaryNumberArray[0].GetNumberOfOnes();
            for(int i = 0; i < k_LengthOfSet; i++)
            {
                if(m_BinaryNumberArray[i].GetNumberOfOnes() > max)
                {
                    max = m_BinaryNumberArray[i].GetNumberOfOnes();
                    maxIndex = i;
                }
            }
            return m_BinaryNumberArray[maxIndex];
        }

        private void printDecimalNumbersInDecendingOrder()
        {
            int[] decimalNumbers = new int[k_LengthOfSet];
            for(int i = 0; i < k_LengthOfSet; i++)
            {
                decimalNumbers[i] = m_BinaryNumberArray[i].GetBinaryNumInDecimal();
            }
            Array.Sort(decimalNumbers);
            Array.Reverse(decimalNumbers);
            Console.WriteLine("The decimal numbers in descending order are:");
            for(int i = 0; i < k_LengthOfSet; i++)
            {
                Console.WriteLine(decimalNumbers[i]);
            }
        }
        
        private void printNumberOfChangesForEachBinaryNum()
        {
            Console.WriteLine("The number of changes between 0 and 1 for each binary number is:");
            for(int i = 0; i < k_LengthOfSet; i++)
            {
                Console.WriteLine("number of changes: {0} for binary number: {1}\n", m_BinaryNumberArray[i].GetNumberOfChangesBetween0And1(), m_BinaryNumberArray[i].GetBinaryNum());
            }
        }

        public void PrintBinarySetDetails()
        {
            printDecimalNumbersInDecendingOrder();
            BinaryNumber numWithLongestSeriesOfOnes = GetLongestSeriesOfOnes();
            Console.WriteLine(
                string.Format(
                    @"the average in decimal is: {0}
the longest series of ones is: {1} from the binary number: {2}",
                    binarySetAverage(),
                    numWithLongestSeriesOfOnes.GetLengthOfLongestSeriesOfOnes(),
                    numWithLongestSeriesOfOnes.GetBinaryNum()));
            
            printNumberOfChangesForEachBinaryNum();

            BinaryNumber numWithLargestNumOfOnes = GetLargestNumOfOnes();
            Console.WriteLine(
                string.Format(
                    @"the largest number of ones is: {0} from the binary number: {1}",
                    numWithLargestNumOfOnes.GetNumberOfOnes(),
                    numWithLargestNumOfOnes.GetBinaryNum()));

            Console.WriteLine("the total number of ones in the set is: {0}", m_NumOfOnes);
        }
    }
}