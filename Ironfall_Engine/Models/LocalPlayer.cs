using Ironfall_Engine.Actions;
using System.Collections.ObjectModel;
using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ironfall_Engine.Models
{
    public class LocalPlayer : LivingEntity
    {
        private int _experiencePoints;
        private double _experienceCap; 
        private int _unAllocatedStatPoints;

        public string CharacterClass { get; set; }
        public string UserID { get; set; }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged();
                SetLevelUp();
            }
        }
        public double ExperienceCap
        {
            get { return _experienceCap; }
            set
            {
                _experienceCap = value;
                OnPropertyChanged();
            }
        }
        public int UnAllocatedStatPoints
        {
            get { return _unAllocatedStatPoints; }
            set
            {
                _unAllocatedStatPoints = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Quest> QuestLog { get; set; }

        public event EventHandler OnLeveledUp; 

        public LocalPlayer(string characterClass, string userID, int experiencePoints, int unAllocatedStatPoints, int statBody, int statSpirit, int statFellowship, string name, string image, int hpMax, int hpCurrent, int damageMinimum, int damageMaximum, int mpMax, int mpCurrent, int apMax, int apCurrent, int defenceMinimum, int defenceMaximum, int level, int gold) : 
            base(name, image, hpMax, hpCurrent, statBody, statSpirit, statFellowship, damageMinimum, damageMaximum, mpMax, mpCurrent, apMax, apCurrent, defenceMinimum, defenceMaximum, level, gold)
        {
            CharacterClass = characterClass;
            UserID = userID;
            ExperiencePoints = experiencePoints;
            ExperienceCap = 13;
            UnAllocatedStatPoints = unAllocatedStatPoints;
            Image = $"/Ironfall_Engine;component/Resource/Images/PlayerImages/{image}";
            QuestLog = new ObservableCollection<Quest>();
            
        }


        private void SetLevelUp()
        {
            int originalLevel = Level;

            if (Level * 12.5 <= ExperiencePoints)
            {
                Level++;
                ExperiencePoints = 0;
                ExperienceCap = Math.Ceiling(Level * 12.5);
            }
            if (Level != originalLevel)
            {
                HpMax += StatBody;
                MpMax += StatSpirit;
                ApMax += StatFellowship;
                UnAllocatedStatPoints += 1;
                OnLeveledUp?.Invoke(this, System.EventArgs.Empty);
            }
        }
        public void AddStatToBody()
        {
            if (UnAllocatedStatPoints > 0)
            {
                UnAllocatedStatPoints--;
                StatBody++;
                HpMax++;
                HpCurrent++;
            }
        }
        public void AddStatToSpirit()
        {
            if (UnAllocatedStatPoints > 0)
            {
                UnAllocatedStatPoints--;
                StatSpirit++;
                MpMax++;
                MpCurrent++;
            }
        }
        public void AddStatToFellowship()
        {
            if (UnAllocatedStatPoints > 0)
            {
                UnAllocatedStatPoints--;
                StatFellowship++;
                ApMax++;
                ApCurrent++;
            }
        }
        public void AddStatToDamage()
        {
            if (UnAllocatedStatPoints > 0)
            {
                UnAllocatedStatPoints--;
                DamageMaximum++;

                if (DamageMaximum % 3 == 0)
                {
                    DamageMinimum++;
                }
            }
        }
        public void AddStatToDefence()
        {
            if (UnAllocatedStatPoints > 0)
            {
                UnAllocatedStatPoints--;
                DefenceMaximum++;
                if (DefenceMaximum % 3 == 0)
                {
                    DefenceMinimum++;
                }
            }
        }

        
        public bool HasItemsToCompleteCheck(List<GroupedInventoryItem> items)
        {
            foreach (GroupedInventoryItem item in items)
            {
                if (Inventory.Count(i => i.Id == item.Item.Id) < item.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
