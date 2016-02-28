using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class D1DwarfKingsGuard : Character
    {
        public D1DwarfKingsGuard()
        {
            Name = "D1 - Dwarf Kings Guard";
            Health = 18;
            Actions = 3;
            Might = 7;
            Agility = 9;
            Resilience = 2;

            HitDefence = 1;
        }

        public override double Fight(Character opponant)
        {
            var damageCaused = 0;

            var actionsRemaining = Actions;
            while (actionsRemaining > 0)
            {
                if (actionsRemaining <= 1)
                    break;

                actionsRemaining -= 2;

                damageCaused += Rules.CalculateAttackDamage(
                    Might,
                    opponant,
                    DiceRoller.Roll(DiceShape.D4, 2) + 1,
                    1,
                    2);
            }

            damageCaused += DiceRoller.Roll(DiceShape.D4, 2) + 2;

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
