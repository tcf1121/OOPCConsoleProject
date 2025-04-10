using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.VarioutData.Items
{
    public class Potion : Item
    {
        private int heal;
        public Potion(string name, string description, int heal, int probability) : base(name, description, true, true, probability, false)
        {
            this.heal = heal;
            count = 1;
        }

        public override void Use()
        {
            Game.Player.Heal(heal);
        }
    }
}
