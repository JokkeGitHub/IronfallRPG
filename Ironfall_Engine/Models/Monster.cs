using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models
{
    class Monster : LivingEntity
    {

        public string Type { get; set; }
        public string SubType { get; set; }
        public string Description { get; set; }
        public int RewardExp { get; set; }

        public Monster(string name, string image, int hpCurrent, int hpMax, int damageMin, int damageMax, int mpCurrent, int mpMax, int apCurrent, int apMax, int defence, int level, int gold, string type, string subType, string description, int rewardExp) 
            : base(name, image, hpMax, hpCurrent, damageMin, damageMax, mpMax, mpCurrent, apMax, apCurrent, defence, level, gold)
        {
            Image = $"/Ironfall_Engine;component/Resource/Images/Monsters/{image}";
            Type = type;
            SubType = subType;
            Description = description;
            RewardExp = rewardExp;
        }
    }
}
