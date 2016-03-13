using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Actions { get; set; }
        public int Might { get; set; }
        public int Accuracy { get; set; }
        public int Magic { get; set; }
        public int Agility { get; set; }
        public int Resilience { get; set; }

        public int AccuracyDefence { get; set; }

        public List<Effect> Effects = new List<Effect>();

        public abstract double Fight(Character opponant);

        public void ApplyEffect(Effect effect)
        {
            if (Effects.Contains(effect))
                return;

            Effects.Add(effect);

            switch (effect)
            {
                case Effect.Poison:
                    Might -= 2;
					Magic -= 2;
					Accuracy -= 2;
					Agility -= 2;
					break;
            }
        }

		public virtual AttackResult TakeHit(AttackType attackType, int attackerAbility)
		{
			if (attackType == AttackType.Ranged)
				attackerAbility -= AccuracyDefence;

			var hits = DiceRoller.RollAtLeast(DiceShape.D10, Math.Max(Agility - attackerAbility, 2), 3);
			return (AttackResult)hits;
		}

		public virtual int TakeDamage(AttackType attackType, AttackResult severity, DamageExpression[] damageSpread, bool ignoreResilience = false)
		{
			var damage = damageSpread[(int)severity].GetDamage();

			if (!ignoreResilience)
				damage = Math.Max(damage - Resilience, 0);

			return damage;
		}
	}
}
