using OOPCConsoleProject.VarioutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.Scene
{
    public class TitleScene : BaseScene
    {
        int select = 0;
        ConsoleKey input;

        public TitleScene()
        {
            map = new Map("Title", MapType.마을);
        }
        public override void Render()
        {
            Console.WriteLine("┌─────────────────────────┐");
            Console.WriteLine("│                         │");
            Console.WriteLine("│            ♧            │");
            Console.WriteLine("│       *    *    *       │");
            Console.WriteLine("│     ψ 콘솔 메이플 ψ     │");
            Console.WriteLine("│                         │");
            Console.WriteLine("│     * press Enter *     │");
            Console.WriteLine("├─────────────────────────┤");
            Console.WriteLine("│          시작           │");
            Console.WriteLine("├─────────────────────────┤");
            Console.WriteLine("│          종료           │");
            Console.WriteLine("├─────────────────────────┤");
            PrintCursor();
            //Util.PressAnyKey("");
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    select = 0;
                    break;
                case ConsoleKey.DownArrow:
                    select = 1;
                    break;
                case ConsoleKey.Enter:
                    if (select == 0)
                    {
                        Game.ChangeScene("CreationChar");
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                        

            }
        }

        public void PrintCursor()
        {
            if(select == 0)
            {
                Console.SetCursorPosition(7, 8);
                Console.WriteLine("▶");
                Console.SetCursorPosition(7, 10);
                Console.WriteLine(" ");
            }
            else if(select == 1)
            {
                Console.SetCursorPosition(7, 8);
                Console.WriteLine(" ");
                Console.SetCursorPosition(7, 10);
                Console.WriteLine("▶");
            }
        }

        public override void Update()
        {
            
        }

        public override void Result()
        {
            //Game.ChangeScene("Town");
        }
    }
}
