using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class A3Minotaur : Character
    {
        public A3Minotaur()
        {
            Name = "A3 - Minotaur";
            Health = 20;
            Actions = 3;
            Might = 7;
            Agility = 10;
            Resilience = 1;
        }

        public override double Fight(Character opponant)
        {
            var damageCaused = 0;

            var actionsRemaining = Actions;
            while (actionsRemaining > 0)
            {
                if (actionsRemaining > 1)
                {

                    actionsRemaining -= 2;

                    damageCaused += Rules.CalculateAttackDamage(
                        Might,
                        opponant,
                        DiceRoller.Roll(DiceShape.D6, 2) + 1,
                        1,
                        2);
                }
                else
                {
                    actionsRemaining--;

                    damageCaused += Rules.CalculateAttackDamage(
                        Might,
                        opponant,
                        DiceRoller.Roll(DiceShape.D8) + 1,
                        1,
                        2);
                }
            }

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
