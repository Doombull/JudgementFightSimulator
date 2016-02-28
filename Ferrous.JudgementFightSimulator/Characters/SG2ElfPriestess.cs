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
            Agility = 12;
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
                    DiceRoller.Roll(DiceShape.D6),
                    1,
                    2);
            }

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
