using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class A3Minotaur : Character
    {
        public A3Minotaur()
        {
            Name = "A3 - Minotaur";
            Health = 20;
            Actions = 3;
            Might = 5;
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

				var hit = opponant.TakeHit(AttackType.Melee, Might);

				var damageSpread = new DamageExpression[4] {
					new DamageExpression(0),
					new DamageExpression(3),
					new DamageExpression(1, DiceShape.D8, 2),
					new DamageExpression(1, DiceShape.D8, 4)
				};

				damageCaused += opponant.TakeDamage(AttackType.Melee, hit, damageSpread);
			}

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
