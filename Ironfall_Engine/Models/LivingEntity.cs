using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Ironfall_Engine.Events;
using Ironfall_Engine.Models.Item;
using Ironfall_Engine.Actions;

namespace Ironfall_Engine.Models
{
    public class LivingEntity : BaseNotificationClass
    {
        #region Backing Variables
        private string _name { get; set; }
        private int _hpMax { get; set; }
        private int _hpCurrent { get; set; }
        private int _statBody { get; set; }
        private int _statSpirit { get; set; }
        private int _statFellowship { get; set; }
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
        private BasicAction _basicAction { get; set; }
        #endregion

        #region Variables
        //Properties
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public int HpMax
        {
            get { return _hpMax; }
            set
            {
                _hpMax = value;
                OnPropertyChanged();
            }
        }
        public int HpCurrent
        {
            get { return _hpCurrent; }
            set
            {
                _hpCurrent = value;
                OnPropertyChanged();
            }
        }
        public int StatBody
        {
            get { return _statBody; }
            set
            {
                _statBody = value;
                OnPropertyChanged();
            }
        }
        public int StatSpirit
        {
            get { return _statSpirit; }
            set
            {
                _statSpirit = value;
                OnPropertyChanged();
            }
        }
        public int StatFellowship
        {
            get { return _statFellowship; }
            set
            {
                _statFellowship = value;
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
            set
            {
                _mpMax = value;
                OnPropertyChanged();
            }
        }
        public int MpCurrent
        {
            get { return _mpCurrent; }
            set
            {
                _mpCurrent = value;
                OnPropertyChanged();
            }
        }
        public int ApMax
        {
            get { return _apMax; }
            set
            {
                _apMax = value;
                OnPropertyChanged();
            }
        }
        public int ApCurrent
        {
            get { return _apCurrent; }
            set
            {
                _apCurrent = value;
                OnPropertyChanged();
            }
        }
        public int DefenceMinimum
        {
            get { return _defenceMinimum; }
            set
            {
                _defenceMinimum = value;
                OnPropertyChanged();
            }
        }
        public int DefenceMaximum
        {
            get { return _defenceMaximum; }
            set
            {
                _defenceMaximum = value;
                OnPropertyChanged();
            }
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged();
            }
        }
        public int Gold
        {
            get { return _gold; }
            set
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
        public ObservableCollection<GameItem> Inventory { get; set; }
        public ObservableCollection<GroupedInventoryItem> GroupedInventory { get; set; }

        public ItemSlot Gear { get; set; }
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

                if (_basicAction != null)
                {
                    _basicAction.OnActionPerformed += RaiseOnActionPerformedEvent;
                }
                OnPropertyChanged();
            }
        }

        public List<GameItem> Weapons => Inventory.Where(i => i.Category == GameItem.ItemCategory.Weapon).ToList();


        public bool IsDead => HpCurrent <= 0;
        #endregion

        #region Events
        //Events
        public event EventHandler OnKilled;
        public event EventHandler<string> OnActionPerformed;
        #endregion

        protected LivingEntity(string name, string image, int hpMax, int hpCurrent, int statBody, int statSpirit, int statFellowship, int damageMinimum, int damageMaximum, int mpMax, int mpCurrent, int apMax, int apCurrent, int defenceMinimum, int defenceMaximum, int level, int gold)
        {
            Name = name;
            Image = image;
            HpMax = hpMax + statBody;
            HpCurrent = hpCurrent;
            StatBody = statBody;
            StatSpirit = statSpirit;
            StatFellowship = statFellowship;
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
            Inventory = new ObservableCollection<GameItem>();
            GroupedInventory = new ObservableCollection<GroupedInventoryItem>();
            Gear = new ItemSlot(ItemList.head, ItemList.neck, ItemList.chest, ItemList.mainHand, ItemList.offHand, ItemList.fingerRight, ItemList.fingerLeft, ItemList.feet);
            BasicAction = new BasicAction();
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
        public void RestoreHealthPoints(int pointsToHeal)
        {
            HpCurrent += pointsToHeal;
            if (HpCurrent > HpMax)
            {
                HpCurrent = HpMax;
            }
        }
        public void RestoreManaPoints(int pointsToHeal)
        {
            MpCurrent += pointsToHeal;
            if (MpCurrent > MpMax)
            {
                MpCurrent = MpMax;
            }
        }
        public void RestoreAbilityPoints(int pointsToHeal)
        {
            ApCurrent += pointsToHeal;
            if (ApCurrent > ApMax)
            {
                ApCurrent = ApMax;
            }
        }

        //Inventory Functions
        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            if (item.IsUnique)
            {
                GroupedInventory.Add(new GroupedInventoryItem(item, 1));
            }
            else if (item.IsUnique == false)
            {

                if (!GroupedInventory.Any(gi => gi.Item.Id == item.Id))
                {
                    GroupedInventory.Add(new GroupedInventoryItem(item, 0));
                }

                GroupedInventory.First(gi => gi.Item.Id == item.Id).Quantity++;
            }
            OnPropertyChanged(nameof(Weapons));
        }
        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);

            GroupedInventoryItem groupedInventoryItemToRemove = item.IsUnique ? GroupedInventory.FirstOrDefault(gi => gi.Item == item) : GroupedInventory.FirstOrDefault(gi => gi.Item.Id == item.Id);

            if (groupedInventoryItemToRemove != null)
            {
                if (groupedInventoryItemToRemove.Quantity == 1)
                {
                    GroupedInventory.Remove(groupedInventoryItemToRemove);
                }
                else
                {
                    groupedInventoryItemToRemove.Quantity--;
                }
            }

            OnPropertyChanged(nameof(Weapons));
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
