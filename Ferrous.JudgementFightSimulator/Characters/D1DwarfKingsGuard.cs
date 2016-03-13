using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class D1DwarfKingsGuard : Character
    {
        public D1DwarfKingsGuard()
        {
            Name = "D1 - Dwarf Kings Guard";
            Health = 18;
            Actions = 3;
            Might = 7;
            Agility = 10;
            Resilience = 2;
        }

        public override double Fight(Character opponant)
        {
            var damageCaused = 0;
            var actionsRemaining = Actions;

            while (actionsRemaining > 0)
            {
				if (actionsRemaining <= 1)
					break;

				actionsRemaining -= 2;

				var hit = opponant.TakeHit(AttackType.Melee, Might);

				var damageSpread = new DamageExpression[4] {
					new DamageExpression(0),
					new DamageExpression(2, DiceShape.D4),
					new DamageExpression(2, DiceShape.D4, 1),
					new DamageExpression(2, DiceShape.D4, 3)
				};

				damageCaused += opponant.TakeDamage(AttackType.Melee, hit, damageSpread);
            }

            damageCaused += DiceRoller.Roll(DiceShape.D4, 2);

            return (double)damageCaused / opponant.Health * 100;
		}

		public override AttackResult TakeHit(AttackType attackType, int attackerAbility)
		{
			var hits = base.TakeHit(attackType, attackerAbility);

			return (AttackResult)(Math.Min((int)hits, 2));
		}
	}
}
