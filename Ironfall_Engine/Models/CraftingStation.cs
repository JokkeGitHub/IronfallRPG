using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models
{
    public class CraftingStation
    {
        public enum Type
        {
            Forge,
            Brewery,
            Lecturn,
            Workshop,
            Kitchen
        }
        
        public Type StationType { get; set; }
        public string Name{ get; set; }
        public ObservableCollection<GameItem> ItemInventory { get; set; }
        public ObservableCollection<GameItem> RecipeInventory { get; set; }
        public ObservableCollection<GroupedInventoryItem> ItemGroupedInventory { get; set; }
        public ObservableCollection<GroupedInventoryItem> RecipeGroupedInventory { get; set; }

        // Maybe add an image

        public CraftingStation(string name, Type stationType)
        {
            Name = name;
            StationType = stationType;
            ItemInventory = new ObservableCollection<GameItem>();
            RecipeInventory = new ObservableCollection<GameItem>();
            ItemGroupedInventory = new ObservableCollection<GroupedInventoryItem>();
            RecipeGroupedInventory = new ObservableCollection<GroupedInventoryItem>();
        }

        //Inventory Functions
        public void AddItemToInventory(GameItem item)
        {
            ItemInventory.Add(item);

            if (item.IsUnique)
            {
                ItemGroupedInventory.Add(new GroupedInventoryItem(item, 1));
            }
            else if (item.IsUnique == false)
            {

                if (!ItemGroupedInventory.Any(gi => gi.Item.Id == item.Id))
                {
                    ItemGroupedInventory.Add(new GroupedInventoryItem(item, 0));
                }

                ItemGroupedInventory.First(gi => gi.Item.Id == item.Id).Quantity++;
            }
            //OnPropertyChanged(nameof(Weapons));
        }
        public void RemoveItemFromInventory(GameItem item)
        {
            ItemInventory.Remove(item);

            GroupedInventoryItem groupedInventoryItemToRemove = item.IsUnique ? ItemGroupedInventory.FirstOrDefault(gi => gi.Item == item) : ItemGroupedInventory.FirstOrDefault(gi => gi.Item.Id == item.Id);

            if (groupedInventoryItemToRemove != null)
            {
                if (groupedInventoryItemToRemove.Quantity == 1)
                {
                    ItemGroupedInventory.Remove(groupedInventoryItemToRemove);
                }
                else
                {
                    groupedInventoryItemToRemove.Quantity--;
                }
            }

            //OnPropertyChanged(nameof(Weapons));
        }





        //Inventory Functions
        public void AddRecipeToInventory(GameItem item)
        {
            RecipeInventory.Add(item);

            if (item.IsUnique)
            {
                RecipeGroupedInventory.Add(new GroupedInventoryItem(item, 1));
            }
            else if (item.IsUnique == false)
            {

                if (!RecipeGroupedInventory.Any(gi => gi.Item.Id == item.Id))
                {
                    RecipeGroupedInventory.Add(new GroupedInventoryItem(item, 0));
                }

                RecipeGroupedInventory.First(gi => gi.Item.Id == item.Id).Quantity++;
            }
            //OnPropertyChanged(nameof(Weapons));
        }
        public void RemoveRecipeFromInventory(GameItem item)
        {
            RecipeInventory.Remove(item);

            GroupedInventoryItem groupedInventoryItemToRemove = item.IsUnique ? RecipeGroupedInventory.FirstOrDefault(gi => gi.Item == item) : RecipeGroupedInventory.FirstOrDefault(gi => gi.Item.Id == item.Id);

            if (groupedInventoryItemToRemove != null)
            {
                if (groupedInventoryItemToRemove.Quantity == 1)
                {
                    RecipeGroupedInventory.Remove(groupedInventoryItemToRemove);
                }
                else
                {
                    groupedInventoryItemToRemove.Quantity--;
                }
            }

            //OnPropertyChanged(nameof(Weapons));
        }
    }
}
