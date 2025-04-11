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
                numY %= 5;
            Util.Print(2, 11 + numY, 34, text, delay);
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
                numY %= 5;
            Console.ForegroundColor = color;
            Util.Print(2, 11 + numY, 34, text, delay);
            Console.ResetColor();
        }

        public static void PrintNextText()
        {
            ConsoleKey input;
            Console.SetCursorPosition(24, 16);
            Console.Write("▼");
            //Console.ReadKey(true);
            while (true)
            {
                input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Spacebar)
                    break;
            }
            Cleartext();
        }

        public static void PrintThree(string text1, string text2, string text3)
        {
            Console.SetCursorPosition(4, 16);
            Console.Write(text1);
            Console.SetCursorPosition(11, 16);
            Console.Write(text2);
            Console.SetCursorPosition(19, 16);
            Console.Write(text3);
        }

        // 3개의 선택지에서 쓰는 커서
        public static void selectCursorThree(int chooseNum)
        {
            int x = 2;
            int y = 16;
            Console.SetCursorPosition(x, y);
            Console.Write("  ");
            Console.SetCursorPosition(x + 7, y);
            Console.Write("  ");
            Console.SetCursorPosition(x + 15, y);
            Console.Write("  ");
            switch (chooseNum)
            {
                case 1:
                    Console.SetCursorPosition(x, y);
                    break;
                case 2:
                    Console.SetCursorPosition(x + 7, y);
                    break;
                case 3:
                    Console.SetCursorPosition(x + 15, y);
                    break;
            }
            Console.Write("▶ ");
        }

        public static void PrintOX()
        {
            TextBox.PrintLog(5, "  O   X");
        }

        // O, X에 쓰는 커서
        public static void selectCursorOX(int chooseNum)
        {
            int x = 2;
            int y = 16;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("  ");
            Console.SetCursorPosition(x + 4, y);
            Console.WriteLine("  ");
            switch (chooseNum)
            {
                case 1:
                    Console.SetCursorPosition(x, y);
                    break;
                case 2:
                    Console.SetCursorPosition(x + 4, y);
                    break;
            }
            Console.WriteLine("▶ ");
        }
    }
}
