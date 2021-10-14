using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Models;
using Ironfall_Engine.Models.Item;

namespace Ironfall_Engine.Factories
{
    class QuestFactory
    {
        private static readonly List<Quest> _listOfQuests = new List<Quest>();

        static QuestFactory()
        {
            ItemList itemsInGame = new ItemList();
            // Declare the items need to complete the quest, and its reward items
            List<GroupedInventoryItem> itemsToComplete = new List<GroupedInventoryItem>();
            List<GroupedInventoryItem> rewardItems = new List<GroupedInventoryItem>();

            itemsToComplete.Add(new GroupedInventoryItem(itemsInGame.woodenRune, 5));
            rewardItems.Add(new GroupedInventoryItem(itemsInGame.strangeOrb, 1));

            // Create the quest
            _listOfQuests.Add
                (new Quest(1, 
                "Remove the bandits",
                "Some bandits have been terrorizing River, help her teach them a lesson.",
                "River",
                25, 10,
                rewardItems,
                itemsToComplete
                ));
        }

        internal static Quest GetQuestByID(int id)
        {
            return _listOfQuests.FirstOrDefault(quest => quest.ID == id);
        }

        public static void AddQuestToNpc(Npc npc)
        {
            if (npc != null)
            {
                foreach (Quest quest in _listOfQuests)
                {
                    if (quest.QuestBelongsToo == npc.Name && quest.IsComplete != true)
                    {
                        npc.NpcQuests.Add(quest);
                    }
                }
            }
        }
    }
}
