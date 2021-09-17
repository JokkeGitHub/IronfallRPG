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
        static int id = 0;

        public Consumable Create(string name, string description, int value, bool isUnique, GameItem.ItemCategory category, Enum consumableType, int quantity, int minEffect, int maxEffect)
        {
            id += 1;

            return new Consumable(id, name, description, value, isUnique, category, consumableType, quantity, minEffect, maxEffect);
        }
    }
}
