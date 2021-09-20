using Ironfall_Engine.Enums;
using Ironfall_Engine.Models.Item;
using Ironfall_Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine
{
    public class ItemSlot
    {
        public Weapon HandRight { get; set; }
        public Weapon HandLeft { get; set; }
        public Armor Chest { get; set; }
        public Artifact Head { get; set; }
        public Artifact Feet { get; set; }
        public Artifact Neck { get; set; }
        public Artifact FingerRight { get; set; }
        public Artifact FingerLeft { get; set; }

        public ItemSlot(Weapon handRight, Weapon handLeft, Armor chest, Artifact head, Artifact feet, Artifact neck, Artifact fingerRight, Artifact fingerLeft)
        {
            HandRight = handRight;
            HandLeft = handLeft;
            Chest = chest;
            Head = head;
            Feet = feet;
            Neck = neck;
            FingerRight = fingerRight;
            FingerLeft = fingerLeft;
        }

        public void EquipHandRight(Weapon weapon)
        {
            if (weapon.WeaponType is ItemEnum.Weapon.TwoHanded)
            {
                HandRight = weapon;
                HandLeft = weapon;
            }
            else
            {
                HandRight = weapon;
            }
        }
    }
}
