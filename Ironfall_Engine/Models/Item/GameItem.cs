﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Enums;

namespace Ironfall_Engine.Models.Item
{
    abstract class GameItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public bool IsUnique { get; set; }
        public ItemCategory Category { get; set; }

        public enum ItemCategory
        {
            Weapon,
            Consumable,
            Artefact,
            Armor
        }
    }
}
