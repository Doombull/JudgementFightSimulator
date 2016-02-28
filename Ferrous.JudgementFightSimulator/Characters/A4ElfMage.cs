using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class A4ElfMage : Character
    {
        public A4ElfMage()
        {
            Name = "A4 - Elf Mage";
            Health = 13;
            Actions = 3;
            Might = 2;
            Magic = 7;
            Agility = 13;
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
                    DiceRoller.Roll(DiceShape.D6) + 1,
                    1,
                    2);
            }

            damageCaused += DiceRoller.Roll(DiceShape.D6, opponant.Resilience);

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
