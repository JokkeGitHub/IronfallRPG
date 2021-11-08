using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Actions;


namespace Ironfall_Engine.Models.Item
{
    public abstract class GameItem
    {
        public enum ItemCategory
        {
            Weapon,
            Consumable,
            Artefact,
            Armor,
            Trinket,
            Loot,
            Recipe
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public bool IsUnique { get; set; }
        public ItemCategory Category { get; set; }

        // Add overloadable method here and overload in subclasses
    }
}
