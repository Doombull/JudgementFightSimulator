using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class D2HumanWinterKnight : Character
    {
        public D2HumanWinterKnight()
        {
            Name = "D2 - Human Winter Knight";
            Health = 18;
            Actions = 3;
            Might = 5;
            Agility = 10;
            Resilience = 2;
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
                    DiceRoller.Roll(DiceShape.D6),
                    1,
                    2);
            }

            damageCaused += DiceRoller.Roll(DiceShape.D6) + 1;

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
