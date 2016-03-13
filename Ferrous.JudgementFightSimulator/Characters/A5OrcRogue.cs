using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class A5OrcRogue : Character
    {
        public A5OrcRogue()
        {
            Name = "A5 - Orc Rogue";
            Health = 14;
            Actions = 3;
            Might = 5;
            Agility = 14;
            Resilience = 0;

            AccuracyDefence = 1;
        }

        public override double Fight(Character opponant)
        {
            var damageCaused = 0;
            var actionsRemaining = Actions;

            while (actionsRemaining > 0)
            {
				actionsRemaining--;

				var hit = opponant.TakeHit(AttackType.Melee, Might);
				if (hit != AttackResult.Miss)
					opponant.ApplyEffect(Effect.Poison);

				var damageSpread = new DamageExpression[4] {
					new DamageExpression(0),
					new DamageExpression(1),
					new DamageExpression(1, DiceShape.D4),
					new DamageExpression(1, DiceShape.D4, 2)
				};

				damageCaused += opponant.TakeDamage(AttackType.Melee, hit, damageSpread);
            }

            if (opponant.Effects.Contains(Effect.Poison))
                damageCaused += DiceRoller.Roll(DiceShape.D6, 2);

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
