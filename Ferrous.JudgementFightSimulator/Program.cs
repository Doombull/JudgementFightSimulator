using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Ferrous;

using Ferrous.JudgementFightSimulator.Characters;

namespace Ferrous.JudgementFightSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxFights = 10000;

            using (XmlWriter writer = XmlWriter.Create(@"D:\Judgement.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Results");
                writer.WriteAttributeString("Date", DateTime.Now.ToString());

                foreach (Character protagonist in CharacterList.Get())
                {
                    writer.WriteStartElement("Character");
                    writer.WriteAttributeString("Name", protagonist.Name);

                    foreach (Character opponent in CharacterList.Get())
                    {
                        var result = 0.0;
                        for (var fightCount = 0; fightCount < maxFights; fightCount++)
                            result += protagonist.Fight(opponent);

                        Console.WriteLine(String.Format("{0} v {1}: {2}", protagonist.Name, opponent.Name, result / maxFights));

                        writer.WriteStartElement("Result");
                        writer.WriteAttributeString("Name", opponent.Name);
                        writer.WriteValue(String.Format("{0:n2}", result / maxFights));
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.Read();
        }
        
    }
}
