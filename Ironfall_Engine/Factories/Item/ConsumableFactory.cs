using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Enums;
using Ironfall_Engine.Models.Item;

namespace Ironfall_Engine.Factories.Item
{
    class ConsumableFactory
    {
        static int id = 0;

        public Consumable Create(string name, string description, int value, bool isUnique, int quantity, ItemEnumConsumable.Type type)
        {
            id += 1;

            return new Consumable(id, name, description, value, isUnique, quantity, type);
        }
    }
}
