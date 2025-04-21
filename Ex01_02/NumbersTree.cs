using System;

namespace Ex01_02
{
    public class NumbersTree
    {
        const int STARTING_LETTER_FOR_TREE = 'A';
        const int STARTING_NUMBER_FOR_TREE = 1;
        const int LENGTH_OF_BARK = 2;
        const int MAX_NUMBER_TO_PRINT = 9;

        public static void PrintNumberTree(int i_treeHeight)
        {
            if (i_treeHeight < 0)
            {
                return;
            }
            PrintNumberTreeHelper(i_treeHeight, STARTING_NUMBER_FOR_TREE, STARTING_NUMBER_FOR_TREE);
        }
        private static void PrintNumberTreeHelper(int i_treeHeight, int i_currentLevel, int i_currentNumber)
        {
            //base case
            if (i_currentLevel > i_treeHeight)
            {
                return;
            }

            System.Text.StringBuilder textToPrint = new System.Text.StringBuilder();

            char currentLevelLetter = (char)(STARTING_LETTER_FOR_TREE + i_currentLevel - 1);
            textToPrint.Append(string.Format("{0}  ", currentLevelLetter));

            //bark
            if (i_currentLevel >= i_treeHeight - 1)
            {
                AppendBarkLevel(i_treeHeight, i_currentNumber, ref textToPrint);
            }
            else
            {
                AppendNumberLevel(i_treeHeight, ref i_currentNumber, i_currentLevel, ref textToPrint);
            }

            Console.WriteLine(textToPrint);

            PrintNumberTreeHelper(i_treeHeight, i_currentLevel + 1, i_currentNumber);
        }

        private static void AppendBarkLevel(int i_treeHeight, int i_currentNumber, ref System.Text.StringBuilder txt)
        {
            int numberOfSpacesToPrint = i_treeHeight - LENGTH_OF_BARK - 1;
            txt.Append(' ', numberOfSpacesToPrint * 2);
            txt.Append(string.Format("|{0}|", i_currentNumber));
        }

        private static void AppendNumberLevel(int i_treeHeight, ref int i_currentNumber, int i_currentLevel, ref System.Text.StringBuilder txt)
        {
            int numberOfSpacesToPrint = i_treeHeight - LENGTH_OF_BARK - i_currentLevel;
            txt.Append(' ', numberOfSpacesToPrint * 2);

            int levelTextLength = i_currentLevel * 2 - 1;
            for (int j = 1; j <= levelTextLength; j++)
            {
                txt.Append(string.Format(" {0}", i_currentNumber));
                i_currentNumber++;
                if (i_currentNumber == MAX_NUMBER_TO_PRINT + 1)
                {
                    i_currentNumber = STARTING_NUMBER_FOR_TREE;
                }
            }
        }
    }
}
