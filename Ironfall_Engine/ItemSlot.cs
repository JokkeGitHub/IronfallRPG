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
        private Weapon _offHand;
        private Armor _chest;
        private Artifact _head;
        private Artifact _neck;
        private Artifact _fingerRight;
        private Artifact _fingerLeft;
        private Artifact _feet;
        
        public Weapon MainHand
        {
            get { return _mainHand; }
            set
            {
                _mainHand = value;
                OnPropertyChanged();
            }
        }

        public Weapon OffHand
        {
            get { return _offHand; }
            set
            {
                _offHand = value;
                OnPropertyChanged();
            }
        }
        public Armor Chest
        {
            get { return _chest; }
            set
            {
                _chest = value;
                OnPropertyChanged();
            }
        }
        public Artifact Head
        {
            get { return _head; }
            set
            {
                _head = value;
                OnPropertyChanged();
            }
        }
        public Artifact Neck
        {
            get { return _neck; }
            set
            {
                _neck = value;
                OnPropertyChanged();
            }
        }
        public Artifact FingerRight
        {
            get { return _fingerRight; }
            set
            {
                _fingerRight = value;
                OnPropertyChanged();
            }
        }
        public Artifact FingerLeft
        {
            get { return _fingerLeft; }
            set
            {
                _fingerLeft = value;
                OnPropertyChanged();
            }
        }
        public Artifact Feet
        {
            get { return _feet; }
            set
            {
                _feet = value;
                OnPropertyChanged();
            }
        }

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
