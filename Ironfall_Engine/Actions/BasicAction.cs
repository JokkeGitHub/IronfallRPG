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

        private void ReportResult(string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
    }
}
