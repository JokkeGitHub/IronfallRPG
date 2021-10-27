using System.Collections.Generic;
using System.Linq;
using Ironfall_Engine.Factories;

namespace Ironfall_Engine.Models
{
    public class Location
    {

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsTravelAllowed { get; set; }

        public Location(int xCoordinate, int yCoordinate, string name, string description, string image, bool isTravelAllowed)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            Image = image;
            IsTravelAllowed = isTravelAllowed;
        }

        public List<MonsterEncounter> MonsterHere { get; } = new List<MonsterEncounter>();
        public Npc NpcHere { get; set; }

        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            if (MonsterHere.Exists(m => m.MonsterID == monsterID))
            {
                //Checks if there is a monster and overwrites the chance of encountering if there is. 
                MonsterHere.First(m => m.MonsterID == monsterID).ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                //No monster present, add one. 
                MonsterHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }
        }
        
        public Monster GetMonster()
        {
            if (!MonsterHere.Any())
            {
                return null;
            }

            //Percentage of monster at location 
            int totalChances = MonsterHere.Sum(m => m.ChanceOfEncountering);

            //Select a random number between 1 and the total chance
            int randomNumber = RNG.NumberBetween(1, totalChances + 1);

            ///Loop throug the monsterlist. Adding the monsters percentage chance of appering to the running total.
            ///When the random number is lower than the running total, that is when the monster returns. 
            int runningTotal = 0;

            foreach (MonsterEncounter monsterEncounter in MonsterHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;
                if (randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }

            // if there is any problems return last monster
            return MonsterFactory.GetMonster(MonsterHere.Last().MonsterID);
        }
    }
}
