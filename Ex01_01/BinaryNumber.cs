using System;

namespace Ex01_01
{
    class BinaryNumber
    {
        private const int k_LenOfBinaryNumber = 7;

        private int m_BinaryNumInDecimal = 0;
        private int m_LengthOfLongestSeriesOfOnes = 0;
        private int m_NumberOfOnes = 0;
        private int m_NumberOfChnagesBetween0And1 = 0;
        private string m_StrBinaryNumber;

        private bool checkStrBinaryNumInput(string i_StrBinaryNumInput)
        {
            bool returnValue = true;

            if(i_StrBinaryNumInput.Length != k_LenOfBinaryNumber)
            {
                returnValue = false;
            }

            for(int i = 0; i < k_LenOfBinaryNumber && returnValue == true; i++)
            {
                if (i_StrBinaryNumInput[i] != '0' && i_StrBinaryNumInput[i] != '1')
                {
                    returnValue = false;
                }
            }
            return returnValue;
        }


        public BinaryNumber()
        {
            m_StrBinaryNumber = Console.ReadLine();
            while(!checkStrBinaryNumInput(m_StrBinaryNumber))
            {
                m_StrBinaryNumber = Console.ReadLine();
            }

            for(int i = 0; i < k_LenOfBinaryNumber; i++)
            {
                if(m_StrBinaryNumber[i] != 0)
                {
                    m_NumberOfOnes++;
                    m_BinaryNumInDecimal += (int)Math.Pow(2, i);
                }
            }
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
    }
}
