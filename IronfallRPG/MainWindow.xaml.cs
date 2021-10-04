﻿using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ironfall_Engine.ViewModels;
using Ironfall_Engine.Events;

namespace IronfallRPG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession _gameSession = new GameSession();
        public MainWindow()
        {
            InitializeComponent();

            _gameSession.OnMessageRaised += OnGameMessageRaised;

            DataContext = _gameSession;
        }

        private void OnClick_MoveNorth(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveNorth();
        }
        private void OnClick_MoveSouth(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveSouth();
        }
        private void OnClick_MoveEast(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveEast();
        }
        private void OnClick_MoveWest(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveWest();
        }

        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }
        private void OnClick_Attack(object sender, RoutedEventArgs e)
        {
            _gameSession.AttackCurrentMonster();
        }

        private void OnClick_AddStatBody(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentPlayer.AddStatToBody();
        }
        private void OnClick_AddStatSpirit(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentPlayer.AddStatToSpirit();
        }
        private void OnClick_AddStatFellowship(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentPlayer.AddStatToFellowship();
        }

        // Null Buttons
        private void GameMessages_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e) { }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Equip items temp button
            object obj = (object)((Button)e.Source).DataContext;
            _gameSession.UseItem(obj);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Info items temp button
            object obj = (object)((Button)e.Source).DataContext;
            // Maybe send this to logic and return string crafted from info
            MessageBox.Show("Hello");
        }

        private void Button_UnequipItem(object sender, RoutedEventArgs e)
        {
            // Unequip items temp button
            object obj = ((Button)sender).CommandParameter;
            _gameSession.UnequipItem(obj);
        }
    }
}
