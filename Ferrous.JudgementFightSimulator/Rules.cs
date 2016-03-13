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
		public static int AimingBonus = 1;
		public static int ChargeBonus = 2;
    }

	public enum AttackResult
	{
		Miss,
		Glancing,
		Solid,
		Critical
	}

	public enum AttackType
	{
		Melee,
		Ranged,
		Magic
	}

	public enum Effect
	{
		Curse,
		Fire,
		Poison,
		Stun
	}
}
