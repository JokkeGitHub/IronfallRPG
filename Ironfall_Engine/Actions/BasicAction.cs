using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Models;
using Ironfall_Engine.Models.Item;

namespace Ironfall_Engine.Actions
{
    public class BasicAction
    {
        public event EventHandler<string> OnActionPerformed;

        //THIS NEEDS TO BE REWORKED!!!
        /*public Attack(GameItem weapon, int minDamage, int maxDamage)
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
        */

        public BasicAction() { }
        public void AttackAction(LivingEntity actor, LivingEntity target)
        {
            int basicDamage = RNG.NumberBetween(actor.DamageMinimum, actor.DamageMaximum);
            int damageOutput = basicDamage + RNG.NumberBetween(actor.Gear.MainHand.MinDamage, actor.Gear.MainHand.MaxDamage);
            int defence = RNG.NumberBetween(target.DefenceMinimum, target.DefenceMaximum);
            int damage = damageOutput - defence;

            string actorName = (actor is LocalPlayer) ? "You" : $"The {actor.Name}";
            string targetName = (target is LocalPlayer) ? "you" : $"the {target.Name}";

            if (damage == 0)
            {
                ReportResult($"{actorName} missed {targetName}.");
            }
            else
            {
                ReportResult($"{actorName} hit {targetName} for {damage} point{(damage > 1 ? "s" : "")}.");

                target.TakeDamage(damage);
            }
        }

        private void ReportResult(string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
    }
}
