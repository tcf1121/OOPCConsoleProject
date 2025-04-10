using OOPCConsoleProject.VarioutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPCConsoleProject.UI
{
    public class TextBox
    {
        private string name;
        private string text;

        public static void PrintUI()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("┌──────────┐");
            Console.WriteLine("│          │");
            Console.WriteLine("│          │");
            Console.WriteLine("│          │");
            Console.WriteLine("│          │");
            Console.WriteLine("│          │");
            Console.WriteLine("│          │");
            Console.WriteLine("│          │");
            Console.WriteLine("│          │");
            Console.WriteLine("│          │");
            Console.WriteLine("│          │");
            Console.WriteLine("├─────────────────────────┤");
        }

        public TextBox()
        {
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("├─────────────────────────┤");
            Console.WriteLine("│                         │");
            Console.WriteLine("│                         │");
            Console.WriteLine("│                         │");
            Console.WriteLine("│                         │");
            Console.WriteLine("│                         │");
            Console.WriteLine("└─────────────────────────┘");
        }

        public static void Cleartext()
        {
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("├──────────┴──────────────┤");
            Console.WriteLine("│                         │");
            Console.WriteLine("│                         │");
            Console.WriteLine("│                         │");
            Console.WriteLine("│                         │");
            Console.WriteLine("│                         │");
            Console.WriteLine("└─────────────────────────┘");
        }

        public static void NPCDialog(NPC npc)
        {
            PrintLog(1, npc.Name);
            Console.SetCursorPosition(2, 13);
            foreach(string text in npc.Speech)
            {
                Util.Print(2, 13, 34, text, 50);
                PrintNextText();
            }
        }

        public static void SetY(int y)
        {
            Console.SetCursorPosition(2, 11 + y);   
        }

        public static void PrintLog(int y, string text, int delay = 0)
        {
            int numY = y;
            if (y == 1)
                Cleartext();
            else if (y % 5 == 1)
                PrintNextText();

            if (y % 5 == 0)
                numY = 5;
            else
                numY = numY % 5;
            Util.Print(2, 11 + y % 5, 34, text, delay);
        }

        public static void PrintLog(int y, string text, ConsoleColor color, int delay = 0)
        {        
            int numY = y;
            if (y == 1)
                Cleartext();
            else if (y % 5 == 1)
                PrintNextText();

            if (y % 5 == 0)
                numY = 5;
            else
                numY = numY % 5;
            Console.ForegroundColor = color;
            Util.Print(2, 11 + y % 5, 34, text, delay);
            Console.ResetColor();
        }

        public static void PrintNextText()
        {
            Console.SetCursorPosition(24, 16);
            Console.Write("▼");
            Console.ReadKey(true);
            Cleartext();
        }
    }
}
