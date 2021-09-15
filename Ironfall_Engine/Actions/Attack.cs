using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Models.Item;
using Ironfall_Engine.Enums;

namespace Ironfall_Engine.Actions
{
    class Attack
    {
        private readonly GameItem _weapon;
        int _damageOutput;
        int _minDamage;
        int _maxDamage;

        public Attack(GameItem weapon, int minDamage, int maxDamage)
        {
            if (weapon.Category != GameItem.ItemCategory.Weapon)
            {
                throw new ArgumentException($"{weapon.Name} is not a weapon");
            }
            if (_minDamage < 0)
            {
                throw new ArgumentException($"minimumDamage must be at least 0");

            }
            if (_maxDamage < _minDamage)
            {
                throw new ArgumentException($"maximumDamage must be bigger than minimumDamage");
            }

            _weapon = weapon;
            _minDamage = minDamage;
            _maxDamage = maxDamage;
        }
    }
}
