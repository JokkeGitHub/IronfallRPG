using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Interfaces.Item;

namespace Ironfall_Engine.Models.Item
{
    class Consumable : GameItem, IEffect
    {
        public int Quantity { get; set; }
        public int MinEffect { get; set; }
        public int MaxEffect { get; set; }

        public Consumable(int id, string name, string description, int value, bool isUnique, Enum type, int quantity, int minEffect, int maxEffect)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Type = type;
            Quantity = quantity;
            MinEffect = minEffect;
            MaxEffect = maxEffect;
        }

        int IEffect.MinMax(int minEffect, int maxEffect, int affectedStat)
        {
            int effectOutput = RNG.NumberBetween(minEffect, maxEffect);

            // effect method healing example
            affectedStat += effectOutput;
            return affectedStat;
        }
    }
}
