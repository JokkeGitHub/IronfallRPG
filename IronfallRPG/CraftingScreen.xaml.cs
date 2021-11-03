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
        public List<Loot> LootList = new List<Loot>();
        public List<Loot> MaterialList = new List<Loot>();

        public CraftingScreen()
        {
            InitializeComponent();
            AddItemToLootList();
            AddItemToMaterialList();
        }

        void AddItemToLootList()
        {
            foreach (GroupedInventoryItem item in Session.CurrentPlayer.GroupedInventory)
            {
                object tempItem = item.ReturnItem();

                if (tempItem is Loot)
                {
                    LootList.Add((Loot)tempItem);
                }
            }
        }

        void AddItemToMaterialList()
        {
            foreach (Loot item in LootList)
            {
                if (item.LootType is ItemEnum.Loot.Material)
                {
                    MaterialList.Add(item);
                }
            }
        }

        private void OnClick_CloseScreen(object sender, RoutedEventArgs e)
        {
            Close();
        }
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
    }
}
