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
            Health = 12;
            Actions = 3;
            Might = 4;
            Magic = 5;
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
                    Magic,
                    opponant,
                    DiceRoller.Roll(DiceShape.D4),
                    1,
                    2);
            }

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
