using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class D2HumanWinterKnight : Character
    {
        public D2HumanWinterKnight()
        {
            Name = "D2 - Human Winter Knight";
            Health = 18;
            Actions = 3;
            Might = 6;
            Agility = 11;
            Resilience = 2;
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
					new DamageExpression(2),
					new DamageExpression(1, DiceShape.D6, 1),
					new DamageExpression(1, DiceShape.D6, 2)
				};

				damageCaused += opponant.TakeDamage(AttackType.Melee, hit, damageSpread);
			}

            damageCaused += DiceRoller.Roll(DiceShape.D4, 1);

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
