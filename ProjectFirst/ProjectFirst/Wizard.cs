using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirst
{
    public class Wizard : Character
    {

        public Wizard(string name) : base(name, 100, 35, 10, 30, true)
        {
        }

        public void ChannelMagic()
        {
            ApplyBuff("damage", 30, 2);
            ApplyBuff("armor", -5, 2);
            ApplyBuff("magicResist", -5, 2);
        }

        public void HealingMagic()
        {
            base.Heal(10);
        }

        
    }
}
