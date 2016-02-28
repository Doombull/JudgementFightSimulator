using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class SU1OrcWitchDoctor : Character
    {
        public SU1OrcWitchDoctor()
        {
            Name = "SU1 - Orc Witch Doctor";
            Health = 14;
            Actions = 3;
            Might = 4;
            Magic = 4;
            Agility = 12;
            Resilience = 0;
        }

        public override double Fight(Character opponant)
        {
            var damageCaused = 0;

            var actionsRemaining = Actions;
            while (actionsRemaining > 0)
            {
                actionsRemaining--;

                damageCaused += Rules.CalculateAttackDamage(
                    Might,
                    opponant,
                    DiceRoller.Roll(DiceShape.D4),
                    1,
                    2);
            }

            damageCaused += DiceRoller.Roll(DiceShape.D4, 2);

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
