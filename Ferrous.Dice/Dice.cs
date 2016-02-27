using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferrous.Dice
{
    public static class DiceRoller
    {
        private static Random _random = new Random();

        public static int Roll(DiceShape shape)
        {
            return _random.Next(1, (int)shape + 1);
        }

        public static int Roll(DiceShape shape, int noOfDice)
        {
            int result = 0;

            for (int diceRolled = 0; diceRolled < noOfDice; diceRolled++)
                result += Roll(shape);

            return result;
        }

        public static int RollAtLeast(DiceShape shape, int target, int noOfDice)
        {
            var result = 0;

            for (int diceRolled = 0; diceRolled < noOfDice; diceRolled++)
                if (Roll(shape) >= target)
                    result++;

            return result;
        }
    }

    public enum DiceShape
    {
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10
    }
}
