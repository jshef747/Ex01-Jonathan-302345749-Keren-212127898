using System;

namespace Ex01_02
{
    public class NumbersTree
    {
        const int STARTING_LETTER = 'A';
        const int STARTING_NUMBER = 1;
        const int LENGTH_OF_BARK = 2;
        const int MAX_NUMBER_TO_PRINT = 10;
        public static void PrintNumberTree(int i_treeHeight)
        {
            if(i_treeHeight < 0)
            {
                return;
            }
            PrintNumberTreeHelper(i_treeHeight ,STARTING_NUMBER, STARTING_NUMBER);
        }
        private static void PrintNumberTreeHelper(int i_treeHeight, int i_currentLevel, int i_currentNumber)
        {
            //finished with the tree
            if (i_currentLevel > i_treeHeight)
            {
                return;
            }
            
            System.Text.StringBuilder textToPrint = new System.Text.StringBuilder();

            char currentLevelLetter = (char)(STARTING_LETTER + i_currentLevel-1);
            textToPrint.Append($"{currentLevelLetter}  ");
            

            //bark
            if (i_currentLevel == i_treeHeight || i_currentLevel == i_treeHeight - 1)
            {
                int numberOfSpacesToPrint = i_treeHeight - LENGTH_OF_BARK - 1;
                textToPrint.Append(' ', numberOfSpacesToPrint * 2);
                textToPrint.Append($"|{i_currentNumber}|");
            }
            else
            {
                int numberOfSpacesToPrint = i_treeHeight - LENGTH_OF_BARK - i_currentLevel;
                textToPrint.Append(' ', numberOfSpacesToPrint * 2);

                int levelTextLength = i_currentLevel * 2 - 1;
                for (int j = 1; j <= levelTextLength; j++)
                {
                    textToPrint.Append($" {i_currentNumber}");
                    i_currentNumber++;
                    if(i_currentNumber == MAX_NUMBER_TO_PRINT)
                    {
                        i_currentNumber = 1;
                    }
                }
            }

            Console.WriteLine(textToPrint);

            PrintNumberTreeHelper(i_treeHeight, i_currentLevel+1, i_currentNumber);
        }
    }
}
