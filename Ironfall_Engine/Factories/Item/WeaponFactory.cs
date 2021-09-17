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

        public Weapon Create(string name, string description, int value, bool isUnique, GameItem.ItemCategory category, int minDamage, int maxDamage, Enum weaponType)
        {
            id += 1;

            return new Weapon(id, name, description, value, isUnique, category, minDamage, maxDamage, weaponType);
        }
    }
}
