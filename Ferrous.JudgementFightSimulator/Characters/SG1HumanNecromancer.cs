using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class SG1HumanNecromancer : Character
    {
        public SG1HumanNecromancer()
        {
            Name = "SG1 - Human Necromancer";
            Health = 14;
            Actions = 3;
            Might = 4;
            Magic = 5;
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

				var hit = opponant.TakeHit(AttackType.Magic, Magic);

				var damageSpread = new DamageExpression[4] {
					new DamageExpression(0),
					new DamageExpression(2),
					new DamageExpression(1, DiceShape.D4, 1),
					new DamageExpression(1, DiceShape.D4, 3)
				};

				damageCaused += opponant.TakeDamage(AttackType.Magic, hit, damageSpread);
			}

			actionsRemaining = 2;

			while (actionsRemaining > 0)
			{
				actionsRemaining--;

				var hit = opponant.TakeHit(AttackType.Melee, Might);

				var damageSpread = new DamageExpression[4] {
					new DamageExpression(0),
					new DamageExpression(1),
					new DamageExpression(2),
					new DamageExpression(3)
				};

				damageCaused += opponant.TakeDamage(AttackType.Melee, hit, damageSpread);
			}

			return (double)damageCaused / opponant.Health * 100;
        }
    }
}
