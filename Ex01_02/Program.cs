using System;

namespace Ex01_02
{
    public class Program
    {
        static void Main()
        {
            const int k_TreeHeight = 7;
            PrintNumberTree(k_TreeHeight);
        }

        const int k_StartingLetterForTree = 'A';
        const int k_StartingNumberForTree = 1;
        const int k_LengthOfBark = 2;
        const int k_MaxNumberToPrint = 9;

        public static void PrintNumberTree(int i_TreeHeight)
        {
            if (i_TreeHeight < 0)
            {
                return;
            }

            printNumberTreeHelper(i_TreeHeight, k_StartingNumberForTree, k_StartingNumberForTree);
        }

        private static void printNumberTreeHelper(int i_TreeHeight, int i_CurrentLevel, int i_CurrentNumber)
        {
            //base case
            if (i_CurrentLevel > i_TreeHeight)
            {
                return;
            }

            System.Text.StringBuilder textToPrint = new System.Text.StringBuilder();

            char currentLevelLetter = (char)(k_StartingLetterForTree + i_CurrentLevel - 1);
            textToPrint.Append(string.Format("{0}  ", currentLevelLetter));

            //bark
            if (i_CurrentLevel >= i_TreeHeight - 1)
            {
                appendBarkLevel(i_TreeHeight, i_CurrentNumber, ref textToPrint);
            }
            else
            {
                appendNumberLevel(i_TreeHeight, ref i_CurrentNumber, i_CurrentLevel, ref textToPrint);
            }

            Console.WriteLine(textToPrint);

            printNumberTreeHelper(i_TreeHeight, i_CurrentLevel + 1, i_CurrentNumber);
        }

        private static void appendBarkLevel(int i_TreeHeight, int i_CurrentNumber, ref System.Text.StringBuilder io_Text)
        {
            int numberOfSpacesToPrint = i_TreeHeight - k_LengthOfBark - 1;
            io_Text.Append(' ', numberOfSpacesToPrint * 2);
            io_Text.Append(string.Format("|{0}|", i_CurrentNumber));
        }

        private static void appendNumberLevel(int i_TreeHeight, ref int i_CurrentNumber, int i_CurrentLevel, ref System.Text.StringBuilder io_Text)
        {
            int numberOfSpacesToPrint = i_TreeHeight - k_LengthOfBark - i_CurrentLevel;
            io_Text.Append(' ', numberOfSpacesToPrint * 2);
            int levelTextLength = i_CurrentLevel * 2 - 1;

            for (int j = 1; j <= levelTextLength; j++)
            {
                io_Text.Append(string.Format(" {0}", i_CurrentNumber));
                i_CurrentNumber++;

                if (i_CurrentNumber == k_MaxNumberToPrint + 1)
                {
                    i_CurrentNumber = k_StartingNumberForTree;
                }
            }
        }
    }
}
