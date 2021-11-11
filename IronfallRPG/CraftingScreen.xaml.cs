using Ironfall_Engine.Models.Item;
using Ironfall_Engine.ViewModels;
using Ironfall_Engine.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IronfallRPG
{
    /// <summary>
    /// Interaction logic for CraftingScreen.xaml
    /// </summary>
    public partial class CraftingScreen : Window
    {
        public GameSession Session => DataContext as GameSession;

        public ObservableCollection<Loot> lootItems = new ObservableCollection<Loot>();
        public ObservableCollection<GameItem> recipeItems = new ObservableCollection<GameItem>();


        public CraftingScreen()
        {
            InitializeComponent();
        }

        private void OnClick_CloseScreen(object sender, RoutedEventArgs e)
        {
            Session.CurrentCraftingStation.ItemInventory.Clear();
            Session.CurrentCraftingStation.RecipeInventory.Clear();
            Session.CurrentCraftingStation.ItemGroupedInventory.Clear();
            Session.CurrentCraftingStation.RecipeGroupedInventory.Clear();
            Close();
        }

        #region BUY/SELL CHANGE THESE LATER
        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem groupedInventoryItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            if (groupedInventoryItem != null)
            {
                if (Session.CurrentPlayer.Gold >= groupedInventoryItem.Item.Value)
                {
                    Session.CurrentPlayer.Gold -= groupedInventoryItem.Item.Value;
                    Session.CurrentNpc.RemoveItemFromInventory(groupedInventoryItem.Item);
                    Session.CurrentPlayer.AddItemToInventory(groupedInventoryItem.Item);
                }
                else
                {
                    MessageBox.Show("You do not have enough gold");
                }
            }
        }
        private void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem groupedInventoryItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            if (groupedInventoryItem != null)
            {
                Session.CurrentPlayer.Gold += groupedInventoryItem.Item.Value;
                Session.CurrentNpc.AddItemToInventory(groupedInventoryItem.Item);
                Session.CurrentPlayer.RemoveItemFromInventory(groupedInventoryItem.Item);
            }
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Session.CurrentPlayer.GroupedInventory)
            {
                GameItem tempItem = item.ReturnItem();
                int quantity = item.Quantity;

                if (tempItem.Category is GameItem.ItemCategory.Recipe)
                {
                    recipeItems.Add((Recipe)tempItem);
                }
                else if (tempItem.Category is GameItem.ItemCategory.Loot)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        lootItems.Add((Loot)tempItem);
                    }
                }
            }
            SortItems();
        }

        void SortItems()
        {
            foreach (Loot item in lootItems)
            {
                if (item.LootType is ItemEnum.Loot.Material)
                {
                    Session.CurrentCraftingStation.AddItemToInventory(item);
                }
            }
            foreach (Recipe item in recipeItems)
            {
                if (item.RecipeType is ItemEnum.Recipe.Weapon)
                {
                    Session.CurrentCraftingStation.AddRecipeToInventory(item);
                }
            }
            lootItems.Clear();
            recipeItems.Clear();
            StartCraftingStation.Visibility = Visibility.Hidden;
        }
    }
}
