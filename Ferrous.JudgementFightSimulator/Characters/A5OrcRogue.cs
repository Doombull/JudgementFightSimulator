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
            Health = 16;
            Actions = 3;
            Might = 5;
            Agility = 13;
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

                var attack = Rules.CalculateAttackRoll(Might, opponant);
                if (attack != AttackResult.Miss)
                    opponant.ApplyEffect(Effect.Poison);

                damageCaused += Rules.CalculateAttackDamage(attack, opponant.Resilience, DiceRoller.Roll(DiceShape.D4, 1), 1, 2);
            }

            if (opponant.Effects.Contains(Effect.Poison))
                damageCaused += DiceRoller.Roll(DiceShape.D6, 2);

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
