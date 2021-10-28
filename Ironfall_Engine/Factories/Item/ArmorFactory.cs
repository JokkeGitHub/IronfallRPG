using Ironfall_Engine.Models.Item;
using Ironfall_Engine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Factories.Item
{
    class ArmorFactory
    {
        static int id = 300;

        public Armor Create(string name, string description, int value, bool isUnique, GameItem.ItemCategory category, Enum armorType, int minDefense, int maxDefense)
        {
            id += 1;

            return new Armor(id, name, description, value, isUnique, category, armorType, minDefense, maxDefense);
        }
        public Armor GetEmptyChest()
        {
            Armor emptyChest = ItemList.chest;
            return emptyChest;
        }
    }
}
