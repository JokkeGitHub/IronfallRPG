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


    }
}
