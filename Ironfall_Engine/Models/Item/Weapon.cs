using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models.Item
{
    class Weapon : GameItem
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        // enchantment

        public Weapon(int id, string name, string description, int value, bool isUnique, Enum type, int minDamage, int maxDamage)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Type = type;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        // Action Method
    }
}
