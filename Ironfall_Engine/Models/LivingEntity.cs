using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Ironfall_Engine.Models
{
    public class LivingEntity
    {

        public string Name { get; set; }
        public int HpMax { get; set; }
        public int HpCurrent { get; set; }
        public int DamageMinimum { get; set; }
        public int DamageMaximum { get; set; }
        public int MpMax { get; set; }
        public int MpCurrent { get; set; }
        public int ApMax { get; set; }
        public int ApCurrent { get; set; }
        public int DefenceMinimum { get; set; }
        public int DefenceMaximum { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public string Image { get; set; }

        public bool IsDead => HpCurrent <= 0;

        //Events
        public event EventHandler OnKilled;
        public event EventHandler<string> OnActionPerformed;


        protected LivingEntity(string name, string image, int hpMax, int hpCurrent, int damageMinimum, int damageMaximum, int mpMax, int mpCurrent, int apMax, int apCurrent, int defenceMinimum, int defenceMaximum, int level, int gold)
        {
            Name = name;
            Image = image;
            HpMax = hpMax;
            HpCurrent = hpCurrent;
            DamageMinimum = damageMinimum;
            DamageMaximum = damageMaximum;
            MpMax = mpMax;
            MpCurrent = mpCurrent;
            ApMax = apMax;
            ApCurrent = apCurrent;
            DefenceMinimum = defenceMinimum;
            DefenceMaximum = defenceMaximum;
            Level = level;
            Gold = gold;
        }

        // Basic functions

        public void TakeDamage(int pointsOfDamage)
        {
            HpCurrent -= pointsOfDamage;

            if (IsDead)
            {
                HpCurrent = 0;
                RaiseOnKilledEvent();
            }
        }
        public void Heal(int pointsToHeal)
        {
            HpCurrent += pointsToHeal;
            if (HpCurrent > HpMax)
            {
                HpCurrent = HpMax;
            }
        }

        public void UseAttackAction(LivingEntity target)
        {
            
        }
        
        private void RaiseOnKilledEvent()
        {
            OnKilled?.Invoke(this, new System.EventArgs());
        }
        private void RaiseOnActionPerfomedEvent(object sender, string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
    }
}
