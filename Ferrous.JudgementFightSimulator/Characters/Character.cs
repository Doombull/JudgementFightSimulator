using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferrous.JudgementFightSimulator.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Actions { get; set; }
        public int Might { get; set; }
        public int Accuracy { get; set; }
        public int Magic { get; set; }
        public int Agility { get; set; }
        public int Resilience { get; set; }

        public int AccuracyDefence { get; set; }
        public int HitDefence { get; set; }

        public List<Effect> Effects = new List<Effect>();

        public abstract double Fight(Character opponant);

        public void ApplyEffect(Effect effect)
        {
            if (Effects.Contains(effect))
                return;

            Effects.Add(effect);

            switch (effect)
            {
                case Effect.Blind:
                case Effect.Stun:
                    Agility -= 2;
                    break;

                case Effect.Poison:
                    Agility -= 1;
                    break;
            }
        }
    }
}
