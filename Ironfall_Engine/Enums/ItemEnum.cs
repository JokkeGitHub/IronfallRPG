using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Enums
{
    class ItemEnum
    {
        public enum Armor
        {
            Light,
            Medium,
            Heavy,
            Enchanted,
            Mythical
        }

        public enum Artifact
        {
            Neck,
            Head,
            Feet,
            Finger
        }

        public enum Common
        {
            Trash,
            Quest
        }

        public enum Consumable
        {
            Ingredient,
            Potion,
            Scroll
        }

        public enum Weapon
        {
            OneHanded,
            TwoHanded,
            Ranged,
            Shield
        }
    }
}
