using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace OOPCConsoleProject.Scene
{
    public class BattleScene
    {
        private Monster monster;
        private Map map;
        private Random randmon;
        private Random rand;
        private bool monsterattack;
        private bool success;
        private bool escape;
        private bool monsterdie;
        private bool playerdie;
        private ConsoleKey input;
        public BattleScene(Map map)
        {
            randmon = new Random();
            rand = new Random();
            this.map = map;
            randomMon();
            monster!.Hp = monster.Maxhp;
            monsterdie = false;
            escape = false;
            monster!.OnDie += MonsterDie;
            monster.OnDie += () => Game.Player.getExp(monster.Exp);
            Game.Player.OnDie += PlayerDie;
            Battle();

        }

        public void Battle()
        {
            while(!escape && !monsterdie)
            {
                Render();
                Input();
                Result();                
            }
            Game.Player.PrintInfo(11, 0);
            TextBox.Cleartext();
        }

        public void Choice()
        {
            TextBox.PrintLog(1, "1. 공격");
            TextBox.PrintLog(2, "2. 도망가기");
        }

        public void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public void Render()
        {
            monster.PrintMonterInfo(1, 4);
            Choice();
        }

        public void Result()
        {
            int y = 1;
            switch (input)
            {
                case ConsoleKey.D1:
                    success = rand.Next(1, 10) < 8 ? true : false;
                    if (success)
                    {
                        TextBox.PrintLog(y++, $"공격 : {Game.Player.Power}", ConsoleColor.Blue);
                        monster.Hit(Game.Player.Power);
                    }
                    else
                    {
                        TextBox.PrintLog(y++, "공격 실패", ConsoleColor.DarkRed);
                    }
                    monsterattack = rand.Next(1, 5) < 4 ? true : false;
                    if (!monsterdie)
                    {
                        if (monsterattack)
                        {
                            TextBox.PrintLog(y++, $"피해 : {monster.Power}", ConsoleColor.DarkRed);
                            Game.Player.Hit(monster.Power);
                        }
                        else
                        {
                            TextBox.PrintLog(y++, "방어 성공", ConsoleColor.Blue);
                        }
                    }
                    break;
                case ConsoleKey.D2:
                    success = rand.Next(1, 10) < 4 ? true : false;
                    if (success)
                    {
                        TextBox.PrintLog(y++, "도망 성공", ConsoleColor.Blue);
                        escape = true;
                    }
                    else
                    {
                        TextBox.PrintLog(y++, "도망 실패", ConsoleColor.DarkRed);
                        TextBox.PrintLog(y++, $"피해 : {monster.Power}", ConsoleColor.DarkRed);
                        Game.Player.Hit(monster.Power);
                    }
                    break;
            }
            Wait(y);
        }

        public void Wait(int y)
        {
            TextBox.PrintLog(y, "▶");
            Console.ReadKey(true);
        }

        public void MonsterDie()
        {
            monsterdie = true;
            monster.OnDie -= MonsterDie;

        }

        public void PlayerDie()
        {
            playerdie = true;
            Game.Player.OnDie -= PlayerDie;
        }
        public void randomMon()
        {
            int n = randmon.Next(10);
            switch (map.Monsters.Count)
            {
                case 1:
                    monster = map.Monsters[0];
                    break;
                case 2:
                    if (n < 8)
                        monster = map.Monsters[0];
                    else
                        monster = map.Monsters[1];
                    break;
                case 3:
                    if (n < 6)
                        monster = map.Monsters[0];
                    else if (n < 9)
                        monster = map.Monsters[1];
                    else
                        monster = map.Monsters[2];
                    break;
                case 4:
                    if (n < 5)
                        monster = map.Monsters[0];
                    else if (n < 8)
                        monster = map.Monsters[1];
                    else if (n < 10)
                        monster = map.Monsters[2];
                    else
                        monster = map.Monsters[3];
                    break;
            }
        }
    }
}

