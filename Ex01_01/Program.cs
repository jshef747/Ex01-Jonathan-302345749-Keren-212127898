using System;

namespace Ex01_01
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter 4 binary numbers of length 7:");
            BinaryNumbersSet binaryNumbersSet = new BinaryNumbersSet();
            Console.WriteLine("The average of the binary numbers in decimal is: " + binaryNumbersSet.BinarySetAverage());  
            binaryNumbersSet.PrintDecimalNumbersInDecendingOrder();
        }
    }
}
