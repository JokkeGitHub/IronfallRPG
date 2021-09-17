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
        public ItemSlot Gear { get; set; }

        public LocalPlayer(string characterClass, string userID, int experiencePoints, int statBody, int statSpirit, int statFellowship, string name, string image, int hpMax, int hpCurrent, int damageMinimum, int damageMaximum, int mpMax, int mpCurrent, int apMax, int apCurrent, int defenceMinimum, int defenceMaximum, int level, int gold) : 
            base(name, image, hpMax, hpCurrent, damageMinimum, damageMaximum, mpMax, mpCurrent, apMax, apCurrent, defenceMinimum, defenceMaximum, level, gold)
        {
            CharacterClass = characterClass;
            UserID = userID;
            ExperiencePoints = experiencePoints;
            StatBody = statBody;
            StatSpirit = statSpirit;
            StatFellowship = statFellowship;
            Image = $"/Ironfall_Engine;component/Resource/Images/PlayerImages/{image}";
            
        }

    }
}
