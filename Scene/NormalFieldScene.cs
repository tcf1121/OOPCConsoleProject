﻿using OOPCConsoleProject.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.Scene
{
    public class NormalFieldScene : FieldScene
    {
        public NormalFieldScene()
        {
            name = "NormalField";
            mapData = new string[]
            {
                "########",
                "#   #  #",
                "#   #  #",
                "# # ## #",
                "##     #",
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
            gameObjects.Add(new Place("Town", 'T', new Vector2(1, 1)));
            gameObjects.Add(new Place("ForestField", 'F', new Vector2(6, 1)));
            gameObjects.Add(new Potion(new Vector2(4, 4)));
        }

        public override void Enter()
        {
            if(Game.prevSceneName == "Town")
                Game.Player.position = new Vector2(1, 1);
            else if (Game.prevSceneName == "ForestField")
                Game.Player.position = new Vector2(6, 1);
            Game.Player.map = map;
        }
    }
}
