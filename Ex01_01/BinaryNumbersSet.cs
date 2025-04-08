using System;

namespace Ex01_01
{
    class BinaryNumbersSet
    {
        private const int k_LengthOfSet = 4;
        private BinaryNumber[] m_BinaryNumberArray;

        public BinaryNumbersSet()
        {
            m_BinaryNumberArray = new BinaryNumber[k_LengthOfSet];
            for(int i = 0; i < k_LengthOfSet; i++)
            {
                m_BinaryNumberArray[i] = new BinaryNumber();
                m_BinaryNumberArray[i].GetBinaryNum();
            }
        }

        public int binarySetAverage()
        {
            int sum = 0;
            for(int i = 0; i < k_LengthOfSet; i++)
            {
                sum += m_BinaryNumberArray[i].GetBinaryNumInDecimal();
            }

            return sum / k_LengthOfSet;
        }
    }
}
