using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.Scene
{
    public class TitleScene : BaseScene
    {
        public override void Render()
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("*           레전드 RPG            *");
            Console.WriteLine("***********************************");
            Util.PressAnyKey("");
        }

        public override void Input()
        {
            Console.ReadKey(true);
        }

        public override void Update()
        {
            
        }

        public override void Result()
        {
            Game.ChangeScene("Town");
        }
    }
}
