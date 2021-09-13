using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Enums;
using Ironfall_Engine.Models.Item;

namespace Ironfall_Engine.Factories.Item
{
    class WeaponFactory
    {
        static int id = 200;

        public Weapon Create(string name, string description, int value, bool isUnique, int minDamage, int maxDamage, ItemEnumWeapon.Type type)
        {
            id += 1;

            return new Weapon(id, name, description, value, isUnique, minDamage, maxDamage, type);
        }
    }
}
