using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Interfaces.Item;

namespace Ironfall_Engine.Models.Item
{
    public class Consumable : GameItem, IEffect
    {
        public int MinEffect { get; set; }
        public int MaxEffect { get; set; }
        public Enum ConsumableType { get; set; }

        public Consumable(int id, string name, string description, int value, bool isUnique, ItemCategory category, Enum consumableType, int minEffect, int maxEffect)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Category = category;
            ConsumableType = consumableType;
            MinEffect = minEffect;
            MaxEffect = maxEffect;
        }



        void HP()
        {

        }

        void MP()
        {

        }

        void AP()
        {

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
