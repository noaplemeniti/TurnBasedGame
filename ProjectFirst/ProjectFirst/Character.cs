using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectFirst
{
    public class Character
    {
        public string Name;
        protected int Hp;
        protected int defaultDamage;
        protected int damage;
        protected int defaultArmor;
        protected int armor;
        protected int defaultMagicResist;
        protected int MagicResist;

        private List<DamageOverTime> activeEffects;
        public bool isPlayer { get; private set; }

        private Dictionary<string, int> statModifiers = new Dictionary<string, int>();
        private Dictionary<string, int> buffDurations = new Dictionary<string, int>();

        public Character(string name, int Hp, int baseDamage, int baseArmor, int baseMR, bool isPlayer)
        {
            this.Name = name;
            this.Hp = Hp;
            this.damage = baseDamage;
            this.defaultDamage = baseDamage;
            this.armor = baseArmor;
            this.MagicResist = baseMR;
            this.defaultMagicResist = baseMR;
            this.defaultArmor = baseArmor;
            this.isPlayer = isPlayer;

            activeEffects = new List<DamageOverTime>();
        }

        public int GetHp() { return this.Hp; }

        public void TakeDamage(int damage)
        {
            this.Hp = Math.Max(this.Hp - damage, 0);
        }

        public void PhysicalTakeDamage(int damage)
        {
            TakeDamage(Math.Max(damage - this.armor, 0));
        }

        public void MagicalDamageTaken(int damage)
        {
            TakeDamage(Math.Max(damage - this.MagicResist, 0));
        }

        public void Heal(int heal)
        {
            this.Hp = Math.Min(this.Hp + heal, 100);
        }

        public void ApplyBuff(string stat, int amount, int duration)
        {
            if (!statModifiers.ContainsKey(stat))
            {
                statModifiers[stat] = 0;
                buffDurations[stat] = 0;
            }

            statModifiers[stat] += amount;
            buffDurations[stat] = duration;

            UpdateStat(stat);
        }

        public void DealDamage(Character target, int damageModifier = 0, string damageType = "physical")
        {
            int totalDamage = this.damage + damageModifier;

            if (damageType == "physical")
            {
                totalDamage = Math.Max(totalDamage - target.armor, 0);
            }
            else if (damageType == "magical")
            {
                totalDamage = Math.Max(totalDamage - target.MagicResist, 0);
            }

            Console.WriteLine($"{this.Name} deals {totalDamage} {damageType} damage to {target.Name}.");

            target.TakeDamage(totalDamage);
        }

        /*public void ApplyDOT(DamageOverTime Effect)
        {
            activeEffects.Add(Effect);
        }*/

        private void UpdateStat(string stat)
        {
            switch (stat)
            {
                case "damage":
                    this.damage = this.defaultDamage + statModifiers[stat];
                    break;
                case "armor":
                    this.armor = this.defaultArmor + statModifiers[stat];
                    break;
                case "magicResist":
                    this.MagicResist = this.defaultMagicResist + statModifiers[stat];
                    break;
            }
        }

        public void EndTurn()
        {
            //buff
            List<string> expiredBuffs = new List<string>();

            foreach (var stat in buffDurations.Keys.ToList())
            {
                if (buffDurations[stat] > 0)
                {
                    buffDurations[stat]--;
                    if (buffDurations[stat] == 0)
                    {
                        expiredBuffs.Add(stat);
                    }
                }
            }
            foreach (string stat in expiredBuffs)
            {
                statModifiers[stat] = 0;
                UpdateStat(stat);
                statModifiers.Remove(stat);
                buffDurations.Remove(stat);
            }
        }
        public static void DisplayCharacterStats(Character character)
        {
            Console.WriteLine($"{character.Name}'s Stats:");
            Console.WriteLine($"HP: {character.Hp}");
            Console.WriteLine($"Damage: {character.damage}");
            Console.WriteLine($"Armor: {character.armor}");
            Console.WriteLine($"Magic Resist: {character.MagicResist}");
            Console.WriteLine("-------------------------------");
        }
    }  
}
