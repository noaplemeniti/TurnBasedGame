using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirst
{
    public class Thief : Character
    {
        public Thief(string name) : base(name, 125, 50, 5, 5, true)
        {
            
        }

        public void StealthStrike()
        {
            ApplyBuff("damage", 50, 2);
            ApplyBuff("armor", -5, 2);
        }

        public void PatchWounds()
        {
            base.Heal(15);
        }
    }
}
