using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirst
{
    public class Goblin : Character
    {
        private List<string> skills;
        private Random random;
        public Goblin() : base("Goblin", 75, 15, 5, 5, false)
        {
            skills = new List<string> { "Slash", "Poison", "Defend" };
            random = new Random();
        }

        public void UseSkill(Character target)
        {
            int skillIndex = random.Next(0, skills.Count);
            string chosenSkill = skills[skillIndex];

            switch (chosenSkill)
            {
                case "Slash":
                    Console.WriteLine("Goblin uses slash.");
                    DealDamage(target, 0 ,"physical");
                    break;
                case "Poison":
                    Console.WriteLine("Goblin uses poison.");
                    target.TakeDamage(2);
                    target.ApplyBuff("armor", -5, 2);
                    break;
                case "Defend":
                    Console.WriteLine("Goblin enters a defensive stance.");
                    ApplyBuff("armor", 20, 2);
                    ApplyBuff("magicResistance", 20, 2);
                    break;
            }
        }
    }
}
