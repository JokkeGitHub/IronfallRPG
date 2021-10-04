using System;
using Ironfall_Engine.Models;
using Ironfall_Engine.Actions;
using Ironfall_Engine.Models.Item;
using System.Collections.ObjectModel;

namespace Ironfall_Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int monsterID)
        {
            ItemList itemsInGame = new ItemList();
            switch (monsterID)
            {
                // Name, Image, HpCurrent, HpMax, DamageMin, DamageMax, MpCurrent, MpMax, ApCurrent, ApMax, DefenceMin, DefenceMax, Level, Gold, Type, Suptype, Description, RewardExp.
                case 1:
                    ItemSlot gear = new ItemSlot(
                        new Models.Item.Weapon(-1, "Right Hand", "Unarmed", 0, false, Models.Item.GameItem.ItemCategory.Weapon, Enums.ItemEnum.Weapon.OneHanded, 0, 0),
                        new Models.Item.Weapon(-1, "Left Hand", "Unarmed", 0, false, Models.Item.GameItem.ItemCategory.Weapon, Enums.ItemEnum.Weapon.OneHanded, 0, 0),
                        new Models.Item.Armor(-1, "Chest", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Armor, Enums.ItemEnum.Armor.Light, 0, 0),
                        new Models.Item.Artifact(-1, "Head", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Head),
                        new Models.Item.Artifact(-1, "Neck", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Neck),
                        new Models.Item.Artifact(-1, "Feet", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Feet),
                        new Models.Item.Artifact(-1, "Right Finger", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Finger),
                        new Models.Item.Artifact(-1, "Left Finger", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Finger));

                    BasicAction basicAction = new BasicAction();
                    ObservableCollection<GameItem> inventory = new ObservableCollection<GameItem>();
                    inventory.Add(itemsInGame.testWeapon);

                    Monster thief = new Monster("Thief", "thief.jpg", 5, 5, 1, 2, 0, 0, 2, 2, 1, 2, 1, 2, "Human", "Rogue", "This back alley thief wants your money and your life", 5, inventory, gear, basicAction);
                    return thief;

                default:
                    throw new ArgumentException(string.Format("Can't find requested monster"));
            }
        }
    }
}