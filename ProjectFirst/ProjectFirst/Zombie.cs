using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirst
{
    public class Zombie : Character
    {
        private List<string> skills;
        private Random random;
        public Zombie() : base("Zombie", 100, 8, 5, 0, false)
        {
            skills = new List<string> { "Scratch", "Bite", "ConsumeOwnFlesh" };
            random = new Random();
        }
        public void UseSkill(Character target)
        {
            int skillIndex = random.Next(0, skills.Count);
            string chosenSkill = skills[skillIndex];

            switch (chosenSkill)
            {
                case "Scratch":
                    Console.WriteLine("Zombie uses scratch");
                    DealDamage(target, 0, "physical");
                    break;
                case "Bite":
                    Console.WriteLine("Zombie bites you healing in the process");
                    DealDamage(target, 0, "physical");
                    Heal(5);
                    break;
                case "ConsumeOwnFlesh":
                    Console.WriteLine("Zombie consumes his own flesh, healing in the process.");
                    Heal(20);
                    break;
            }
        }
    }
}
