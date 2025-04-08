using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject
{
    public class TextBox
    {
        private string name;
        private string text;

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
                int length = Encoding.Default.GetByteCount(text);
                int wordLenth = 0;
                int y = 1;
                SetY(y+1);
                foreach (var s in text)
                {
                    if ((int)s > 128)
                        wordLenth += 3;
                    else
                        wordLenth += 1;


                    if ((float)wordLenth / 34 < (float)y)
                        Console.Write(s);
                    else
                    {
                        y++;
                        SetY(y+1);
                        Console.Write(s);
                    }

                }
                Console.ReadKey(true);
            }
            Cleartext();
        }

        public static void SetY(int y)
        {
            Console.SetCursorPosition(2, 11 + y);   
        }

        public static void PrintLog(int x, string text)
        {
            if (x == 1)
                Cleartext();
            Console.SetCursorPosition(2, 11 + x);
            Console.WriteLine(text);
        }
    }
}
