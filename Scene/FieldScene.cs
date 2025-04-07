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
        private List<GameObject> gameObjects;
        private ConsoleKey input;
        private string[] mapData;
        private bool[,] map;

        public FieldScene()
        {
            mapData = new string[]
            {
                "########",
                "#      #",
                "#      #",
                "#      #",
                "#      #",
                "########"
            };

            map = new bool[6, 8];
            for(int y = 0; y < 6; y++)
            {
                for(int x = 0; x < 8; x++)
                {
                    map[y, x] = mapData[y][x] == '#' ? false : true;
                }
            }
            gameObjects = new List<GameObject>();
            gameObjects.Add(new Place("Town", 'T', new Vector2(1, 1)));
            Game.Player.position = new Vector2(2, 1);
            Game.Player.map = map;
        }
        public override void Render()
        {
            PrintMap();
            Game.Player.Print();
            foreach(GameObject obj in gameObjects)
            {
                obj.Print();
            }
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
