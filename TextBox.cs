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

        public void Cleartext()
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

        public void NPCDialog(NPC npc)
        {
            Console.SetCursorPosition(2, 12);
            foreach(string text in npc.Speech)
                Console.WriteLine(text);
        }

        public void PrintLog(int x, string text)
        {
            Console.SetCursorPosition(2, 11 + x);
            Console.WriteLine(text);
        }
    }
}
