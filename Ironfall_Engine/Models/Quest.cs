using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Models.Item;

namespace Ironfall_Engine.Models
{
    public class Quest
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string QuestBelongsToo { get; set; }
        public int RewardExperience { get; set; }
        public int RewardGold { get; set; }
        public List<GroupedInventoryItem> RewardItems { get; set; }
        public List<GroupedInventoryItem> ItemsToComplete { get; set; }
        public bool IsComplete { get; set; }

        public Quest(int iD, string name, string description, string questBelongsToo, int rewardExperience, int rewardGold, List<GroupedInventoryItem> rewardItems, List<GroupedInventoryItem> itemsToComplete, bool isComplete = false)
        {
            ID = iD;
            Name = name;
            Description = description;
            QuestBelongsToo = questBelongsToo;
            RewardExperience = rewardExperience;
            RewardGold = rewardGold;
            RewardItems = rewardItems;
            ItemsToComplete = itemsToComplete;
            IsComplete = isComplete;
        }

    }
}
