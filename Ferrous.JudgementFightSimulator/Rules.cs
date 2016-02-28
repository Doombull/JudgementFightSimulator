using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;
using Ferrous.JudgementFightSimulator.Characters;

namespace Ferrous.JudgementFightSimulator
{
    public static class Rules
    {
        public static AttackResult CalculateAttackRoll(int attackerAbility, Character target)
        {
            var hits = DiceRoller.RollAtLeast(DiceShape.D10, target.Agility - attackerAbility, 3);
            return (AttackResult)Math.Max(hits - target.HitDefence, 0);
        }

        public static int CalculateAttackDamage(AttackResult attackResult, int targetResilience, int baseDamage, int solidModifier, int critModifier)
        {
            var damage = 0;

            switch (attackResult)
            {
                case AttackResult.Glancing:
                    damage = baseDamage;
                    break;

                case AttackResult.Solid:
                    damage = baseDamage + solidModifier;
                    break;

                case AttackResult.Critical:
                    damage = baseDamage + critModifier;
                    break;
            }

            return Math.Max(damage - targetResilience, 0);
        }

        public static int CalculateAttackDamage(int attackerAbility, Character target, int baseDamage, int solidModifier, int critModifier)
        {
            var attackResult = CalculateAttackRoll(attackerAbility, target);
            return CalculateAttackDamage(attackResult, target.Resilience, baseDamage, solidModifier, critModifier);
        }
    }
}
