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
                    DiceRoller.Roll(DiceShape.D6),
                    1,
                    2);
            }

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
