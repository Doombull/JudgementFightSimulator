using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class SG2ElfPriestess : Character
    {
        public SG2ElfPriestess()
        {
            Name = "SG2 - Elf Priestess";
            Health = 14;
            Actions = 3;
            Might = 6;
            Agility = 13;
            Resilience = 1;
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
