using OOPCConsoleProject.GameObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPCConsoleProject
{
    public enum MapTile
    {
        빈칸,
        땅,
        풀숲,

    }
    public enum MapType
    {
        마을,
        사냥터
    }

    public class Map
    {
        private string name;
        public string Name { get { return name; }}

        public List<Map> nextMap = new List<Map>();
        //public List<Map> NextMap { get { return nextMap; } set { nextMap = value; } }
        private List<NPC> npcs = new List<NPC>();
        public List<NPC> Npcs { get { return npcs; } set { npcs = value; } }
        private List<Monster> monsters = new List<Monster>();
        public List<Monster> Monsters { get { return monsters; } set { monsters = value; } }
        private MapType mapType;
        public MapType MapType { get; set; }
        public List<GameObject> gameObjects = new List<GameObject>();
        public int[,] map;

        public Map(string name, MapType mapType)
        {
            this.name = name;
            this.mapType = mapType;
        }

        

        public static void LinkedMap(Map map1, Map map2)
        {
            map1.nextMap.Add(map2);
            map2.nextMap.Add(map1);
        }

        public void AddGO(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void AddNPC()
        {
            foreach(NPC npc in Npcs)
            {
                gameObjects.Add(new NPCObj(npc));

            }
        }

        public void PrintMap()
        {

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x+1, y+1);
                    if (map[y, x] == (int)MapTile.빈칸)
                        Console.BackgroundColor = ConsoleColor.Black;
                    else if (map[y, x] == (int)MapTile.땅)
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    else if (map[y, x] == (int)MapTile.풀숲)
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" ");
                }
            }
            Console.ResetColor();
            foreach (GameObject obj in gameObjects)
            {
                Console.BackgroundColor = GetBGColor(obj.position);
                obj.Print();
            }

        }

        public ConsoleColor GetBGColor(Vector2 position)
        {
            if (map[position.y, position.x] == (int)MapTile.빈칸)
                return ConsoleColor.Black;
            else if (map[position.y, position.x] == (int)MapTile.땅)
                return ConsoleColor.DarkYellow;
            else if (map[position.y, position.x] == (int)MapTile.풀숲)
                return ConsoleColor.DarkGreen;
            else
                return ConsoleColor.Black;
        }

        public void setMapTile(string mapname)
        {
            int[,] maptile = new int[10, 10];

            switch (mapname)
            {
                case "버섯마을서쪽입구":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "버섯마을I":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 1, 2, 2, 2, 2, 1, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 1, 2, 2, 2, 2, 1, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "버섯마을II":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 1, 2, 2, 2, 2, 1, 0, 0 },
                    {0, 0, 2, 1, 2, 2, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 2, 2, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 2, 2, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 2, 2, 1, 2, 0, 0 },
                    {0, 0, 1, 2, 2, 2, 2, 1, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "버섯마을민가":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                    {0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                    {0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                    {0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "버섯마을동쪽입구":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "달팽이사냥터I":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "달팽이사냥터II":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "달팽이사냥터III":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "두갈래길":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 2, 2 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 2, 2 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 0, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 0, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 1, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 1, 1, 1 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "암허스트서쪽필드":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "암허스트":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "암허스트동쪽필드":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "사우스페리서쪽필드":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "사우스페리":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 1, 1, 1, 1, 2, 0, 0 },
                    {0, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
            }

            this.map = maptile;
        }
    
        public Vector2 SetPlayerPos(string prevScene)
        {
            Vector2 vector2 = new Vector2();
            switch (this.name)
            {
                case "버섯마을서쪽입구":
                    if (prevScene == "CreationChar")
                        vector2 = new Vector2(2, 5);
                    else if(prevScene == "버섯마을I")
                        vector2 = new Vector2(7, 5);
                    break;
                case "버섯마을I":
                    if (prevScene == "버섯마을서쪽입구")
                        vector2 = new Vector2(2, 5);
                    else if (prevScene == "버섯마을II")
                        vector2 = new Vector2(7, 5);
                    break;
                case "버섯마을II":
                    break;
                case "버섯마을민가":
                    break;
                case "버섯마을동쪽입구":
                    break;
                case "달팽이사냥터I":
                    break;
                case "달팽이사냥터II":
                    break;
                case "달팽이사냥터III":
                    break;
                case "두갈래길":
                    break;
                case "암허스트서쪽필드":
                    break;
                case "암허스트":
                    break;
                case "암허스트동쪽필드":
                    break;
                case "사우스페리서쪽필드":
                    break;
                case "사우스페리":
                    break;
            }
            return vector2;
        }
    }
}
