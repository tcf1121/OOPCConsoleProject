using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.VarioutData.Items
{
    public enum Part
    {
        머리,
        전신,
        신발,
        무기
    }
    public class Equipment : Item
    {
        private Part part;
        public Part Part { get { return part; } }
        private int ability;
        public int Ability { get { return ability; } }
        public Equipment(string name, Part part, int ability,int probability, int meso) : base(name, description: null, false, true, probability, true, meso)
        {
            this.part = part;
            this.ability = ability;
        }

        public override void Use()
        {
            // 장착
        }
    }
}
