using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Actions;
using Ironfall_Engine.Models;
using Ironfall_Engine.Models.Item;

namespace Ironfall_Engine.Factories
{
    class NpcFactory
    {
        private static readonly List<Npc> _npc = new List<Npc>();
        static NpcFactory()
        {
            Npc river = new Npc("River", "river.png", 15,20, 5,5,10, 5,10, 5,5, 5,5, 3,5, 6, 150, 1, "She looks crazy.", 30);            
            //Move this somewhere else
            ItemList itemList = new ItemList();
            river.AddItemToInventory(itemList.healthPotionMinor);
            river.AddItemToInventory(itemList.healthPotionMinor);
            river.AddItemToInventory(itemList.healthPotionMinor);
            river.AddItemToInventory(itemList.manaPotionMinor);
            river.AddItemToInventory(itemList.manaPotionMinor);
            river.AddItemToInventory(itemList.manaPotionMinor);
            river.AddItemToInventory(itemList.abilityPotionMinor);
            river.AddItemToInventory(itemList.abilityPotionMinor);
            river.AddItemToInventory(itemList.abilityPotionMinor);
            
            AddNpcToList(river);


            Npc earl = new Npc("Earl", "earl.png", 15, 20, 5, 5, 10, 5, 10, 5, 5, 5, 5, 3, 5, 6, 150, 2, "He looks like a nice guy.", 30);
            earl.AddItemToInventory(itemList.ironSword);
            AddNpcToList(earl);
        }
        public static Npc GetNpcByName(string name)
        {
            return _npc.FirstOrDefault(t => t.Name == name);
        }

        private static void AddNpcToList(Npc npc)
        {
            if (_npc.Any(t => t.Name == npc.Name))
            {
                throw new ArgumentException($"There is already an Npc named '{npc.Name}'");
            }
            _npc.Add(npc);
        }
    }
}
