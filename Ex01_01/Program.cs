using System;

namespace Ex01_01
{
    class Program
    {
        public static void Main()
        {
             BinaryNumbersSet[] arrayOfBinaryNumbersSet = new BinaryNumbersSet[4];
             for(int i = 0; i < 4; i++)
             {
                 Console.WriteLine("Enter 4 binary numbers of length 7:");
                 arrayOfBinaryNumbersSet[i] = new BinaryNumbersSet();
             }

             for(int i = 0; i < 4; i++)
             {
                 arrayOfBinaryNumbersSet[i].PrintBinarySetDetails();
             }
        }
    }
}
