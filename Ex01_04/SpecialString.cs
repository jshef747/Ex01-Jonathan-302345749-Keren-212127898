using System;
using System.Linq;

namespace Ex01_04
{
    class SpecialString
    {
        private static string m_specialString;
        const int STRING_LENGTH = 12;
        const int NUMBER_TO_CHECK_DIVISION = 3;

        public static void GetStrFromUser()
        {
            Console.WriteLine(string.Format("Enter a string with exactly {0} characters:", STRING_LENGTH));
            string strToCheck = Console.ReadLine();
            while (strToCheck.Length != STRING_LENGTH)
            {
                Console.WriteLine("Input must be exactly 12 characters long. Try again:");
                strToCheck = Console.ReadLine();
            }
            m_specialString = strToCheck;
        }

        public static bool IsPalindrome()
        {
            return IsPalindromeHelper(m_specialString.ToLower());
        }

        private static bool IsPalindromeHelper(string strToCheck)
        {
            bool returnValue = true;
            if (strToCheck.Length != 0) // base case is when we get to zero lengthed string
            {
                int lastCharIndex = strToCheck.Length - 1;
                if (strToCheck[0] == strToCheck[lastCharIndex])
                {
                    if (lastCharIndex == 1) // got to middle of string
                    {
                        Console.WriteLine("String is a palindrome!");
                        returnValue = true;
                    }
                    else //continue getting to the middle
                    {
                        string shorterString = strToCheck.Substring(1, strToCheck.Length - 2);
                        returnValue = IsPalindromeHelper(shorterString);
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
            if (!long.TryParse(m_specialString, out specialStrInt))   // not a number
            {
                Console.WriteLine("String is not a number.");
                returnValue = false;
            }
            else // a number
            {
                if (specialStrInt % NUMBER_TO_CHECK_DIVISION != 0) // not divided by
                {
                    Console.WriteLine(string.Format("String is not divided by {0}.", NUMBER_TO_CHECK_DIVISION));
                    returnValue = false;
                }
            }
            if (returnValue)
            {
                Console.WriteLine(string.Format("String is divided by {0}.", NUMBER_TO_CHECK_DIVISION));
            }
            return returnValue;
        }

        public static bool IsStringBuiltOfABC()
        {
            bool returnValue = true;
            if (!m_specialString.All(c => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))) // string is not built out of english letters only
            {
                Console.WriteLine("String isn't built out of english letters only.");
                returnValue = false;
            }
            else //string is built out of english letters only
            {
                // check uppercase
                int amountUppercaseLetters = m_specialString.Count(char.IsUpper);
                Console.WriteLine(string.Format("There are {0} uppercase letters in string.", amountUppercaseLetters));

                string lowerCaseString = m_specialString.ToLower();

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
