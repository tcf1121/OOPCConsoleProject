using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.UI
{
    public static class Extension
    {
        
    }

    public static class Util
    {
        public static void PressAnyKey(string text)
        {
            TextBox.PrintLog(1, text);
            TextBox.PrintNextText();
        }

        public static void Print(int x, int y, int textSize, string text)
        {
            int wordLenth = 0;
            int line = 1;
            Console.SetCursorPosition(x, y);
            foreach (var s in text)
            {
                if (s > 128)
                    wordLenth += 3;
                else
                    wordLenth += 1;


                if ((float)wordLenth / textSize < line)
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
