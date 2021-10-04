using Ironfall_Engine.Actions;
using System.Collections.ObjectModel;
using Ironfall_Engine.Models.Item;

namespace Ironfall_Engine.Models
{
    public class LocalPlayer : LivingEntity
    {
        private int _experiencePoints;

        public string CharacterClass { get; set; }
        public string UserID { get; set; }
        public int ExperiencePoints 
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged();
            }
        }
        

        public LocalPlayer(string characterClass, string userID, int experiencePoints, int statBody, int statSpirit, int statFellowship, string name, string image, int hpMax, int hpCurrent, int damageMinimum, int damageMaximum, int mpMax, int mpCurrent, int apMax, int apCurrent, int defenceMinimum, int defenceMaximum, int level, int gold, ObservableCollection<GameItem> inventory, ItemSlot gear, BasicAction basicAction) : 
            base(name, image, hpMax, hpCurrent, damageMinimum, damageMaximum, mpMax, mpCurrent, apMax, apCurrent, defenceMinimum, defenceMaximum, level, gold, inventory, gear, basicAction)
        {
            CharacterClass = characterClass;
            UserID = userID;
            ExperiencePoints = experiencePoints;
            StatBody = statBody;
            StatSpirit = statSpirit;
            StatFellowship = statFellowship;
            Image = $"/Ironfall_Engine;component/Resource/Images/PlayerImages/{image}";
            
        }

    }
}
