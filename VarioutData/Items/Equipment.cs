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
            StringBuilder text = new StringBuilder();
            text.Append($"({(Part)part})");
            switch (part)
            {
                case Part.머리:
                    text.Append("체력");
                    break;
                case Part.전신:
                    text.Append("방어력");
                    break;
                case Part.신발:
                    text.Append("이속");
                    break;
                case Part.무기:
                    text.Append("데미지");
                    break;
            }
            
            text.Append($" +{ability}");
            base.description = text.ToString();
        }

        public override void Use()
        {
            // 장착
        }
    }
}
