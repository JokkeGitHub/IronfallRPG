using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Factories.Item
{
    class LootFactory
    {
        public Loot Create(int id, string name, string description, int value, bool isUnique, GameItem.ItemCategory category, Enum lootType)
        {
            return new Loot(id, name, description, value, isUnique, category, lootType);
        }
    }
}
