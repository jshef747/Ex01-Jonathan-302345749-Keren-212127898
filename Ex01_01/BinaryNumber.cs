using System;

namespace Ex01_01
{
    class BinaryNumber
    {
        private const char k_ZeroChar = '0';
        private const char k_OneChar = '1';

        private const int k_LenOfBinaryNumber = 7;
        private int m_BinaryNumInDecimal = 0;
        private int m_LengthOfLongestSeriesOfOnes = 0;
        private int m_NumberOfOnes = 0;
        private int m_NumberOfChangesBetween0And1 = 0;
        private string m_StrBinaryNumber;

        private bool checkStrBinaryNumInput(string i_StrBinaryNumInput)
        {
            bool returnValue = (i_StrBinaryNumInput.Length == k_LenOfBinaryNumber);

            for(int i = 0; i < k_LenOfBinaryNumber && returnValue == true; i++)
            {
                if (i_StrBinaryNumInput[i] != k_ZeroChar && i_StrBinaryNumInput[i] != k_OneChar)
                {
                    returnValue = false;
                }
            }
            return returnValue;
        }

        private void findLongestSeriesOfOne()
        {
            int longestSeriesOfOne = 0;
            int currentSeriesOfOne = 0;
            for(int i = 0; i < k_LenOfBinaryNumber; i++)
            {
                if(m_StrBinaryNumber[i] == k_OneChar)
                {
                    currentSeriesOfOne++;
                    longestSeriesOfOne = Math.Max(longestSeriesOfOne, currentSeriesOfOne);
                }
                else
                {
                    currentSeriesOfOne = 0;
                }

            }
            m_LengthOfLongestSeriesOfOnes = longestSeriesOfOne;
        }

        private void findNumOfChangesBetween0And1()
        {
            for(int i = 1; i < k_LenOfBinaryNumber; i++)
            {
                if(m_StrBinaryNumber[i - 1] != m_StrBinaryNumber[i])
                {
                    m_NumberOfChangesBetween0And1++;
                }
            }
        }

        public void GetBinaryNumberFromUser()
        {
            Console.WriteLine("Please Enter 7 digit binary number:");
            m_StrBinaryNumber = Console.ReadLine();
            while(!checkStrBinaryNumInput(m_StrBinaryNumber))
            {
                Console.WriteLine("Incorrect Input please enter again:");
                m_StrBinaryNumber = Console.ReadLine();
            }

            for (int i = 0; i < k_LenOfBinaryNumber; i++)
            {
                if(m_StrBinaryNumber[i] == k_OneChar)
                {
                    m_NumberOfOnes++;
                    m_BinaryNumInDecimal += (int)Math.Pow(2, k_LenOfBinaryNumber - 1 - i);
                }
            }
            findLongestSeriesOfOne();
            findNumOfChangesBetween0And1();
        }

        public int GetBinaryNumInDecimal()
        {
            return m_BinaryNumInDecimal;
        }

        public string GetBinaryNum()
        {
            return m_StrBinaryNumber;
        }

        public int GetNumberOfOnes()
        {
            return m_NumberOfOnes;
        }

        public int GetLengthOfLongestSeriesOfOnes()
        {
            return m_LengthOfLongestSeriesOfOnes;
        }

        public int GetNumberOfChangesBetween0And1()
        {
            return m_NumberOfChangesBetween0And1;
        }
    }
}
