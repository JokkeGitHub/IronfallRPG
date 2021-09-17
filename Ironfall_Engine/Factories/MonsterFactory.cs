﻿using Ironfall_Engine.Models;
using System;

namespace Ironfall_Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int monsterID)
        {
            switch (monsterID)
            {
                // Name, Image, HpCurrent, HpMax, DamageMin, DamageMax, MpCurrent, MpMax, ApCurrent, ApMax, DefenceMin, DefenceMax, Level, Gold, Type, Suptype, Description, RewardExp.
                case 1:
                    Monster thief = new Monster("Thief", "thief.jpg", 5,5, 1,2, 0,0, 2,2, 1,2, 1, 2, "Human", "Rogue", "This back alley thief wants your money and your life", 5);
                    return thief;

                default:
                    throw new ArgumentException(string.Format("Can't find requested monster"));
            }
        }
    }
}