using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.GameObjects
{
    public class Place : GameObject
    {
        private string scene;
        public Place(string scene, Vector2 position) 
            : base(ConsoleColor.DarkBlue, '▒', position, false)
        {
            this.scene = scene;
        }

        public override void Interact(Player player)
        {
            Game.ChangeScene(scene);
        }
    }
}
