using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models.Item
{
    class Artifact : GameItem
    {
        // enhcantment
        // drawback

        public Artifact(int id, string name, string description, int value, bool isUnique, Enum type)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Type = type;
        }
    }
}
