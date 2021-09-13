using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Enums;

namespace Ironfall_Engine.Factories.Item
{
    class ArmorFactory
    {
        static int id = 300;

        public Armor Create(string name, string description, int value, bool isUnique, int defense, ItemEnumArmor.Type type)
        {
            id += 1;

            return new Armor(id, name, description, value, isUnique, defense, type);
        }
    }
}
