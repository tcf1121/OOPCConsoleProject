using OOPCConsoleProject.GameObjects;
using OOPCConsoleProject.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPCConsoleProject.VarioutData
{
    public enum MapTile
    {
        빈칸,
        땅,
        잔디,
        풀숲,
        포탈,
        벽,
        지붕,
        파란지붕
    }
    public enum MapType
    {
        마을,
        사냥터
    }

    public class Map(string name, MapType mapType)
    {
        public string Name { get { return name; }}

        public List<Map> nextMap = []; 
        //public List<Map> NextMap { get { return nextMap; } set { nextMap = value; } }
        private List<NPC> npcs = []; 
        public List<NPC> Npcs { get { return npcs; } set { npcs = value; } }
        private List<Monster> monsters = [];
        public List<Monster> Monsters { get { return monsters; } set { monsters = value; } }

        public MapType MapType { get { return mapType; } }
        public List<GameObject> gameObjects = [];
        public int[,]? map;
        public bool[,]? mapInNPC;

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

        public void MapInNPC()
        {
            mapInNPC = new bool[10, 10];
            for(int y = 0; y < 10; y++)
                for (int x = 0; x < 10; x++)
                    mapInNPC[y, x] = false;

            foreach(NPC npc in Npcs)
            {
                mapInNPC[npc.Position.y, npc.Position.x] = true;
            }
        }
        public void PrintMap()
        {

            for (int y = 0; y < map!.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x+1, y+1);
                    Console.BackgroundColor = GetBGColor(new Vector2(x, y));
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
            if (map![position.y, position.x] == (int)MapTile.빈칸)
                return ConsoleColor.Black;
            else if (map[position.y, position.x] == (int)MapTile.땅)
                return ConsoleColor.DarkYellow;
            else if (map[position.y, position.x] == (int)MapTile.잔디)
                return ConsoleColor.Green;
            else if (map[position.y, position.x] == (int)MapTile.풀숲)
                return ConsoleColor.DarkGreen;
            else if (map[position.y, position.x] == (int)MapTile.포탈)
                return ConsoleColor.Cyan;
            else if (map[position.y, position.x] == (int)MapTile.벽)
                return ConsoleColor.Yellow;
            else if (map[position.y, position.x] == (int)MapTile.지붕)
                return ConsoleColor.DarkRed;
            else if (map[position.y, position.x] == (int)MapTile.파란지붕)
                return ConsoleColor.Blue;
            else
                return ConsoleColor.Black;
        }

        public void SetMapTile(string mapname)
        {
            int[,] maptile = new int[10, 10];

            switch (mapname)
            {
                case "버섯마을서쪽입구":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 3, 3, 3, 3, 0, 0, 0 },
                    {0, 3, 3, 2, 1, 1, 2, 3, 3, 0 },
                    {3, 2, 2, 1, 1, 1, 1, 2, 2, 3 },
                    {3, 2, 1, 1, 1, 1, 1, 1, 2, 3 },
                    {3, 2, 1, 1, 1, 1, 1, 1, 4, 3 },
                    {3, 2, 2, 1, 1, 1, 1, 2, 2, 3 },
                    {0, 3, 3, 2, 1, 1, 2, 3, 3, 0 },
                    {0, 0, 0, 3, 3, 3, 3, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "버섯마을I":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 3, 3, 3, 3, 0, 0, 0 },
                    {0, 3, 3, 2, 1, 1, 2, 3, 3, 0 },
                    {3, 2, 2, 1, 1, 1, 1, 2, 2, 3 },
                    {3, 4, 1, 1, 1, 1, 1, 1, 2, 3 },
                    {3, 2, 1, 1, 1, 1, 1, 1, 4, 3 },
                    {3, 2, 2, 1, 1, 1, 1, 2, 2, 3 },
                    {0, 3, 3, 2, 1, 1, 2, 3, 3, 0 },
                    {0, 0, 0, 3, 3, 3, 3, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "버섯마을II":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 3, 3, 6, 6, 6, 0, 0 },
                    {0, 3, 3, 2, 6, 6, 6, 6, 6, 0 },
                    {3, 2, 2, 1, 1, 5, 4, 5, 2, 3 },
                    {3, 4, 1, 1, 1, 1, 1, 1, 2, 3 },
                    {3, 2, 1, 1, 1, 1, 1, 1, 4, 3 },
                    {3, 2, 2, 1, 1, 1, 1, 2, 2, 3 },
                    {0, 3, 3, 2, 1, 1, 2, 3, 3, 0 },
                    {0, 0, 0, 3, 3, 3, 3, 0, 0, 0 },
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
                    {0, 0, 0, 0, 4, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                    };
                    break;
                case "버섯마을동쪽입구":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 3, 2, 2, 1, 4 },
                    {0, 0, 0, 3, 3, 3, 2, 1, 1, 1 },
                    {0, 3, 3, 2, 2, 2, 1, 1, 1, 2 },
                    {3, 2, 2, 2, 2, 1, 1, 1, 2, 2 },
                    {3, 2, 2, 2, 1, 1, 1, 2, 2, 3 },
                    {3, 2, 2, 1, 1, 1, 2, 2, 2, 3 },
                    {3, 2, 1, 1, 1, 2, 2, 2, 2, 3 },
                    {2, 1, 1, 1, 2, 2, 2, 3, 3, 0 },
                    {1, 1, 1, 2, 2, 3, 3, 0, 0, 0 },
                    {4, 1, 2, 2, 2, 3, 0, 0, 0, 0 }
                    };
                    break;
                case "달팽이사냥터I":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 3, 3, 3, 3, 0, 0, 0 },
                    {0, 3, 3, 2, 2, 2, 2, 3, 3, 0 },
                    {3, 2, 2, 2, 3, 3, 3, 2, 2, 3 },
                    {2, 2, 2, 3, 2, 2, 2, 3, 2, 2 },
                    {1, 2, 2, 3, 2, 2, 2, 3, 2, 2 },
                    {1, 1, 2, 2, 3, 2, 2, 3, 2, 2 },
                    {1, 1, 2, 2, 2, 2, 3, 2, 2, 1 },
                    {1, 1, 2, 3, 3, 3, 2, 2, 1, 1 },
                    {4, 1, 1, 2, 2, 2, 2, 1, 1, 4 }
                    };
                    break;
                case "달팽이사냥터II":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 3, 3, 3, 3, 0, 0, 0 },
                    {0, 3, 3, 2, 2, 2, 2, 3, 3, 0 },
                    {3, 2, 2, 2, 3, 3, 3, 2, 2, 3 },
                    {2, 2, 2, 3, 2, 2, 2, 3, 2, 2 },
                    {2, 2, 2, 3, 2, 2, 2, 3, 2, 2 },
                    {2, 2, 2, 2, 3, 2, 2, 3, 2, 2 },
                    {2, 2, 3, 2, 2, 2, 3, 2, 2, 2 },
                    {1, 2, 2, 3, 3, 3, 2, 2, 2, 1 },
                    {1, 1, 2, 2, 2, 2, 2, 2, 1, 1 },
                    {4, 1, 1, 1, 1, 1, 1, 1, 1, 4 }
                    };
                    break;
                case "달팽이사냥터III":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 3, 3, 3, 3, 0, 0, 4},
                    {0, 3, 3, 2, 2, 2, 2, 3, 3, 1 },
                    {3, 2, 2, 2, 3, 3, 3, 2, 2, 3 },
                    {2, 2, 2, 3, 2, 2, 2, 3, 2, 2 },
                    {2, 2, 2, 3, 2, 2, 2, 3, 2, 2 },
                    {2, 2, 2, 2, 3, 2, 2, 3, 2, 2 },
                    {2, 2, 3, 2, 2, 2, 3, 2, 2, 2 },
                    {1, 2, 2, 3, 3, 3, 2, 2, 2, 1 },
                    {1, 1, 2, 2, 2, 2, 2, 2, 1, 1 },
                    {4, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
                    };
                    break;
                case "두갈래길":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 3, 2, 1, 1, 4 },
                    {0, 0, 0, 3, 3, 2, 1, 1, 1, 1 },
                    {3, 3, 3, 2, 2, 1, 1, 1, 1, 2 },
                    {2, 2, 2, 1, 1, 1, 1, 1, 2, 3 },
                    {1, 1, 1, 1, 1, 1, 1, 2, 3, 0 },
                    {1, 1, 1, 1, 1, 1, 1, 2, 3, 0 },
                    {2, 2, 2, 1, 1, 1, 1, 1, 2, 3 },
                    {3, 3, 3, 2, 2, 1, 1, 1, 1, 2 },
                    {0, 0, 0, 3, 3, 2, 1, 1, 1, 1 },
                    {0, 0, 0, 0, 0, 3, 2, 1, 1, 4 }
                    };
                    break;
                case "암허스트서쪽필드":
                    maptile = new int[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 2, 2, 2 },
                    {0, 0, 0, 3, 0, 0, 2, 2, 1, 2 },
                    {0, 0, 3, 2, 2, 2, 2, 1, 1, 2 },
                    {0, 3, 2, 1, 1, 2, 1, 1, 2, 4 },
                    {0, 2, 1, 1, 1, 1, 1, 2, 2, 2 },
                    {3, 2, 1, 1, 1, 1, 1, 2, 2, 1 },
                    {2, 1, 1, 1, 1, 1, 2, 2, 3, 0 },
                    {2, 2, 2, 2, 2, 2, 2, 3, 0, 0 },
                    {2, 2, 3, 0, 2, 3, 2, 3, 0, 0 },
                    {4, 3, 0, 0, 0, 0, 3, 0, 0, 0 }
                    };
                    break;
                case "암허스트":
                    maptile = new int[10, 10]
                    {
                    {0, 6, 6, 6, 0, 0, 6, 6, 6, 0 },
                    {6, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                    {3, 5, 4, 5, 2, 2, 5, 4, 5, 3 },
                    {2, 2, 1, 2, 2, 2, 2, 1, 2, 2 },
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                    {4, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                    {3, 2, 1, 1, 1, 1, 1, 1, 1, 1 },
                    {3, 3, 2, 2, 2, 2, 2, 2, 1, 4 }
                    };
                    break;
                case "암허스트동쪽필드":
                    maptile = new int[10, 10]
                    {
                    {4, 2, 2, 2, 3, 0, 0, 0, 0, 0 },
                    {2, 2, 2, 2, 3, 3, 3, 0, 0, 0 },
                    {2, 2, 2, 2, 2, 2, 2, 3, 3, 0 },
                    {2, 2, 2, 2, 1, 1, 2, 2, 2, 3 },
                    {2, 2, 2, 1, 1, 1, 1, 2, 2, 3 },
                    {2, 2, 1, 1, 1, 1, 1, 1, 2, 3 },
                    {2, 2, 1, 1, 1, 1, 1, 1, 2, 3 },
                    {2, 2, 2, 1, 1, 1, 1, 2, 2, 3 },
                    {3, 2, 2, 1, 1, 1, 1, 2, 2, 3 },
                    {0, 3, 2, 2, 2, 2, 2, 2, 3, 0 }
                    };
                    break;
                case "사우스페리서쪽필드":
                    maptile = new int[10, 10]
                    {
                    {4, 3, 0, 0, 0, 0, 3, 0, 0, 0 },
                    {2, 2, 3, 0, 2, 3, 2, 3, 0, 0 },
                    {2, 2, 2, 2, 2, 2, 2, 3, 0, 0 },
                    {2, 1, 1, 1, 1, 1, 2, 2, 3, 0 },
                    {3, 2, 1, 1, 1, 1, 1, 2, 2, 1 },
                    {0, 2, 1, 1, 1, 1, 1, 2, 2, 2 },
                    {0, 3, 2, 1, 1, 2, 1, 1, 2, 4 },
                    {0, 0, 3, 2, 2, 2, 2, 1, 1, 2 },
                    {0, 0, 0, 3, 0, 0, 2, 2, 1, 2 },
                    {0, 0, 0, 0, 0, 0, 0, 2, 2, 2 }
                    };
                    break;
                case "사우스페리":
                    maptile = new int[10, 10]
                    {
                    {0, 7, 7, 7, 0, 0, 7, 7, 7, 0 },
                    {0, 7, 7, 7, 0, 0, 7, 7, 7, 0 },
                    {3, 5, 4, 5, 2, 2, 5, 4, 5, 3 },
                    {2, 2, 1, 2, 2, 2, 2, 1, 2, 2 },
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                    {4, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                    {3, 2, 1, 1, 1, 1, 1, 1, 2, 2 },
                    {3, 3, 2, 2, 2, 2, 2, 2, 2, 2 }
                    };
                    break;
            }

            map = maptile;
        }
    
        public Vector2 SetPlayerPos(string prevScene)
        {
            Vector2 vector2 = new();
            if(name == "버섯마을서쪽입구" && prevScene == "CreationChar")
            {
                vector2 = new Vector2(1, 4);
            }

            else
            {
                foreach (GameObject go in gameObjects)
                    if (go.symbol == '▒')
                    {
                        Place place = (Place)go;
                        if (place.scene == prevScene)
                            vector2 = go.position;
                    }
            }
            return vector2;
        }
    }
}
