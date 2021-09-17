using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Interfaces.Item;

namespace Ironfall_Engine.Models.Item
{
    class Armor : GameItem, IEnchantment, IDrawback
    {
        public int Defense { get; set; }
        public Enum ArmorType { get; set; }

        public Armor(int id, string name, string description, int value, bool isUnique, ItemCategory category, Enum armorType, int defense)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Category = category;
            ArmorType = armorType;
            Defense = defense;
        }
        int IEnchantment.Effect(int effect, int affectedStat)
        {
            return affectedStat += effect;
        }

        int IDrawback.Effect(int effect, int affectedStat)
        {
            return affectedStat -= effect;
        }
    }
}
