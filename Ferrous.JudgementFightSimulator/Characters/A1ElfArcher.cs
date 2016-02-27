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
            Accuracy = 5;
            Agility = 12;
            Resilience = 0;
        }

        public override double Fight(Character opponant)
        {
            var damageCaused = 0;
            var mageHunterDamage = (opponant.Magic > 0) ? 2 : 0;

            var actionsRemaining = Actions;
            while (actionsRemaining > 0)
            {
                actionsRemaining--;

                damageCaused += Rules.CalculateAttackDamage(
                    Accuracy,
                    opponant.Agility,
                    opponant.Resilience,
                    DiceShape.D4,
                    0 + mageHunterDamage,
                    1 + mageHunterDamage,
                    2 + mageHunterDamage);
            }

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
