using OOPCConsoleProject.VarioutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.Scene
{
    public class HowtoPlayScene : BaseScene
    {
        int select = 0;
        ConsoleKey input;

        public HowtoPlayScene()
        {
            map = new Map("HowtoPlay", MapType.마을);
        }

        public override void Render()
        {
            Console.WriteLine("┌─────────────────────────┐");
            Console.WriteLine("│      방향키 : 이동      │");
            Console.WriteLine("│       I : 인벤토리      │");
            Console.WriteLine("│       E : 장비창        │");
            Console.WriteLine("│       S : 능력치창      │");
            Console.WriteLine("│      SpaceBar : 선택    │");
            Console.WriteLine("│     준비 됐으면 시작!   │");
            Console.WriteLine("├─────────────────────────┤");
            Console.WriteLine("│          시작           │");
            Console.WriteLine("├─────────────────────────┤");
            Console.WriteLine("│          뒤로           │");
            Console.WriteLine("├─────────────────────────┤");
            Console.WriteLine("│                         │");
            Console.WriteLine("│                         │");
            PrintCursor();
            //Util.PressAnyKey("");
        }

        public void PrintCursor()
        {
            Console.SetCursorPosition(7, 8);
            Console.WriteLine(" ");
            Console.SetCursorPosition(7, 10);
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
                case ConsoleKey.Spacebar:
                    if (select == 0)
                    {
                        Game.ChangeScene("CreationChar");
                        break;
                    }
                    else
                    {
                        Game.ChangeScene("Title");
                        break;
                    }
            }
        }

        public override void Update()
        {

        }

        public override void Result()
        {
            
        }
    }
}
