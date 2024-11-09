using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirst
{
    public class Game
    {
        public static bool Battle(Character enemy, Character player)
        {
            while (player.GetHp() > 0 && enemy.GetHp() > 0)
            {
                Console.WriteLine("\n--- Turn Start ---");
                Character.DisplayCharacterStats(player);
                Character.DisplayCharacterStats(enemy);

                // Player turn
                if (player is Warrior warrior)
                {
                    PerformWarriorAction(warrior, enemy);
                }
                else if (player is Wizard wizard)
                {
                    PerformWizardAction(wizard, enemy);
                }
                else if (player is Thief thief)
                {
                    PerformThiefAction(thief, enemy);
                }

                // Enemy turn
                if (enemy.GetHp() > 0)
                {
                    if (enemy is Sorcerer sorcerer) sorcerer.UseSkill(player);
                    else if (enemy is Goblin goblin) goblin.UseSkill(player);
                    else if (enemy is Skeleton skeleton) skeleton.UseSkill(player);
                    else if (enemy is Zombie zombie) zombie.UseSkill(player);
                    else if (enemy is Dragon dragon) dragon.UseSkill(player);
                }

                if (player.GetHp() <= 0)
                {
                    Console.WriteLine("You have been defeated!");
                    return false;
                }

                player.EndTurn();
                enemy.EndTurn();
            }

            Console.WriteLine("Victory! The enemy has been defeated.");
            return true;
        }

        private static void PerformWarriorAction(Warrior warrior, Character enemy)
        {
            Console.WriteLine("Choose action: 1-Attack, 2-Heal, 3-Battle Rage, 4-Iron Armor.");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: warrior.DealDamage(enemy, 0, "physical"); break;
                case 2: warrior.DrumsOfWar(); break;
                case 3: warrior.BattleRage(); break;
                case 4: warrior.IronArmor(); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }

        private static void PerformWizardAction(Wizard wizard, Character enemy)
        {
            Console.WriteLine("Choose action: 1-Attack, 2-Channel Magic, 3-Healing Magic.");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: wizard.DealDamage(enemy, 0, "magic"); break;
                case 2: wizard.ChannelMagic(); break;
                case 3: wizard.HealingMagic(); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }

        private static void PerformThiefAction(Thief thief, Character enemy)
        {
            Console.WriteLine("Choose action: 1-Attack, 2-Enter Stealth, 3-Patch Wounds.");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: thief.DealDamage(enemy, 0, "physical"); break;
                case 2: thief.StealthStrike(); break;
                case 3: thief.PatchWounds(); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
