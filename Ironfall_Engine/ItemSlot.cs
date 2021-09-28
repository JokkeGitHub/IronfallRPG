using Ironfall_Engine.Enums;
using Ironfall_Engine.Models.Item;
using Ironfall_Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Events;

namespace Ironfall_Engine
{
    public class ItemSlot : BaseNotificationClass
    {
        //Changed so that there is no right og left hand, but main and offhand. 
        private Weapon _mainHand;
        
        public Weapon MainHand
        {
            get { return _mainHand; }
            set
            {
                _mainHand = value;
                OnPropertyChanged();
            }
        }

        public Weapon OffHand { get; set; }
        public Armor Chest { get; set; }
        public Artifact Head { get; set; }
        public Artifact Neck { get; set; }
        public Artifact FingerRight { get; set; }
        public Artifact FingerLeft { get; set; }
        public Artifact Feet { get; set; }

        public ItemSlot(Weapon mainHand, Weapon offHand, Armor chest, Artifact head, Artifact neck, Artifact fingerRight, Artifact fingerLeft, Artifact feet)
        {
            MainHand = mainHand;
            OffHand = offHand;
            Chest = chest;
            Head = head;
            Neck = neck;
            FingerRight = fingerRight;
            FingerLeft = fingerLeft;
            Feet = feet;
        }

        public void EquipHandMain(Weapon weapon)
        {
            if (weapon.WeaponType is ItemEnum.Weapon.TwoHanded)
            {
                MainHand = weapon;
                OffHand = weapon;
            }
            else
            {
                MainHand = weapon;
            }
        }
    }
}
