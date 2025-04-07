using OOPCConsoleProject.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.Scene
{
    public class ForestFieldScene : FieldScene
    {
        private ConsoleKey input;
        public ForestFieldScene()
        {
            name = "ForestField";
            mapData = new string[]
            {
                "########",
                "#   #  #",
                "#   #  #",
                "#  ##  #",
                "#      #",
                "########"
            };

            map = new bool[6, 8];
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    map[y, x] = mapData[y][x] == '#' ? false : true;
                }
            }
            gameObjects = new List<GameObject>();
            gameObjects.Add(new Place("NormalField", 'N', new Vector2(1, 1)));
        }

        public override void Enter()
        {
            if (Game.prevSceneName == "NormalField")
                Game.Player.position = new Vector2(1, 1);
            Game.Player.map = map;
        }
    }
}
