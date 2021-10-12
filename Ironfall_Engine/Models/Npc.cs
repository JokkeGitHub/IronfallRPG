using Ironfall_Engine.Actions;
using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models
{
    public class Npc : LivingEntity
    {
        public string Description { get; set; }
        public int RewardExp { get; set; }
        public ObservableCollection<Dialog> NpcDialog { get; set; }
        public ObservableCollection<Dialog> NpcDialogResponses { get; set; }
        public ObservableCollection<Dialog> NpcCurrentDialog { get; set; }
        public ObservableCollection<Dialog> NpcCurrentDialogResponses { get; set; }

        public Npc(string name, string image, int hpMax, int hpCurrent, int statBody, int statSpirit, int statFellowship, int damageMinimum, int damageMaximum, int mpMax, int mpCurrent, int apMax, int apCurrent, int defenceMinimum, int defenceMaximum, int level, int gold, string description, int rewardExp) 
            : base(name, image, hpMax, hpCurrent, statBody, statSpirit, statFellowship, damageMinimum, damageMaximum, mpMax, mpCurrent, apMax, apCurrent, defenceMinimum, defenceMaximum, level, gold)
        {
            Description = description;
            RewardExp = rewardExp;
            Image = $"/Ironfall_Engine;component/Resource/Images/Characters/{image}";
            NpcDialog = new ObservableCollection<Dialog>();
            NpcDialogResponses = new ObservableCollection<Dialog>();
            NpcCurrentDialog = new ObservableCollection<Dialog>();
            NpcCurrentDialogResponses = new ObservableCollection<Dialog>();
        }
    }
}
