using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Factories.Item;
using Ironfall_Engine.Models.Item;
using Ironfall_Engine.Enums;

namespace Ironfall_Engine
{
    class ItemList
    {
        public Weapon testWeapon = new WeaponFactory().Create("Developers Axe", "Forged in the code of the Architects.", 100, true, GameItem.ItemCategory.Weapon, 1, 5, ItemEnum.Weapon.OneHanded);
    }
}
