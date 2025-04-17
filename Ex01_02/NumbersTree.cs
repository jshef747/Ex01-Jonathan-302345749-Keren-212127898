using System;

namespace Ex01_02
{
    public class NumbersTree
    {
        const int k_StartingLetter = 'A';
        const int k_StartingNumber = 1;
        const int k_LengthOfBark = 2;
        const int k_MaxNumberToPrint = 9;

        public static void PrintNumberTree(int i_TreeHeight)
        {
            if(i_TreeHeight < 0)
            {
                return;
            }
            printNumberTreeHelper(i_TreeHeight ,k_StartingNumber, k_StartingNumber);
        }
        private static void printNumberTreeHelper(int i_TreeHeight, int i_CurrentLevel, int i_CurrentNumber)
        {
            //base case
            if (i_CurrentLevel > i_TreeHeight)
            {
                return;
            }
            
            System.Text.StringBuilder textToPrint = new System.Text.StringBuilder();

            char currentLevelLetter = (char)(k_StartingLetter + i_CurrentLevel-1);
            textToPrint.Append($"{currentLevelLetter}  ");
            

            //bark
            if (i_CurrentLevel >= i_TreeHeight-1)
            {
                appendBarkLevel(i_TreeHeight, i_CurrentNumber, ref textToPrint);
            }
            else
            {
                appendNumberLevel(i_TreeHeight, ref i_CurrentNumber, i_CurrentLevel, ref textToPrint);
            }

            Console.WriteLine(textToPrint);

            printNumberTreeHelper(i_TreeHeight, i_CurrentLevel+1, i_CurrentNumber);
        }

        private static void appendBarkLevel(int i_TreeHeight, int i_Number, ref System.Text.StringBuilder i_Txt) 
        {
            int numberOfSpacesToPrint = i_TreeHeight - k_LengthOfBark - 1;
            i_Txt.Append(' ', numberOfSpacesToPrint * 2);
            i_Txt.Append($"|{i_Number}|");
        }

        private static void appendNumberLevel(int i_TreeHeight, ref int i_Number, int i_CurrentLevel, ref System.Text.StringBuilder i_Txt)
        {
            int numberOfSpacesToPrint = i_TreeHeight - k_LengthOfBark - i_CurrentLevel;
            i_Txt.Append(' ', numberOfSpacesToPrint * 2);

            int levelTextLength = i_CurrentLevel * 2 - 1;
            for (int j = 1; j <= levelTextLength; j++)
            {
                i_Txt.Append($" {i_Number}");
                i_Number++;
                if (i_Number == k_MaxNumberToPrint + 1)
                {
                    i_Number = k_StartingNumber;
                }
            }
        }
    }
}
