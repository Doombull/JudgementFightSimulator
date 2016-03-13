using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class SG3DwarfDruid : Character
    {
        public SG3DwarfDruid()
        {
            Name = "SG3 - Dwarf Druid";
            Health = 16;
            Actions = 3;
            Might = 5;
            Accuracy = 5;
            Agility = 11;
            Resilience = 0;
        }

        public override double Fight(Character opponant)
        {
            var damageCaused = 0;

            var actionsRemaining = Actions;
            while (actionsRemaining > 0)
            {
				actionsRemaining--;

				var hit = opponant.TakeHit(AttackType.Ranged, Accuracy);

				var damageSpread = new DamageExpression[4] {
					new DamageExpression(0),
					new DamageExpression(1),
					new DamageExpression(1, DiceShape.D4),
					new DamageExpression(1, DiceShape.D4, 2)
				};

				damageCaused += opponant.TakeDamage(AttackType.Ranged, hit, damageSpread);
			}

            return (double)damageCaused / opponant.Health * 100;
		}

		public override int TakeDamage(AttackType attackType, AttackResult severity, DamageExpression[] damageSpread, bool ignoreResilience = false)
		{
			var damage = base.TakeDamage(attackType, severity, damageSpread, ignoreResilience);

			if (attackType == AttackType.Melee && !ignoreResilience)
				damage = Math.Max(damage - 1, 0);

			return damage;
		}
	}
}
