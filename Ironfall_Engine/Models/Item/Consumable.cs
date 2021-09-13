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

        // minEffect
        // maxEffect

        public Consumable(int id, string name, string description, int value, bool isUnique, Enum type, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Type = type;
            Quantity = quantity;
        }

        // Action Method
    }
}
