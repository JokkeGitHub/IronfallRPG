using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Enums
{
    public class ItemEnum
    {
        public enum Weapon
        {
            OneHanded,
            TwoHanded,
            Ranged,
            Shield
        }

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

        public enum Loot
        {
            Trash,
            Common,
            Material,
            Recipe,
            Quest
        }

        public enum Consumable
        {
            Ingredient,
            Potion,
            Scroll,
            Food
        }

        public enum Trinket
        {
            Heirloom,
            Antique,
            Magical,
            Mechanism
        }
    }
}
