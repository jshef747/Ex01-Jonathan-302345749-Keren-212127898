using System;

namespace Ex01_01
{
    class BinaryNumber
    {
        private const int k_LenOfBinaryNumber = 7;

        private int m_BinaryNum;
        private int m_BinaryNumInDecimal = 0;

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
            string strBinaryNumber = Console.ReadLine();
            while(!checkStrBinaryNumInput(strBinaryNumber))
            {
                strBinaryNumber = Console.ReadLine();
            }

            m_BinaryNum = int.Parse(strBinaryNumber);

            for(int i = 0; i < k_LenOfBinaryNumber; i++)
            {
                if(strBinaryNumber[i] != 0)
                {
                    m_BinaryNumInDecimal += (int)Math.Pow(2, i);
                }
            }
        }

        public int GetBinaryNumInDecimal()
        {
            return m_BinaryNumInDecimal;
        }
    }
}
