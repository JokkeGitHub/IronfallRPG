using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models.Item
{
    class Common : GameItem
    {
        public int Quantity { get; set; }
        public Enum CommonType { get; set; }

        public Common(int id, string name, string description, int value, bool isUnique, ItemCategory category, Enum commonType, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Category = category;
            CommonType = commonType;
            Quantity = quantity;
        }
    }
}
