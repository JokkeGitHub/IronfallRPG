using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models.Item
{
    public class Trinket : GameItem
    {
        public Enum TrinketType { get; set; }

        public Trinket(int id, string name, string description, int value, bool isUnique, ItemCategory category, Enum trinketType)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Category = category;
            TrinketType = trinketType;
        }
    }
}
