using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ERPRO.Functions.Print
{
    internal partial class table //allowed to extent because partial is stated
    {
        public static void PrintVertical(string[,] ShowProperties)
        {
            //if chars lengt in ShowProperties[?, 0 OR 1] > ShowProperties[?, 2] Edit ShowProperties[?, 2] to match max string width
            for (int i = 0; i < ShowProperties.GetLength(0); i++)
            {
                if (ShowProperties[i, 0].Length > System.Convert.ToInt32(ShowProperties[i, 2]))
                {
                    ShowProperties[i, 2] = (ShowProperties[i, 0].Length).ToString();
                }

                if (ShowProperties[i, 1].Length > System.Convert.ToInt32(ShowProperties[i, 2]))
                {
                    ShowProperties[i, 2] = (ShowProperties[i, 1].Length).ToString();
                }

            }

            //add top line on table
            Console.ForegroundColor = ConsoleColor.Cyan;
            int linelengt = 2;
            for (int i = 0; i < ShowProperties.GetLength(0); i++)
            {
                linelengt = linelengt + System.Convert.ToInt32(ShowProperties[i, 2]) + 3;
            }
            Console.WriteLine("".PadRight(linelengt, '='));
            Console.ForegroundColor = ConsoleColor.White;

            //add keys
            for (int i = 0; i < ShowProperties.GetLength(0); i++)
            {
                Console.Write("| " + ShowProperties[i, 0].PadRight(System.Convert.ToInt32(ShowProperties[i, 2])) + " ");
            }
            Console.WriteLine(" |");

            //add middle line on table
            for (int i = 0; i < ShowProperties.GetLength(0); i++)
            {
                Console.Write("".PadRight(System.Convert.ToInt32(ShowProperties[i, 2]) + 3, '-'));
            }
            Console.WriteLine("--");

            //add values
            for (int i = 0; i < ShowProperties.GetLength(0); i++)
            {
                Console.Write("| " + ShowProperties[i, 1].PadRight(System.Convert.ToInt32(ShowProperties[i, 2])) + " ");
            }
            Console.WriteLine(" |");

            //add bottom line on table
            for (int i = 0; i < ShowProperties.GetLength(0); i++)
            {
                Console.Write("".PadRight(System.Convert.ToInt32(ShowProperties[i, 2]) + 3, '-'));
            }
            Console.WriteLine("--");

            Console.WriteLine(""); //new line before showing list
        }

        public static void PrintHorizontal(string[,] ShowProperties)
        {
            string paddingLeft = "  ";
            int keyLenght = 0;
            int valueLenght = 0;

            //get max lenght for key and for value
            for (int i = 0; i < ShowProperties.GetLength(0); i++)
            {
                if (ShowProperties[i, 0].Length > keyLenght)
                {
                    keyLenght = ShowProperties[i, 0].Length;
                }

                if (ShowProperties[i, 1].Length > valueLenght)
                {
                    valueLenght = ShowProperties[i, 1].Length;
                }

            }

            keyLenght += 1;

            //add top line on table
            Console.Write(paddingLeft); //padding left
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int linelengt = 7 + keyLenght + valueLenght;
            Console.WriteLine("".PadRight(linelengt, '▒'));
            Console.ForegroundColor = ConsoleColor.White;

            //add key
            for (int i = 0; i < ShowProperties.GetLength(0); i++)
            {
                //print line above
                Console.Write(paddingLeft); //padding left
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█".PadRight(3 + keyLenght, '▀') + "▀");
                Console.WriteLine("".PadRight(2 + valueLenght, '▀') + "█");

                //print content
                Console.Write(paddingLeft); //padding left
                Console.Write("▌ ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(ShowProperties[i, 0].PadRight(keyLenght));

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("   ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(ShowProperties[i, 1].PadRight(valueLenght));

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(" ▐");
                Console.ForegroundColor = ConsoleColor.White;

            }

            Console.Write(paddingLeft); //padding left
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("".PadRight((7 + keyLenght + valueLenght), '▀'));
            Console.ForegroundColor = ConsoleColor.White;

        }

        /* old way
        public static void PrintHorizontal(string[,] ShowProperties)
        {
            int keyLenght = 0;
            int valueLenght = 0;

            //get max lenght for key and for value
            for (int i = 0; i < ShowProperties.GetLength(0); i++)
            {
                if (ShowProperties[i, 0].Length > keyLenght)
                {
                    keyLenght = ShowProperties[i, 0].Length;
                }

                if (ShowProperties[i, 1].Length > valueLenght)
                {
                    valueLenght = ShowProperties[i, 1].Length;
                }

            }

            //add top line on table
            Console.ForegroundColor = ConsoleColor.Cyan;
            int linelengt = 8 + keyLenght + valueLenght;
            Console.WriteLine("".PadRight(linelengt, '='));
            Console.ForegroundColor = ConsoleColor.White;

            //add key
            for (int i = 0; i < ShowProperties.GetLength(0); i++)
            {
                Console.Write("| " + ShowProperties[i, 0].PadRight(System.Convert.ToInt32(keyLenght)) + " ");
                Console.Write("| " + ShowProperties[i, 1].PadRight(System.Convert.ToInt32(valueLenght)) + " ");

                Console.WriteLine(" |");
                Console.WriteLine("".PadRight(8 + keyLenght + valueLenght, '-'));
            }

        }
        */

    }
}
