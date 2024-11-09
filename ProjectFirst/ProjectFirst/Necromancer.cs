using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirst
{
    public class Sorcerer : Character
    {
        private List<string> skills;
        private Random random;
        public Sorcerer() : base("Sorcerer", 50, 20, 0, 10, false) 
        {
            skills = new List<string> { "ShadowBall", "Thunder", "SelfBuff"};
            random = new Random();
        }

        public void UseSkill(Character target)
        {
            int skillIndex = random.Next(0, skills.Count);
            string chosenSkill = skills[skillIndex];

            switch (chosenSkill)
            {
                case "ShadowBall":
                    Console.WriteLine("Sorcerer creates a shadow ball throwing it in your direction.");
                    DealDamage(target, 0, "magic");
                    break;
                case "Thunder":
                    Console.WriteLine("Sorcerer throws a thunderbolt.");
                    DealDamage(target, 0, "magic");
                    break;
                case "SelfBuff":
                    Console.WriteLine("Sorcerer buffs himself with magic");
                    ApplyBuff("armor", 20, 2);
                    ApplyBuff("magicResist", 20, 2);
                    ApplyBuff("damage", 20, 2);
                    break;
            }
        }
    }
}
