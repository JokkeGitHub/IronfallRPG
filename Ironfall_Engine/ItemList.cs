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
        #region EMPTY GEAR SLOTS
        public static Weapon mainHand = new Weapon(-1, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 0, 0);
        public static Weapon offHand = new Weapon(-1, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 0, 0);
        public static Armor chest = new Armor(-1, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Armor, ItemEnum.Armor.Light, 0, 0);
        public static Artifact head = new Artifact(-1, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Head);
        public static Artifact neck = new Artifact(-1, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Neck);
        public static Artifact feet = new Artifact(-1, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Feet);
        public static Artifact fingerRight = new Artifact(-1, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
        public static Artifact fingerLeft = new Artifact(-1, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
        #endregion

        public Weapon testWeapon = new WeaponFactory().Create("Developers Axe", "Forged in the code of the Architects.", 100, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 1, 5);


        #region CONSUMABLES
        public Consumable healthPotionMinor = new ConsumableFactory().Create("Minor Health Potion", "This item heals your HP.", 10, false, GameItem.ItemCategory.Consumable, ItemEnum.Consumable.Potion, 1, 3);
        public Consumable manaPotionMinor = new ConsumableFactory().Create("Minor Mana Potion", "This item heals your MP.", 10, false, GameItem.ItemCategory.Consumable, ItemEnum.Consumable.Potion, 1, 3);
        public Consumable abilityPotionMinor = new ConsumableFactory().Create("Minor Ability Potion", "This item heals your AP.", 10, false, GameItem.ItemCategory.Consumable, ItemEnum.Consumable.Potion, 1, 3);
        #endregion

        #region COMMON ITEMS
        public Common woodenRune = new CommonFactory().Create(401, "Wooden Rune", "Small rune for luck", 2, false, GameItem.ItemCategory.Common, ItemEnum.Common.Trash);
        #endregion

        #region TRINKETS
        public Trinket strangeOrb = new TrinketFactory().Create(5001, "Strange Black Orb", "This black orb is like starring into the abyss", 50, true, GameItem.ItemCategory.Trinket, ItemEnum.Trinket.Magical);
        #endregion
    }
}
