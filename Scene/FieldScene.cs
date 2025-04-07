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

        protected List<GameObject> gameObjects;
        protected string[] mapData;
        protected bool[,] map;

        public override void Render()
        {
            PrintMap();
            foreach(GameObject obj in gameObjects)
            {
                obj.Print();
            }
            Game.Player.Print();

            Console.SetCursorPosition(0, map.GetLength(0)+2);
            Game.Player.inventory.PrintALL();
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            Game.Player.Move(input);
        }

        public override void Result()
        {
            foreach(GameObject go in gameObjects)
            {
                if(Game.Player.position == go.position)
                {
                    go.Interact(Game.Player);
                    if (go.isOnce == true)
                        gameObjects.Remove(go);
                    break;
                }
            }
        }

        private void PrintMap()
        {
            
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("{0}", map[y, x] == true? ' ' : '#');
                }
            }
        }
    }
}
