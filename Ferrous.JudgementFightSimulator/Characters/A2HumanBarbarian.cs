using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public class A2HumanBarbarian : Character
    {
        public A2HumanBarbarian()
        {
            Name = "A2 - Human Barbarianr";
            Health = 16;
            Actions = 3;
            Might = 7;
            Agility = 11;
            Resilience = 0;
        }

        public override double Fight(Character opponant)
        {
            var shouldCharge = true;
            var rage = 0;

            var damageCaused = 0;
            var actionsRemaining = Actions;

            while (actionsRemaining > 0)
            {
                var chargeBonus = 0;
                if (shouldCharge && actionsRemaining == Actions)
                {
                    rage += 1;
                    opponant.ApplyEffect(Effect.Stun);
                    chargeBonus = 2;
                    actionsRemaining--;
                }

                actionsRemaining--;

                var attack = Rules.CalculateAttackRoll(Might + chargeBonus, opponant.Agility);
                if (attack == AttackResult.Critical)
                    rage += 1;

                damageCaused += Rules.CalculateAttackDamage(attack, opponant.Resilience, DiceShape.D6, 0, 1, 2);
            }

            damageCaused += DiceRoller.Roll(DiceShape.D6, rage);

            return (double)damageCaused / opponant.Health * 100;
        }
    }
}
