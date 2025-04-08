﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.Scene
{
    public abstract class BaseScene
    {
        public Map map;
        public abstract void Render();

        public abstract void Input();

        public abstract void Update();
        public abstract void Result();

        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}
