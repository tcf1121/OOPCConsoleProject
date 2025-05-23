﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.VarioutData.Items
{
    public abstract class Item
    {
        // 이름
        private string name;
        public string Name { get { return name; } }
        // 설명
        protected string? description;
        public string? Description { get { return description; } }

        // 중복 가능 여부
        private bool reduplication;
        public bool Reduplication { get { return reduplication; } }

        // 개수
        protected int count;
        public int Count { get { return count; } set { count = value; } }

        // 사용 가능 여부
        private bool canuse;
        public bool Canuse { get { return canuse; } }

        private bool isEquip;
        public bool IsEquip { get { return isEquip; } }
        // 확률
        private int probability;
        public int Probability { get { return probability; } }

        // 메소
        private int meso;
        public int Meso { get { return meso; } }
        public Item(string name, string description, bool reduplication, bool canuse, int probability, bool isEquip, int meso)
        {
            this.name = name;
            this.description = description;
            this.reduplication = reduplication;
            this.canuse = canuse;
            this.probability = probability;
            this.isEquip = isEquip;
            this.meso = meso;
        }



        public abstract void Use();
    }
}
