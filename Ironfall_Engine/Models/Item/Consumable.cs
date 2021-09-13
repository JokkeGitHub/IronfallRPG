using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models.Item
{
    class Consumable : GameItem
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

        // Action Method
    }
}
