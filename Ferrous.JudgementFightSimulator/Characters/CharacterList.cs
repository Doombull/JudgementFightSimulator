using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public static class CharacterList
    {
        public static List<Character> Get()
        {
            var list = new List<Character>();

            list.Add(new A1ElfArcher());
            list.Add(new A2HumanBarbarian());
            list.Add(new A3Minotaur());
            list.Add(new A4ElfMage());
            list.Add(new A5OrcRogue());
            list.Add(new D1DwarfKingsGuard());
            list.Add(new D2HumanWinterKnight());
            list.Add(new SG1HumanNecromancer());
            list.Add(new SG2ElfPriestess());
            list.Add(new SG3DwarfDruid());
            list.Add(new SU1OrcWitchDoctor());
            list.Add(new SU2HumanTribalElder());

            return list;
        }
    }
}
