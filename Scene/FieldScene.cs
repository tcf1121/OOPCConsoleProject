using OOPCConsoleProject.GameObjects;
using OOPCConsoleProject.UI;
using OOPCConsoleProject.VarioutData;
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
        private Random random;
        private BattleScene battleScene;
        public FieldScene(Map map)
        {
            base.map = map;
        }

        public override void Render()
        {
            Map map = base.map;
            if (first)
            {
                TextBox.PrintUI();
                Game.Player.PrintInfo(11, 0);
                first = false;
                if (map.MapType == MapType.사냥터)
                    random = new Random();
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
            // 움직였을 때
            if(input == ConsoleKey.UpArrow || input == ConsoleKey.DownArrow||
                input == ConsoleKey.LeftArrow || input == ConsoleKey.RightArrow)
                if(Game.Player.position == Game.Player.targetPos)
                    if (map.MapType == MapType.사냥터)
                    {
                        int monster = random.Next(100);
                        if (monster > 85)
                            battleScene = new BattleScene(map);
                    }
                
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
                if(Game.Player.targetPos == go.position && input == ConsoleKey.Spacebar)
                {
                    go.Interact(Game.Player);
                }
            }
        }


        public override void Enter()
        {
            first = true;
            Game.Player.position = map.SetPlayerPos(Game.prevSceneName);
            Game.Player.mapInNPC = map.mapInNPC;
            Game.Player.map = map;
        }
    }
}
