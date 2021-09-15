using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models
{
    public class LocalPlayer : LivingEntity
    {

        public string CharacterClass { get; set; }
        public string UserID { get; set; }
        public int ExperiencePoints { get; set; }
        public int StatBody { get; set; }
        public int StatSpirit { get; set; }
        public int StatFellowship { get; set; }

        public LocalPlayer(string characterClass, string userID, int experiencePoints, int statBody, int statSpirit, int statFellowship, string name, string image, int hpMax, int hpCurrent, int damageMinimum, int damageMaximum, int mpMax, int mpCurrent, int apMax, int apCurrent, int defence, int level, int gold) : 
            base(name, image, hpMax, hpCurrent, damageMinimum, damageMaximum, mpMax, mpCurrent, apMax, apCurrent, defence, level, gold)
        {
            CharacterClass = characterClass;
            UserID = userID;
            ExperiencePoints = experiencePoints;
            StatBody = statBody;
            StatSpirit = statSpirit;
            StatFellowship = statFellowship;
        }

    }
}
