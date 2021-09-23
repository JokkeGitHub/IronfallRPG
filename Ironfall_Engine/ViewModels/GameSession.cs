﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Models;
using Ironfall_Engine.Factories;
using Ironfall_Engine.Events;

namespace Ironfall_Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        private Location _currentLocation;
        private Monster _currentMonster;
        private LocalPlayer _currentPlayer;

        public LocalPlayer CurrentPlayer 
        {
            get { return _currentPlayer; }
            set 
            {
                if (_currentPlayer != null)
                {
                    _currentPlayer.OnActionPerformed -= OnCurrentPlayerActionPerfomed;
                    _currentPlayer.OnKilled -= OnCurrentPlayerKilled;
                }

                _currentPlayer = value;

                if (_currentPlayer != null)
                {
                    _currentPlayer.OnActionPerformed += OnCurrentPlayerActionPerfomed;
                    _currentPlayer.OnKilled += OnCurrentPlayerKilled;

                }
            }
        }
        public Monster CurrentMonster 
        {
            get { return _currentMonster; } 
            set
            {
                if (_currentMonster != null)
                {
                    _currentMonster.OnKilled -= OnCurrentMonsterKilled;
                }

                _currentMonster = value;

                if (_currentMonster != null)
                {
                    _currentMonster.OnKilled += OnCurrentMonsterKilled;

                    RaiseMessage("");
                    RaiseMessage($"You are being attacked by a {CurrentMonster.Name}!");
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(HasMonster));
            } 
        }
        public Location CurrentLocation 
        {
            get { return _currentLocation; }
            set 
            {
                _currentLocation = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToSouth));

                GetMonsterAtLocation();
                
            } 
        }
        World CurrentWorld { get; set; }

        public GameSession()
        {
            ItemSlot gear = new ItemSlot(
                new Models.Item.Weapon(-1, "Right Hand", "Unarmed", 0, false, Models.Item.GameItem.ItemCategory.Weapon, Enums.ItemEnum.Weapon.OneHanded, 0, 0),
                new Models.Item.Weapon(-1, "Left Hand", "Unarmed", 0, false, Models.Item.GameItem.ItemCategory.Weapon, Enums.ItemEnum.Weapon.OneHanded, 0, 0),
                new Models.Item.Armor(-1, "Chest", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Armor, Enums.ItemEnum.Armor.Light, 0, 0),
                new Models.Item.Artifact(-1, "Head", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Head),
                new Models.Item.Artifact(-1, "Neck", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Neck),
                new Models.Item.Artifact(-1, "Right Finger", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Finger),
                new Models.Item.Artifact(-1, "Left Finger", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Finger),
                new Models.Item.Artifact(-1, "Feet", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Feet));

            CurrentPlayer = new LocalPlayer(
                "Classless",                //Class
                "UserID",                   //ID
                0,                          //ExperienecPoints
                1, 1, 1,                    //Stats
                "Happy New Adventurer",     //Name
                "placeholderclose.png",     //Image
                10, 10,                     //Health
                1, 2,                       //Damage
                5,5,                        //MagicPoints
                5,5,                        //AbilityPoints
                1,1,                        //Defence
                1,                          //Level
                0,                          //Gold
                gear);                         

            CurrentPlayer.DamageMinimum = CurrentPlayer.DamageMinimum + CurrentPlayer.StatBody;
            CurrentPlayer.DamageMaximum = CurrentPlayer.DamageMaximum + CurrentPlayer.StatBody;

            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, 0);
            
        }

        public bool HasMonster => CurrentMonster != null;

        #region Movement
        //A boolean used to show the buttons in the xaml file. If it's true, the button can show, if null the it statement is false and the button can't show.
        public bool HasLocationToNorth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
        public bool HasLocationToWest => CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
        public bool HasLocationToEast => CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
        public bool HasLocationToSouth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
        
        public void MoveNorth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            IsTravelAllowed("North");
        }
        public void MoveSouth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            IsTravelAllowed("South");
        }
        public void MoveEast()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate +1 , CurrentLocation.YCoordinate);
            IsTravelAllowed("East");
        }
        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            IsTravelAllowed("West");
        }
        public void IsTravelAllowed(string direction)
        {
            if (CurrentLocation.IsTravelAllowed == false)
            {
                switch (direction)
                {
                    case "North":
                        CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
                        RaiseMessage("You can't go here yet.");
                        break;
                    case "West":
                        CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
                        RaiseMessage("You can't go here yet.");
                        break;
                    case "East":
                        CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
                        RaiseMessage("You can't go here yet.");
                        break;
                    case "South":
                        CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
                        RaiseMessage("You can't go here yet.");
                        break;
                    default:
                        break;
                }

            }
        }
        #endregion

        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }

        public void AttackCurrentMonster()
        {
            RaiseMessage("Combat has begun");

            CurrentPlayer.UseAttackAction(CurrentPlayer, CurrentMonster);

            if (CurrentMonster.IsDead)
            {
                // Add another monster. Maybe it should be changed to when you enter the zone. 
                //GetMonsterAtLocation();
            }
            else
            {
                //Monster Attack
                CurrentMonster.UseAttackAction(CurrentMonster, CurrentPlayer);
            }
        }

        //Event Functions
        private void OnCurrentMonsterKilled(object sender, System.EventArgs eventArgs)
        {
            RaiseMessage("");
            RaiseMessage($"You killed the {CurrentMonster.Name}!");
        }
        private void OnCurrentPlayerActionPerfomed(object sender, string result)
        {
            RaiseMessage(result);
        }

        private void OnCurrentPlayerKilled(object sender, System.EventArgs eventArgs)
        {
            RaiseMessage("");
            RaiseMessage($"The {CurrentMonster} killed you...");
            CurrentLocation = CurrentWorld.LocationAt(99, 99);
            CurrentPlayer.Heal(CurrentPlayer.HpMax);
        }
        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
    }
}
