using OOPCConsoleProject.VarioutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.Scene
{
    public class CreationCharScene : BaseScene
    {
        int select = 0;
        ConsoleKey input;

        public CreationCharScene()
        {
            map = new Map("CreationChar", MapType.마을);
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
            Console.WriteLine("│          입력           │");
            Console.WriteLine("├─────────────────────────┤");
            Console.WriteLine("│          이전           │");
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
                        Console.SetCursorPosition(7, 8);
                        Console.WriteLine("▶             ");
                        Console.SetCursorPosition(11, 8);
                        string name = Console.ReadLine();
                        Game.Player = new Player(name);
                        Game.ChangeScene("버섯마을서쪽입구");
                        break;
                    }
                    else
                    {
                        Game.ChangeScene("Title");
                        break;
                    }


            }
        }

        public void PrintCursor()
        {
            if (select == 0)
            {
                Console.SetCursorPosition(7, 8);
                Console.WriteLine("▶");
                Console.SetCursorPosition(7, 10);
                Console.WriteLine(" ");
            }
            else if (select == 1)
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
