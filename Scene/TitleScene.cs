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
            Console.WriteLine("│          설명           │");
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
                    select--;
                    if (select < 0)
                        select = 0;
                    break;
                case ConsoleKey.DownArrow:
                    select++;
                    if (select > 2)
                        select = 2;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (select == 0)
                    {
                        Game.ChangeScene("CreationChar");
                        break;
                    }
                    else if(select == 1)
                    {
                        Game.ChangeScene("HowtoPlay");
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
            Console.SetCursorPosition(7, 8);
            Console.WriteLine(" ");
            Console.SetCursorPosition(7, 10);
            Console.WriteLine(" ");
            Console.SetCursorPosition(7, 12);
            Console.WriteLine(" ");
            if (select == 0)
            {
                Console.SetCursorPosition(7, 8);
                Console.WriteLine("▶");
            }
            else if (select == 1)
            {
                Console.SetCursorPosition(7, 10);
                Console.WriteLine("▶");
            }
            else if (select == 2)
            {
                Console.SetCursorPosition(7, 12);
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
