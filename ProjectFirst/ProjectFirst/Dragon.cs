using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirst
{
    public class Dragon : Character
    {
        private List<string> skills;
        private Random random;
        public Dragon() : base("Dragon", 200, 20, 15, 15, false) { 
            skills = new List<string> { "Firebreath", "Bite", "Roar", "Claw" };
            random = new Random();
        }
        public void UseSkill(Character target)
        {
            int skillIndex = random.Next(0, skills.Count);
            string chosenSkill = skills[skillIndex];

            switch (chosenSkill)
            {
                case "Firebreath":
                    Console.WriteLine("Dragon uses his fire breath, it damages itself aswell.");
                    DealDamage(target, 0, "magic");
                    TakeDamage(25);
                    break;
                case "Bite":
                    Console.WriteLine("Dragon bites you healing in the process");
                    DealDamage(target, 0, "physical");
                    Heal(5);
                    break;
                case "Roar":
                    Console.WriteLine("Dragon roars healing and lowering your armor.");
                    Heal(10);
                    target.ApplyBuff("armor", -5, 2);
                    break;
                case "Claw":
                    Console.WriteLine("Dragon uses it's claws to scratch you shattering your armor.");
                    target.ApplyBuff("armor", -10, 5);
                    break;
            }
        }

    }
}
