using Ironfall_Engine.Enums;
using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Factories.Item
{
    class WeaponFactory
    {
        static int id = 200;

        public Weapon Create(string name, string description, int value, bool isUnique, GameItem.ItemCategory category, Enum weaponType, int minDamage, int maxDamage)
        {
            id += 1;

            return new Weapon(id, name, description, value, isUnique, category, weaponType, minDamage, maxDamage);
        }

        public Weapon GetEmptyMainHand()
        {
            Weapon emptyMainHand = ItemList.mainHand;
            return emptyMainHand;
        }

        public Weapon GetEmptyOffHand()
        {
            Weapon emptyOffHand = ItemList.offHand;
            return emptyOffHand;
        }
    }
}
