using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirst
{
    public class Skeleton : Character
    {
        private List<string> skills;
        private Random random;
        public Skeleton() :base("Skeleton", 100, 10, 0, 0, false)
        {
            skills = new List<string> { "Slash", "Taunt", "Sharpenblade" };
            random = new Random();
        }
        public void UseSkill(Character target)
        {
            int skillIndex = random.Next(0, skills.Count);
            string chosenSkill = skills[skillIndex];

            switch (chosenSkill)
            {
                case "Slash":
                    Console.WriteLine("Skeleton uses slash.");
                    DealDamage(target, 0, "physical");
                    break;
                case "Taunt":
                    Console.WriteLine("Skeleton hurls insults at you! You feel uneasy. Your damage is lowered");
                    target.TakeDamage(1);
                    target.ApplyBuff("damage", -5, 2);
                    break;
                case "Sharpenblade":
                    Console.WriteLine("Skeleton sharpens his blade.");
                    ApplyBuff("damage", 20, 2);
                    break;
            }
        }
    }
}
