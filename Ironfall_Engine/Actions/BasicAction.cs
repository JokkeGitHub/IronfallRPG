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
        public void AttackAction(LivingEntity actor, LivingEntity target)
        {
            int basicDamage = RNG.NumberBetween(actor.DamageMinimum, actor.DamageMaximum);
            int damageOutput = basicDamage + RNG.NumberBetween(actor.Gear.MainHand.MinDamage, actor.Gear.MainHand.MaxDamage);
            int defence = RNG.NumberBetween(target.DefenceMinimum, target.DefenceMaximum);
            int damage = damageOutput - defence;

            string actorName = (actor is LocalPlayer) ? "You" : $"The {actor.Name}";
            string targetName = (target is LocalPlayer) ? "you" : $"the {target.Name}";

            if (damage <= 0)
            {
                ReportResult($"{actorName} missed {targetName}.");
            }
            else
            {
                ReportResult($"{actorName} hit {targetName} for {damage} point{(damage > 1 ? "s" : "")}.");

                target.TakeDamage(damage);
            }
        }

        public void UseConsumable(LivingEntity actor, Consumable item)
        {
            int consumableOutput = RNG.NumberBetween(item.MinEffect, item.MaxEffect);

            string actorName = (actor is LocalPlayer) ? "You" : $"The {actor.Name}";

            if (consumableOutput <= 0)
            {
                ReportResult($"{item.Name} had no effect on {actorName}");
            }
            else
            {
                string resource = DetermineType(actor, item.Name, consumableOutput);
                ReportResult($"{item.Name} restored {consumableOutput} point{(consumableOutput > 1 ? "s" : "")} of {resource} for {actorName}.");
            }

            actor.RemoveItemFromInventory(item);
        }

        string DetermineType(LivingEntity actor, string itemName, int consumableOutput)
        {
            string resource = "";

            if (itemName.Contains("Health"))
            {
                actor.RestoreHealthPoints(consumableOutput);
                resource = "HP";
            }
            else if (itemName.Contains("Mana"))
            {
                actor.RestoreManaPoints(consumableOutput);
                resource = "MP";
            }
            else if (itemName.Contains("Ability"))
            {
                actor.RestoreAbilityPoints(consumableOutput);
                resource = "AP";
            }
            return resource;
        }

        private void ReportResult(string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
    }
}
