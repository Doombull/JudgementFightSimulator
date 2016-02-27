using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferrous;

namespace Ferrous.JudgementFightSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxFights = 10000;

            //Archer fight archer
            Characters.Character fighter = new Characters.A1ElfArcher();

            var result = 0.0;
            for (var fightCount = 0; fightCount < maxFights; fightCount++)
                result += fighter.Fight(new Characters.A1ElfArcher());

            Console.WriteLine("Archer v Archer: " + result / maxFights);

            result = 0.0;
            for (var fightCount = 0; fightCount < maxFights; fightCount++)
                result += fighter.Fight(new Characters.A2HumanBarbarian());

            Console.WriteLine("Archer v Barbarian: " + result / maxFights);

            fighter = new Characters.A2HumanBarbarian();
            result = 0.0;
            for (var fightCount = 0; fightCount < maxFights; fightCount++)
                result += fighter.Fight(new Characters.A1ElfArcher());

            Console.WriteLine("Barbarian v Archer: " + result / maxFights);

            result = 0.0;
            for (var fightCount = 0; fightCount < maxFights; fightCount++)
                result += fighter.Fight(new Characters.A2HumanBarbarian());

            Console.WriteLine("Barbarian v Barbarian: " + result / maxFights);

            Console.Read();
        }
        
    }
}
