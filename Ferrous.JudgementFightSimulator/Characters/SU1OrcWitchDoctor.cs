using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class SU1OrcWitchDoctor : Character
    {
        public SU1OrcWitchDoctor()
        {
            Name = "SU1 - Orc Witch Doctor";
            Health = 14;
            Actions = 3;
            Might = 4;
            Magic = 4;
            Agility = 13;
            Resilience = 0;
        }

        public override double Fight(Character opponant)
        {
            var damageCaused = 0;

            var actionsRemaining = Actions;
            while (actionsRemaining > 0)
            {
				actionsRemaining--;

				var hit = opponant.TakeHit(AttackType.Melee, Might);

				var damageSpread = new DamageExpression[4] {
					new DamageExpression(0),
					new DamageExpression(1),
					new DamageExpression(1, DiceShape.D4),
					new DamageExpression(1, DiceShape.D4, 2)
				};

				damageCaused += opponant.TakeDamage(AttackType.Melee, hit, damageSpread);
			}

            damageCaused += DiceRoller.Roll(DiceShape.D4, 2);

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
