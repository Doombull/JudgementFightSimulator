using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class A4ElfMage : Character
    {
        public A4ElfMage()
        {
            Name = "A4 - Elf Mage";
            Health = 13;
            Actions = 3;
            Magic = 7;
            Agility = 14;
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
					new DamageExpression(1, DiceShape.D6, 1),
					new DamageExpression(1, DiceShape.D6, 2)
				};

				damageCaused += opponant.TakeDamage(AttackType.Magic, hit, damageSpread, true);
			}

            damageCaused += DiceRoller.Roll(DiceShape.D6, opponant.Resilience);

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
