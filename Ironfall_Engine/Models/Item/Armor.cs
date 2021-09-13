using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models.Item
{
    class Armor : GameItem
    {
        public int Defense { get; set; }

        // enchantment
        // drawback

        public Armor(int id, string name, string description, int value, bool isUnique, int defense, Enum type)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Defense = defense;
            Type = type;
        }
    }
}
