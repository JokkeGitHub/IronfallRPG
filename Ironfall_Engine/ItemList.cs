using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Factories.Item;
using Ironfall_Engine.Models.Item;
using Ironfall_Engine.Enums;

namespace Ironfall_Engine
{
    public class ItemList
    {
        public static Weapon mainHand = new Weapon(-1, "Right Hand", "Unarmed", 0, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 0, 0);
        public static Weapon offHand = new Weapon(-1, "Left Hand", "Unarmed", 0, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 0, 0);
        public static Armor chest = new Armor(-1, "Chest", "Unarmored", 0, false, GameItem.ItemCategory.Armor, ItemEnum.Armor.Light, 0, 0);
        public Artifact head = new Artifact(-1, "Head", "Unarmored", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Head);
        public Artifact neck = new Artifact(-1, "Neck", "Unarmored", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Neck);
        public Artifact feet = new Artifact(-1, "Feet", "Unarmored", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Feet);
        public Artifact fingerRight = new Artifact(-1, "Right Finger", "Unarmored", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
        public Artifact fingerLeft = new Artifact(-1, "Left Finger", "Unarmored", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);

        public Weapon testWeapon = new WeaponFactory().Create("Developers Axe", "Forged in the code of the Architects.", 100, true, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 1, 5);
    }
}
