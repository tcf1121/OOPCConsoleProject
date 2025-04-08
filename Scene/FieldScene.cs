using OOPCConsoleProject.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.Scene
{
    public class FieldScene : BaseScene
    {
        private ConsoleKey input;

        protected ConsoleColor bgColor;
        private bool first = true;

        public FieldScene(Map map)
        {
            this.map = map;
        }

        public override void Render()
        {
            if (first)
            {
                PrintUI();
                Game.Player.PrintInfo(11, 0);
                first = false;
            }
            map.PrintMap();
            Game.Player.Print(map.GetBGColor(Game.Player.position));
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            Game.Player.Action(input);
        }

        public override void Result()
        {
            foreach(GameObject go in map.gameObjects)
            {
                if(Game.Player.position == go.position)
                {
                    go.Interact(Game.Player);
                    if (go.isOnce == true)
                        map.gameObjects.Remove(go);
                    break;
                }
            }
        }

        private void PrintUI()
        {
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

        public override void Enter()
        {
            first = true;
            Game.Player.position = map.SetPlayerPos(Game.prevSceneName);
            Game.Player.map = map.map;
        }
    }
}
