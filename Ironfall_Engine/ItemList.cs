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
        public static Weapon mainHand = new Weapon(-1, "Empty Right Hand", "Unarmed", 0, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 0, 0);
        public static Weapon offHand = new Weapon(-1, "Empty Left Hand", "Unarmed", 0, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 0, 0);
        public static Armor chest = new Armor(-1, "Empty Chest", "Unarmored", 0, false, GameItem.ItemCategory.Armor, ItemEnum.Armor.Light, 0, 0);
        public static Artifact head = new Artifact(-1, "Empty Head", "Unarmored", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Head);
        public static Artifact neck = new Artifact(-1, "Empty Neck", "Unarmored", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Neck);
        public static Artifact feet = new Artifact(-1, "Empty Feet", "Unarmored", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Feet);
        public static Artifact fingerRight = new Artifact(-1, "Empty Right Finger", "Unarmored", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
        public static Artifact fingerLeft = new Artifact(-1, "Empty Left Finger", "Unarmored", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);

        public Weapon testWeapon = new WeaponFactory().Create("Developers Axe", "Forged in the code of the Architects.", 100, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 1, 5);
        
        public Common woodenRune = new CommonFactory().Create(401, "Wooden Rune", "Small rune for luck", 2, false, GameItem.ItemCategory.Common, GameItem.ItemCategory.Common);
    }
}
