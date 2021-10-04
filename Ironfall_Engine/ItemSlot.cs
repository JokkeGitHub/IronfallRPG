﻿using Ironfall_Engine.Enums;
using Ironfall_Engine.Models.Item;
using Ironfall_Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Events;
using Ironfall_Engine.Models;
using Ironfall_Engine.Factories.Item;

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

        // Make a unequip method. Call this method every time equipping and slot != empty 

        #region EQUIP ITEMS

        public string EquipWeapon(LocalPlayer currentPlayer, Weapon weapon)
        {
            switch (weapon.WeaponType)
            {
                case ItemEnum.Weapon.OneHanded:
                    currentPlayer.Gear.MainHand = weapon;
                    break;

                case ItemEnum.Weapon.Shield:
                    currentPlayer.Gear.OffHand = weapon;
                    break;

                case ItemEnum.Weapon.Ranged:
                    currentPlayer.Gear.MainHand = weapon;
                    currentPlayer.Gear.OffHand = weapon;
                    break;

                case ItemEnum.Weapon.TwoHanded:
                    currentPlayer.Gear.MainHand = weapon;
                    currentPlayer.Gear.OffHand = weapon;
                    break;

                default:
                    break;
            }
            return weapon.Name;
        }

        public string EquipArmor(LocalPlayer currentPlayer, Armor armor)
        {
            currentPlayer.Gear.Chest = armor;
            return armor.Name;
        }

        public string EquipArtifact(LocalPlayer currentPlayer, Artifact artifact)
        {
            switch (artifact.ArtifactType)
            {
                case ItemEnum.Artifact.Head:
                    currentPlayer.Gear.Head = artifact;
                    break;

                case ItemEnum.Artifact.Neck:
                    currentPlayer.Gear.Neck = artifact;
                    break;

                case ItemEnum.Artifact.Finger:
                    currentPlayer.Gear.FingerRight = artifact;

                    // Do something

                    break;

                case ItemEnum.Artifact.Feet:
                    currentPlayer.Gear.Feet = artifact;
                    break;

                default:
                    break;
            }
            return artifact.Name;
        }

        #endregion

        #region UNEQUIP ITEMS

        public string UnequipWeapon(LocalPlayer currentPlayer, Weapon weapon)
        {
            WeaponFactory weaponFactory = new WeaponFactory();

            switch (weapon.WeaponType)
            {
                case ItemEnum.Weapon.OneHanded:
                    currentPlayer.Gear.MainHand = weaponFactory.GetEmptyMainHand();
                    break;

                case ItemEnum.Weapon.Shield:
                    currentPlayer.Gear.OffHand = weaponFactory.GetEmptyOffHand();
                    break;

                case ItemEnum.Weapon.Ranged:
                    currentPlayer.Gear.MainHand = weaponFactory.GetEmptyMainHand();
                    currentPlayer.Gear.OffHand = weaponFactory.GetEmptyOffHand();
                    break;

                case ItemEnum.Weapon.TwoHanded:
                    currentPlayer.Gear.MainHand = weaponFactory.GetEmptyMainHand();
                    currentPlayer.Gear.OffHand = weaponFactory.GetEmptyOffHand();
                    break;

                default:
                    break;
            }
            return weapon.Name;
        }

        public string UnequipArmor(LocalPlayer currentPlayer, Armor armor)
        {
            ArmorFactory armorFactory = new ArmorFactory();

            currentPlayer.Gear.Chest = armorFactory.GetEmptyChest();
            return armor.Name;
        }

        public string UnequipArtifact(LocalPlayer currentPlayer, Artifact artifact)
        {
            ArtifactFactory artifactFactory = new ArtifactFactory();

            switch (artifact.ArtifactType)
            {
                case ItemEnum.Artifact.Head:
                    currentPlayer.Gear.Head = artifactFactory.GetEmptyHead();
                    break;

                case ItemEnum.Artifact.Neck:
                    currentPlayer.Gear.Neck = artifactFactory.GetEmptyNeck();
                    break;

                case ItemEnum.Artifact.Finger:
                    currentPlayer.Gear.FingerRight = artifactFactory.GetEmptyFingerRight();
                    // DO something
                    break;

                case ItemEnum.Artifact.Feet:
                    currentPlayer.Gear.Feet = artifactFactory.GetEmptyFeet();
                    break;

                default:
                    break;
            }
            return artifact.Name;
        }

        #endregion
    }
}
