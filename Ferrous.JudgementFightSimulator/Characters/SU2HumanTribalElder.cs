using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class SU2HumanTribalElder : Character
    {
        public SU2HumanTribalElder()
        {
            Name = "SU2 - Human Tribal Elder";
            Health = 16;
            Actions = 3;
            Might = 4;
			Magic = 6;
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
					new DamageExpression(2),
					new DamageExpression(1, DiceShape.D6, 1),
					new DamageExpression(1, DiceShape.D6, 2)
				};

				damageCaused += opponant.TakeDamage(AttackType.Melee, hit, damageSpread);
			}

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
