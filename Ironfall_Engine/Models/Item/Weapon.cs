using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Interfaces.Item;

namespace Ironfall_Engine.Models.Item
{
    class Weapon : GameItem, IEffect, IEnchantment
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

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
