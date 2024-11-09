using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirst
{
    public class Warrior : Character
    {
        

        public Warrior(string name) : base(name, 120, 10, 10, 10, true)
        {

        }
        
        public void DrumsOfWar()
        {
            base.Heal(25);
        }

        public void BattleRage()
        {
            base.ApplyBuff("damage", 20, 2);
            base.TakeDamage(10);
        }

        public void IronArmor()
        {
            ApplyBuff("armor", 40, 2);
            ApplyBuff("magicResist", -10, 2);
            ApplyBuff("damage", -10, 2);
        }
        
    }
}
