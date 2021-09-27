﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Actions;
using Ironfall_Engine.Models.Item;

namespace Ironfall_Engine.Models
{
    public class Monster : LivingEntity
    {

        public string Type { get; set; }
        public string SubType { get; set; }
        public string Description { get; set; }
        public int RewardExp { get; set; }

        public Monster(string name, string image, int hpCurrent, int hpMax, int damageMin, int damageMax, int mpCurrent, int mpMax, int apCurrent, int apMax, int defenceMinimum, int defenceMaximum, int level, int gold, string type, string subType, string description, int rewardExp, ItemSlot gear, BasicAction basicAction, ObservableCollection<GameItem> inventory) 
            : base(name, image, hpMax, hpCurrent, damageMin, damageMax, mpMax, mpCurrent, apMax, apCurrent, defenceMinimum, defenceMaximum, level, gold, gear, basicAction, inventory)
        {
            Image = $"/Ironfall_Engine;component/Resource/Images/Monsters/{image}";
            Type = type;
            SubType = subType;
            Description = description;
            RewardExp = rewardExp;
        }
    }
}
