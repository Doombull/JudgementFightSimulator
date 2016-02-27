using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator
{
    public static class Rules
    {
        public static AttackResult CalculateAttackRoll(int attackerAbility, int targetAgility)
        {
            return (AttackResult)DiceRoller.RollAtLeast(DiceShape.D10, targetAgility - attackerAbility, 3);
        }

        public static int CalculateAttackDamage(AttackResult attackResult, int targetResilience, DiceShape dice, int glancingModifier, int solidModifier, int critModifier)
        {
            var damage = 0;

            switch (attackResult)
            {
                case AttackResult.Glancing:
                    damage = DiceRoller.Roll(dice) + glancingModifier;
                    break;

                case AttackResult.Solid:
                    damage = DiceRoller.Roll(dice) + solidModifier;
                    break;

                case AttackResult.Critical:
                    damage = DiceRoller.Roll(dice) + critModifier;
                    break;
            }

            return Math.Max(damage - targetResilience, 0);
        }

        public static int CalculateAttackDamage(int attackerAbility, int targetAgility, int targetResilience, DiceShape dice, int glancingModifier, int solidModifier, int critModifier)
        {
            var attackResult = CalculateAttackRoll(attackerAbility, targetAgility);
            return CalculateAttackDamage(attackResult, targetResilience, dice, glancingModifier, solidModifier, critModifier);
        }
    }
}
