using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Ironfall_Engine.Events;
using Ironfall_Engine.Actions;

namespace Ironfall_Engine.Models
{
    public class LivingEntity : BaseNotificationClass
    {
        #region Backing Variables
        private string _name { get; set; }
        private int _hpMax { get; set; }
        private int _hpCurrent { get; set; }
        private int _damageMinimum { get; set; }
        private int _damageMaximum { get; set; }
        private int _mpMax { get; set; }
        private int _mpCurrent { get; set; }
        private int _apMax { get; set; }
        private int _apCurrent { get; set; }
        private int _defenceMinimum { get; set; }
        private int _defenceMaximum { get; set; }
        private int _level { get; set; }
        private int _gold { get; set; }
        private string _image { get; set; }
        private ItemSlot _gear { get; set; }
        private BasicAction _basicAction { get; set; }
        #endregion

        #region Variables
        //Properties
        public string Name
        {
            get { return _name; }
            private set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public int HpMax
        {
            get { return _hpMax; }
            private set
            {
                _hpMax = value;
                OnPropertyChanged();
            }
        }
        public int HpCurrent
        {
            get { return _hpCurrent; }
            private set
            {
                _hpCurrent = value;
                OnPropertyChanged();
            }
        }
        public int DamageMinimum
        {
            get { return _damageMinimum; }
            set
            {
                _damageMinimum = value;
                OnPropertyChanged();
            }
        }
        public int DamageMaximum
        {
            get { return _damageMaximum; }
            set
            {
                _damageMaximum = value;
                OnPropertyChanged();
            }
        }
        public int MpMax
        {
            get { return _mpMax; }
            private set
            {
                _mpMax = value;
                OnPropertyChanged();
            }
        }
        public int MpCurrent
        {
            get { return _mpCurrent; }
            private set
            {
                _mpCurrent = value;
                OnPropertyChanged();
            }
        }
        public int ApMax
        {
            get { return _apMax; }
            private set
            {
                _apMax = value;
                OnPropertyChanged();
            }
        }
        public int ApCurrent
        {
            get { return _apCurrent; }
            private set
            {
                _apCurrent = value;
                OnPropertyChanged();
            }
        }
        public int DefenceMinimum
        {
            get { return _defenceMinimum; }
            private set
            {
                _defenceMinimum = value;
                OnPropertyChanged();
            }
        }
        public int DefenceMaximum
        {
            get { return _defenceMaximum; }
            private set
            {
                _defenceMaximum = value;
                OnPropertyChanged();
            }
        }
        public int Level
        {
            get { return _level; }
            private set
            {
                _level = value;
                OnPropertyChanged();
            }
        }
        public int Gold
        {
            get { return _gold; }
            private set
            {
                _gold = value;
                OnPropertyChanged();
            }
        }
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }
        public ItemSlot Gear
        {
            get { return _gear; }
            private set
            {
                _gear = value;
                OnPropertyChanged();
            }
        }
        public BasicAction BasicAction 
        {
            get { return _basicAction; } 
            set 
            {
                if (_basicAction != null)
                {
                    _basicAction.OnActionPerformed -= RaiseOnActionPerformedEvent;
                }

                _basicAction = value;

                if(_basicAction != null)
                {
                    _basicAction.OnActionPerformed += RaiseOnActionPerformedEvent;
                }
                OnPropertyChanged();
            }
        }

        public bool IsDead => HpCurrent <= 0;
        #endregion

        #region Events
        //Events
        public event EventHandler OnKilled;
        public event EventHandler<string> OnActionPerformed;
        #endregion

        protected LivingEntity(string name, string image, int hpMax, int hpCurrent, int damageMinimum, int damageMaximum, int mpMax, int mpCurrent, int apMax, int apCurrent, int defenceMinimum, int defenceMaximum, int level, int gold, ItemSlot gear, BasicAction basicAction)
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
            Gear = gear;
            BasicAction = basicAction;
        }

        //Basic functions
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

        //Use Actions
        public void UseAttackAction(LivingEntity target)
        {
            BasicAction.AttackAction(this, target);
        }
        
        //Events
        private void RaiseOnKilledEvent()
        {
            OnKilled?.Invoke(this, new System.EventArgs());
        }
        private void RaiseOnActionPerformedEvent(object sender, string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
    }
}
