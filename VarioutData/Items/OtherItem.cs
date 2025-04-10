using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.VarioutData.Items
{
    public class OtherItem : Item
    {
        public OtherItem(string name, string description, int probability, int meso) : base(name, description, true, false, probability, false, meso)
        {
            count = 1;
        }

        public void CountUp()
        {
            count++;
        }

        public void CountDown()
        {
            count--;
        }

        public override void Use()
        {
            //
        }
    }
}
