using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class A2HumanBarbarian : Character
    {
        public A2HumanBarbarian()
        {
            Name = "A2 - Human Barbarian";
            Health = 16;
            Actions = 3;
            Might = 8;
            Agility = 12;
            Resilience = 0;
        }

        public override double Fight(Character opponant)
        {
            var shouldCharge = true;
            var rage = 0;

            var damageCaused = 0;
            var actionsRemaining = Actions;

            while (actionsRemaining > 0)
            {
                bool charged = false;
                if (shouldCharge && actionsRemaining == Actions)
                {
					charged = true;
					rage += 1;
                    actionsRemaining--;
                }

                actionsRemaining--;

				var hit = opponant.TakeHit(AttackType.Melee, Might + (charged ? Rules.ChargeBonus : 0));
				if (hit == AttackResult.Critical)
					rage += 1;

				var damageSpread = new DamageExpression[4] {
					new DamageExpression(0),
					new DamageExpression(2),
					new DamageExpression(1, DiceShape.D6, 1),
					new DamageExpression(1, DiceShape.D6, 2)
				};

				damageCaused += opponant.TakeDamage(AttackType.Melee, hit, damageSpread);
            }

            damageCaused += DiceRoller.Roll(DiceShape.D6, rage);

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
