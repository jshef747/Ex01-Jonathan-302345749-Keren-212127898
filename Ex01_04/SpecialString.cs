using System;
using System.Linq;

namespace Ex01_04
{
    class SpecialString
    {
        private static string m_SpecialString;
        const int k_StringLength = 12;
        const int k_NumberToCheckDivision = 3;

        public static void GetStrFromUser()
        {
            Console.WriteLine(string.Format("Enter a string with exactly {0} characters:", k_StringLength));
            string i_StrToCheck = Console.ReadLine();
            while (i_StrToCheck.Length != k_StringLength)
            {
                Console.WriteLine("Input must be exactly 12 characters long. Try again:");
                i_StrToCheck = Console.ReadLine();
            }
            m_SpecialString = i_StrToCheck;
        }

        public static bool IsPalindrome()
        {
            return isPalindromeHelper(m_SpecialString.ToLower());
        }

        private static bool isPalindromeHelper(string i_StrToCheck)
        {
            bool returnValue = true;
            if (i_StrToCheck.Length != 0) // base case is when we get to zero lengthed string
            {
                int lastCharIndex = i_StrToCheck.Length - 1;
                if (i_StrToCheck[0] == i_StrToCheck[lastCharIndex])
                {
                    if (lastCharIndex == 1) // got to middle of string
                    {
                        Console.WriteLine("String is a palindrome!");
                        returnValue = true;
                    }
                    else //continue getting to the middle
                    {
                        string shorterString = i_StrToCheck.Substring(1, i_StrToCheck.Length - 2);
                        returnValue = isPalindromeHelper(shorterString);
                    }
                }
                else //not palindrome
                {
                    Console.WriteLine("String is not a palindrome.");
                    returnValue = false;
                }
            }
            return returnValue;
        }

        public static bool IsDividedBy()
        {
            bool returnValue = true;
            long specialStrInt;
            if (!long.TryParse(m_SpecialString, out specialStrInt))   // not a number
            {
                Console.WriteLine("String is not a number.");
                returnValue = false;
            }
            else // a number
            {
                if (specialStrInt % k_NumberToCheckDivision != 0) // not divided by
                {
                    Console.WriteLine(string.Format("String is not divided by {0}.", k_NumberToCheckDivision));
                    returnValue = false;
                }
            }
            if (returnValue)
            {
                Console.WriteLine(string.Format("String is divided by {0}.", k_NumberToCheckDivision));
            }
            return returnValue;
        }

        public static bool IsStringBuiltOfABC()
        {
            bool returnValue = true;
            if (!m_SpecialString.All(c => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))) // string is not built out of english letters only
            {
                Console.WriteLine("String isn't built out of english letters only.");
                returnValue = false;
            }
            else //string is built out of english letters only
            {
                // check uppercase
                int amountUppercaseLetters = m_SpecialString.Count(char.IsUpper);
                Console.WriteLine(string.Format("There are {0} uppercase letters in string.", amountUppercaseLetters));

                string lowerCaseString = m_SpecialString.ToLower();

                for (int i = 0; i < lowerCaseString.Length - 1 && returnValue; i++)
                {
                    if (lowerCaseString[i] > lowerCaseString[i + 1])
                    {
                        Console.WriteLine("String isn't built in alphabetical order.");
                        returnValue = false;
                    }
                }
                if (returnValue)
                {
                    Console.WriteLine("String is built in alphabetical order!");
                }
            }

            return returnValue;
        }
    }
}
