using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirst
{
    public class DamageOverTime
    {
        public string Effect;
        private int damage;
        private int duration;

        public DamageOverTime(string effect, int damage, int duration)
        {
            this.Effect = effect;
            this.damage = damage;
            this.duration = duration;
        }

        public bool ApplyEffect(Character target)
        {
            target.TakeDamage(damage);
            duration--;
            return duration == 0;
        }

    }
}
