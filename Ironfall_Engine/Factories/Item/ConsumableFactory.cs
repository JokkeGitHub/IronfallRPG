using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Factories.Item
{
    class ConsumableFactory
    {
        public Consumable Create(int id, string name, string description, int value, bool isUnique, GameItem.ItemCategory category, Enum consumableType, int minEffect, int maxEffect)
        {
            return new Consumable(id, name, description, value, isUnique, category, consumableType, minEffect, maxEffect);
        }
    }
}
