using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject
{
    public static class Extension
    {
        
    }

    public static class Util
    {
        public static void PressAnyKey(string text)
        {
            TextBox.PrintLog(1, text);
            TextBox.PrintLog(2, "계속하려면 아무키나 누르세요...");
            Console.ReadKey(true);
        }

        public static void Print(int x, int y, int textSize, string text)
        {
            int wordLenth = 0;
            int line = 1;
            Console.SetCursorPosition(x, y);
            foreach (var s in text)
            {
                if ((int)s > 128)
                    wordLenth += 3;
                else
                    wordLenth += 1;


                if ((float)wordLenth / textSize < (float)line)
                    Console.Write(s);
                else
                {
                    line++;
                    Console.SetCursorPosition(x, y + line - 1);
                    Console.Write(s);
                }

            }
        }
    }
}
