using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class SG3DwarfDruid : Character
    {
        public SG3DwarfDruid()
        {
            Name = "SG3 - Dwarf Druid";
            Health = 18;
            Actions = 3;
            Might = 5;
            Accuracy = 5;
            Agility = 11;
            Resilience = 1;
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

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
