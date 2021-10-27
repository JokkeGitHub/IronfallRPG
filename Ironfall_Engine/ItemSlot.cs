using Ironfall_Engine.Enums;
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
        private Artifact _head;
        private Artifact _neck;
        private Armor _chest;
        private Weapon _mainHand;
        private Weapon _offHand;
        private Artifact _fingerRight;
        private Artifact _fingerLeft;
        private Artifact _feet;

        #region ENCAPSULATIONS
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

        public Armor Chest
        {
            get { return _chest; }
            set
            {
                _chest = value;
                OnPropertyChanged();
            }
        }

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
        #endregion

        public ItemSlot(Artifact head, Artifact neck, Armor chest, Weapon mainHand, Weapon offHand, Artifact fingerRight, Artifact fingerLeft, Artifact feet)
        {
            Head = head;
            Neck = neck;
            Chest = chest;
            MainHand = mainHand;
            OffHand = offHand;
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
                    EquipMainHand(currentPlayer, weapon);
                    break;

                case ItemEnum.Weapon.Shield:
                    EquipOffHand(currentPlayer, weapon);
                    break;

                case ItemEnum.Weapon.Ranged:
                    EquipBothHands(currentPlayer, weapon);
                    break;

                case ItemEnum.Weapon.TwoHanded:
                    EquipBothHands(currentPlayer, weapon);
                    break;

                default:
                    break;
            }
            currentPlayer.RemoveItemFromInventory(weapon);

            return weapon.Name;
        }

        #region CHECKING WEAPON SLOTS
        public void EquipMainHand(LocalPlayer currentPlayer, Weapon weapon)
        {
            WeaponFactory weaponFactory = new WeaponFactory();

            if (currentPlayer.Gear.MainHand.WeaponType is ItemEnum.Weapon.TwoHanded || currentPlayer.Gear.MainHand.WeaponType is ItemEnum.Weapon.Ranged)
            {
                currentPlayer.Gear.OffHand = weaponFactory.GetEmptyOffHand();
            }

            if (currentPlayer.Gear.MainHand.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(currentPlayer.Gear.MainHand);
            }
            currentPlayer.Gear.MainHand = weapon;
        }

        public void EquipOffHand(LocalPlayer currentPlayer, Weapon weapon)
        {
            WeaponFactory weaponFactory = new WeaponFactory();

            if (currentPlayer.Gear.MainHand.WeaponType is ItemEnum.Weapon.TwoHanded || currentPlayer.Gear.MainHand.WeaponType is ItemEnum.Weapon.Ranged)
            {
                currentPlayer.Gear.MainHand = weaponFactory.GetEmptyMainHand();
            }

            if (currentPlayer.Gear.OffHand.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(currentPlayer.Gear.OffHand);
            }
            currentPlayer.Gear.OffHand = weapon;
        }

        public void EquipBothHands(LocalPlayer currentPlayer, Weapon weapon)
        {
            WeaponFactory weaponFactory = new WeaponFactory();

            if (currentPlayer.Gear.MainHand.WeaponType is ItemEnum.Weapon.TwoHanded || currentPlayer.Gear.MainHand.WeaponType is ItemEnum.Weapon.Ranged)
            {
                currentPlayer.Gear.OffHand = weaponFactory.GetEmptyOffHand();
            }

            if (currentPlayer.Gear.MainHand.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(currentPlayer.Gear.MainHand);
            }

            if (currentPlayer.Gear.OffHand.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(currentPlayer.Gear.OffHand);
            }

            currentPlayer.Gear.MainHand = weapon;
            currentPlayer.Gear.OffHand = weapon;
        }

        #endregion

        public string EquipArmor(LocalPlayer currentPlayer, Armor armor)
        {
            if (currentPlayer.Gear.Chest.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(currentPlayer.Gear.Chest);
            }
            currentPlayer.Gear.Chest = armor;
            currentPlayer.RemoveItemFromInventory(armor);
            return armor.Name;
        }

        public string EquipArtifact(LocalPlayer currentPlayer, Artifact artifact)
        {
            switch (artifact.ArtifactType)
            {
                case ItemEnum.Artifact.Head:
                    EquipHead(currentPlayer, artifact);
                    break;

                case ItemEnum.Artifact.Neck:
                    EquipNeck(currentPlayer, artifact);
                    break;

                case ItemEnum.Artifact.Finger:
                    EquipFinger(currentPlayer, artifact);
                    break;

                case ItemEnum.Artifact.Feet:
                    EquipFeet(currentPlayer, artifact);
                    break;

                default:
                    break;
            }
            currentPlayer.RemoveItemFromInventory(artifact);

            return artifact.Name;
        }

        #region CHECKING ARTIFACT SLOTS
        public void EquipHead(LocalPlayer currentPlayer, Artifact artifact)
        {
            if (currentPlayer.Gear.Head.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(currentPlayer.Gear.Head);
            }
            currentPlayer.Gear.Head = artifact;
        }

        public void EquipNeck(LocalPlayer currentPlayer, Artifact artifact)
        {
            if (currentPlayer.Gear.Neck.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(currentPlayer.Gear.Neck);
            }
            currentPlayer.Gear.Neck = artifact;
        }

        public void EquipFinger(LocalPlayer currentPlayer, Artifact artifact)
        {
            if (currentPlayer.Gear.FingerRight.Name == "Empty")
            {
                currentPlayer.Gear.FingerRight = artifact;
            }
            else if (currentPlayer.Gear.FingerLeft.Name == "Empty")
            {
                currentPlayer.Gear.FingerLeft = artifact;
            }
            else
            {
                currentPlayer.AddItemToInventory(currentPlayer.Gear.FingerRight);
                currentPlayer.Gear.FingerRight = artifact;
            }
        }

        public void EquipFeet(LocalPlayer currentPlayer, Artifact artifact)
        {
            if (currentPlayer.Gear.Feet.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(currentPlayer.Gear.Feet);
            }
            currentPlayer.Gear.Feet = artifact;
        }
        #endregion
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

            if (weapon.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(weapon);
            }

            return weapon.Name;
        }

        public string UnequipArmor(LocalPlayer currentPlayer, Armor armor)
        {
            ArmorFactory armorFactory = new ArmorFactory();

            currentPlayer.Gear.Chest = armorFactory.GetEmptyChest();

            if (armor.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(armor);
            }

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
                    UnequipFinger(currentPlayer, artifact);
                    break;

                case ItemEnum.Artifact.Feet:
                    currentPlayer.Gear.Feet = artifactFactory.GetEmptyFeet();
                    break;

                default:
                    break;
            }

            if (artifact.Name != "Empty")
            {
                currentPlayer.AddItemToInventory(artifact);
            }

            return artifact.Name;
        }
        public void UnequipFinger(LocalPlayer currentPlayer, Artifact artifact)
        {
            ArtifactFactory artifactFactory = new ArtifactFactory();

            if (currentPlayer.Gear.FingerRight == artifact)
            {
                currentPlayer.Gear.FingerRight = artifactFactory.GetEmptyFingerRight();
            }
            else if (currentPlayer.Gear.FingerLeft == artifact)
            {
                currentPlayer.Gear.FingerLeft = artifactFactory.GetEmptyFingerLeft();
            }
        }

        #endregion

        #region ITEM INFO
        public string InfoWeapon(LocalPlayer currentPlayer, Weapon weapon)
        {
            string weaponInfo = "";

            switch (weapon.WeaponType)
            {
                case ItemEnum.Weapon.OneHanded:
                    weaponInfo = "Weapon Type: " + currentPlayer.Gear.MainHand.WeaponType.ToString();
                    weaponInfo += "\nUnique: " + currentPlayer.Gear.MainHand.IsUnique.ToString();
                    weaponInfo += "\nWeapon Name: " + currentPlayer.Gear.MainHand.Name;
                    weaponInfo += "\nDescription: " + currentPlayer.Gear.MainHand.Description;
                    weaponInfo += $"\nDamage: {currentPlayer.Gear.MainHand.MinDamage} - {currentPlayer.Gear.MainHand.MaxDamage}";
                    break;

                case ItemEnum.Weapon.Shield:
                    weaponInfo = "Weapon Type: " + currentPlayer.Gear.OffHand.WeaponType.ToString();
                    weaponInfo += "\nUnique: " + currentPlayer.Gear.OffHand.IsUnique.ToString();
                    weaponInfo += "\nWeapon Name: " + currentPlayer.Gear.OffHand.Name;
                    weaponInfo += "\nDescription: " + currentPlayer.Gear.OffHand.Description;
                    break;

                case ItemEnum.Weapon.Ranged:
                    weaponInfo = "Weapon Type: " + currentPlayer.Gear.MainHand.WeaponType.ToString();
                    weaponInfo += "\nUnique: " + currentPlayer.Gear.MainHand.IsUnique.ToString();
                    weaponInfo += "\nWeapon Name: " + currentPlayer.Gear.MainHand.Name;
                    weaponInfo += "\nDescription: " + currentPlayer.Gear.MainHand.Description;
                    weaponInfo += $"\nDamage: {currentPlayer.Gear.MainHand.MinDamage} - {currentPlayer.Gear.MainHand.MaxDamage}";
                    break;

                case ItemEnum.Weapon.TwoHanded:
                    weaponInfo = "Weapon Type: " + currentPlayer.Gear.MainHand.WeaponType.ToString();
                    weaponInfo += "\nUnique: " + currentPlayer.Gear.MainHand.IsUnique.ToString();
                    weaponInfo += "\nWeapon Name: " + currentPlayer.Gear.MainHand.Name;
                    weaponInfo += "\nDescription: " + currentPlayer.Gear.MainHand.Description;
                    weaponInfo += $"\nDamage: {currentPlayer.Gear.MainHand.MinDamage} - {currentPlayer.Gear.MainHand.MaxDamage}";
                    break;

                default:
                    break;
            }

            return weaponInfo;
        }

        public string InfoArmor(LocalPlayer currentPlayer, Armor armor)
        {
            string armorInfo = "Armor Type: " + currentPlayer.Gear.Chest.ArmorType.ToString();
            armorInfo += "\nUnique: " + currentPlayer.Gear.Chest.IsUnique.ToString();
            armorInfo += "\nArmor Name: " + currentPlayer.Gear.Chest.Name;
            armorInfo += "\nDescription: " + currentPlayer.Gear.Chest.Description;
            armorInfo += $"\nDefense: {currentPlayer.Gear.Chest.MinDefense} - {currentPlayer.Gear.Chest.MaxDefense}";

            return armorInfo;
        }

        public string InfoArtifact(LocalPlayer currentPlayer, Artifact artifact)
        {
            string artifactInfo = "";

            switch (artifact.ArtifactType)
            {
                case ItemEnum.Artifact.Head:
                    artifactInfo = "Artifact Type: " + currentPlayer.Gear.Head.ArtifactType.ToString();
                    artifactInfo += "\nUnique: " + currentPlayer.Gear.Head.IsUnique.ToString();
                    artifactInfo += "\nArtifact Name: " + currentPlayer.Gear.Head.Name;
                    artifactInfo += "\nDescription: " + currentPlayer.Gear.Head.Description;
                    break;

                case ItemEnum.Artifact.Neck:
                    artifactInfo = "Artifact Type: " + currentPlayer.Gear.Neck.ArtifactType.ToString();
                    artifactInfo += "\nUnique: " + currentPlayer.Gear.Neck.IsUnique.ToString();
                    artifactInfo += "\nArtifact Name: " + currentPlayer.Gear.Neck.Name;
                    artifactInfo += "\nDescription: " + currentPlayer.Gear.Neck.Description;
                    break;

                case ItemEnum.Artifact.Finger:
                    artifactInfo = InfoFinger(currentPlayer, artifact);
                    break;

                case ItemEnum.Artifact.Feet:
                    artifactInfo = "Artifact Type: " + currentPlayer.Gear.Feet.ArtifactType.ToString();
                    artifactInfo += "\nUnique: " + currentPlayer.Gear.Feet.IsUnique.ToString();
                    artifactInfo += "\nArtifact Name: " + currentPlayer.Gear.Feet.Name;
                    artifactInfo += "\nDescription: " + currentPlayer.Gear.Feet.Description;
                    break;

                default:
                    break;
            }
            return artifactInfo;
        }

        public string InfoFinger(LocalPlayer currentPlayer, Artifact artifact)
        {
            string artifactInfo = "";

            if (artifact.Name == currentPlayer.Gear.FingerRight.Name)
            {
                artifactInfo = "Artifact Type: " + currentPlayer.Gear.FingerRight.ArtifactType.ToString();
                artifactInfo += "\nUnique: " + currentPlayer.Gear.FingerRight.IsUnique.ToString();
                artifactInfo += "\nArtifact Name: " + currentPlayer.Gear.FingerRight.Name;
                artifactInfo += "\nDescription: " + currentPlayer.Gear.FingerRight.Description;
            }
            else if (artifact.Name == currentPlayer.Gear.FingerLeft.Name)
            {
                artifactInfo = "Artifact Type: " + currentPlayer.Gear.FingerLeft.ArtifactType.ToString();
                artifactInfo += "\nUnique: " + currentPlayer.Gear.FingerLeft.IsUnique.ToString();
                artifactInfo += "\nArtifact Name: " + currentPlayer.Gear.FingerLeft.Name;
                artifactInfo += "\nDescription: " + currentPlayer.Gear.FingerLeft.Description;
            }

            return artifactInfo;
        }

        #endregion
    }
}
