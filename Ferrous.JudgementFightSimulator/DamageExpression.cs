using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ferrous.Dice;

namespace Ferrous.JudgementFightSimulator
{
	public class DamageExpression
	{
		public int NoOfDice { get; }
		public DiceShape Dice { get; }
		public int ConstantDamage { get; }

		public DamageExpression(int constantDamage)
		{
			ConstantDamage = constantDamage;
		}

		public DamageExpression(int noOfDice, DiceShape dice)
		{
			NoOfDice = noOfDice;
			Dice = dice;
		}

		public DamageExpression(int noOfDice, DiceShape dice, int constantDamage)
		{
			NoOfDice = noOfDice;
			Dice = dice;
			ConstantDamage = constantDamage;
		}

		public int GetDamage()
		{
			var result = 0;

			if (NoOfDice > 0)
				result += DiceRoller.Roll(Dice, NoOfDice);

			return result + ConstantDamage;
		}
	}
}
