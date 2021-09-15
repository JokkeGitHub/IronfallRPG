namespace Ironfall_Engine.Models
{
    public class LivingEntity
    {

        public string Name { get; set; }
        public int HpMax { get; set; }
        public int HpCurrent { get; set; }
        public int DamageMinimum { get; set; }
        public int DamageMaximum { get; set; }
        public int MpMax { get; set; }
        public int MpCurrent { get; set; }
        public int ApMax { get; set; }
        public int ApCurrent { get; set; }
        public int Defence { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public string Image { get; set; }


        protected LivingEntity(string name, string image, int hpMax, int hpCurrent, int damageMinimum, int damageMaximum, int mpMax, int mpCurrent, int apMax, int apCurrent, int defence, int level, int gold)
        {
            Name = name;
            Image = image;
            HpMax = hpMax;
            HpCurrent = hpCurrent;
            DamageMinimum = damageMinimum;
            DamageMaximum = damageMaximum;
            MpMax = mpMax;
            MpCurrent = mpCurrent;
            ApMax = apMax;
            ApCurrent = apCurrent;
            Defence = defence;
            Level = level;
            Gold = gold;
        }
    }
}
