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
        
        public int BinarySetAverage()
        {
            int sum = 0;
            for(int i = 0; i < k_LengthOfSet; i++)
            {
                sum += m_BinaryNumberArray[i].GetBinaryNumInDecimal();
            }

            return sum / k_LengthOfSet;
        }

        public BinaryNumber GetLongestSeriesOfOnes()
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

        public BinaryNumber GetLargestNumOfOnes()
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

        public void PrintDecimalNumbersInDecendingOrder()
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
    }
}