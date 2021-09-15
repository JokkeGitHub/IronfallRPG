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

        public Consumable Create(string name, string description, int value, bool isUnique, Enum type, int quantity, int minEffect, int maxEffect)
        {
            id += 1;

            return new Consumable(id, name, description, value, isUnique, type, quantity, minEffect, maxEffect);
        }
    }
}
