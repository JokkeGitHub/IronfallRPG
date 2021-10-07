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
                // Name, Image, HpCurrent, HpMax, StatBody, StatSpirit, StatFellowship, DamageMin, DamageMax, MpCurrent, MpMax, ApCurrent, ApMax, DefenceMin, DefenceMax, Level, Gold, Type, Suptype, Description, RewardExp.
                case 1:
                    Monster thief = new Monster("Thief", "thief.jpg", 4, 4, 1,1,1, 1, 2, 0, 0, 2, 2, 1, 1, 1, 2, "Human", "Rogue", "This back alley thief wants your money and your life", 5);
                    thief.Heal(10);
                    thief.AddItemToInventory(itemsInGame.woodenRune);
                    return thief;

                default:
                    throw new ArgumentException(string.Format("Can't find requested monster"));
            }
        }
    }
}