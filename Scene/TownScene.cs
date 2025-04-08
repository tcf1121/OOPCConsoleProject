using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.Scene
{
    public class TownScene : BaseScene
    {
        ConsoleKey input;
        Map map;
        public TownScene(Map map)
        {
            this.map = map;
            name = map.Name;
        }
        public override void Render()
        {
            Game.Player.PrintInfo(15,0);
            Console.WriteLine("징소 : 초보자의 마을");
            Console.WriteLine("1. 필드로 나간다.");
            Console.WriteLine("어디로 가시겠습니까?");
            
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            
        }

        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    Util.PressAnyKey("필드로 나갑니다.");
                    Game.ChangeScene("NormalField");
                    break;
            }
        }
    }
}
