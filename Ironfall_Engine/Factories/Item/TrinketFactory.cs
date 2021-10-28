using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Models.Item;

namespace Ironfall_Engine.Factories.Item
{
    class TrinketFactory
    {
        public Trinket Create(int id, string name, string description, int value, bool isUnique, GameItem.ItemCategory category, Enum commonType)
        {
            return new Trinket(id, name, description, value, isUnique, category, commonType);
        }
    }
}
