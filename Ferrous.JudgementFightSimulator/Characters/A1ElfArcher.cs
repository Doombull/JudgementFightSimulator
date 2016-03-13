using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class A1ElfArcher : Character
    {
        public A1ElfArcher()
        {
            Name = "A1 - Elf Archer";
            Health = 15;
            Actions = 4;
            Might = 5;
            Accuracy = 6;
            Agility = 12;
            Resilience = 0;
        }

        public override double Fight(Character opponant)
        {
            var damageCaused = 0;
            var mageHunterDamage = (opponant.Magic > 0) ? 2 : 0;
            var aimingBonus = 1;

            var actionsRemaining = Actions;
            while (actionsRemaining > 0)
            {
                actionsRemaining--;

                damageCaused += Rules.CalculateAttackDamage(
                    Accuracy + aimingBonus - opponant.AccuracyDefence,
                    opponant,
                    DiceRoller.Roll(DiceShape.D4) + mageHunterDamage,
                    1,
                    2);
            }

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
