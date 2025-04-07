﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject
{
    public class Player
    {
        public Vector2 position;
        public Inventory inventory;
        public bool[,] map;

        private int curHP;
        public int CurHP { get { return curHP; } }
        private int maxHP;
        public int MaxHP { get { return maxHP; } }

        public Player()
        {
            inventory = new Inventory();
            maxHP = 100;
            curHP = maxHP;
        }

        public void Heal(int amount)
        {
            curHP += amount;
            if (curHP > maxHP)
                curHP = maxHP;
        }


        public void Print()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("⊙");
            Console.ResetColor();
        }

        public void Move(ConsoleKey input)
        {
            Vector2 targetPos = position;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    targetPos.y--;
                    break;
                case ConsoleKey.DownArrow:
                    targetPos.y++;
                    break;
                case ConsoleKey.LeftArrow:
                    targetPos.x--;
                    break;
                case ConsoleKey.RightArrow:
                    targetPos.x++;
                    break;
            }
            if (map[targetPos.y, targetPos.x] == true)
                position = targetPos;
        }
    }

}
