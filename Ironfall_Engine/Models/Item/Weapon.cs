using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Interfaces.Item;
using Ironfall_Engine.Enums;

namespace Ironfall_Engine.Models.Item
{
    class Weapon : GameItem, IEffect, IEnchantment
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public Enum WeaponType { get; set; }

        public Weapon(int id, string name, string description, int value, bool isUnique, ItemCategory category, int minDamage, int maxDamage, Enum weaponType)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Category = category;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            WeaponType = weaponType;
        }
        
        int IEffect.MinMax(int minDamage, int maxDamage, int enemyHP)
        {
            int damageOutput = RNG.NumberBetween(minDamage, maxDamage);

            // damage method example
            enemyHP -= damageOutput;
            return enemyHP;
        }

        int IEnchantment.Effect(int effect, int affectedStat)
        {
           return affectedStat += effect;
        }


    }
}
