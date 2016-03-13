using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class A1ElfArcher : Character
    {
        public A1ElfArcher()
        {
            Name = "A1 - Elf Archer";
            Health = 15;
            Actions = 4;
            Might = 5;
            Accuracy = 5;
            Agility = 13;
            Resilience = 0;
        }

        public override double Fight(Character opponant)
        {
            var mageHunterDamage = (opponant.Magic > 0) ? 1 : 0;
            var birdBonus = 1;

			var damageCaused = 0;
			var actionsRemaining = Actions;

            while (actionsRemaining > 0)
            {
                actionsRemaining--;

				var hit = opponant.TakeHit(AttackType.Ranged, Accuracy + Rules.AimingBonus + birdBonus);

				var damageSpread = new DamageExpression[4] {
					new DamageExpression(0),
					new DamageExpression(2 + mageHunterDamage),
					new DamageExpression(1, DiceShape.D4, 1 + mageHunterDamage),
					new DamageExpression(1, DiceShape.D4, 3 + mageHunterDamage)
				};

				damageCaused += opponant.TakeDamage(AttackType.Ranged, hit, damageSpread);
            }

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
