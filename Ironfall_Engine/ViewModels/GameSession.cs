using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Models;
using Ironfall_Engine.Factories;
using Ironfall_Engine.Events;
using Ironfall_Engine.Actions;
using Ironfall_Engine.Models.Item;
using Ironfall_Engine.Factories.Item;
using Ironfall_Engine.Enums;
using System.Collections.ObjectModel;

namespace Ironfall_Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        public bool HasMonster => CurrentMonster != null;
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        #region Instantiations
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
                    _currentMonster.OnActionPerformed -= OnCurrentMonsterPerformedAction;
                    _currentMonster.OnKilled -= OnCurrentMonsterKilled;
                }

                _currentMonster = value;

                if (_currentMonster != null)
                {
                    _currentMonster.OnActionPerformed += OnCurrentMonsterPerformedAction;
                    _currentMonster.OnKilled += OnCurrentMonsterKilled;

                    RaiseMessage("");
                    RaiseMessage($"You are being attacked by a {CurrentMonster.Name}!");
                    RaiseMessage("");
                    RaiseMessage($"Combat has begun.");
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
        #endregion

        public GameSession()
        {
            ItemSlot gear = new ItemSlotFactory().Create();
            BasicAction basicAction = new BasicAction();
            ObservableCollection<GameItem> inventory = new ObservableCollection<GameItem>();
            CurrentPlayer = new LocalPlayer(
                "Classless",                //Class
                "UserID",                   //ID
                0,                          //ExperienecPoints
                3,                          //UnAllocatedStatPoints
                0, 0, 0,                    //Stats
                "Happy New Adventurer",     //Name
                "soldier.png",              //Image
                10, 5,                      //Health
                1, 2,                       //Damage
                5, 5,                       //MagicPoints
                5, 5,                       //AbilityPoints
                1, 1,                       //Defence
                1,                          //Level
                0,                          //Gold
                inventory, gear, basicAction);

            //This should not be here but maybe in localPlayer

            CurrentPlayer.Heal(CurrentPlayer.HpMax);

            WeaponFactory weaponFactory = new WeaponFactory();
            ArmorFactory armorFactory = new ArmorFactory();
            ArtifactFactory artifactFactory = new ArtifactFactory();

            Weapon testWeapon = weaponFactory.Create("Dev Weapon", "noisy kids must leave", 100, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 3, 5);
            Weapon testWeapon2 = weaponFactory.Create("Dev Weapon 2", "noisy kids must leave", 100, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.OneHanded, 3, 5);
            Weapon testShield = weaponFactory.Create("Dev Shield", "noisy kids must leave", 100, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.Shield, 0, 0);
            Weapon testShield2 = weaponFactory.Create("Dev Shield 2", "noisy kids must leave", 100, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.Shield, 0, 0);

            Weapon test2Hander = weaponFactory.Create("Dev 2 Hander", "noisy kids must leave", 100, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.TwoHanded, 6, 9);
            Weapon testRanged = weaponFactory.Create("Dev Ranged", "noisy kids must leave", 100, false, GameItem.ItemCategory.Weapon, ItemEnum.Weapon.Ranged, 6, 9);

            Armor testChest = armorFactory.Create("Dev Chest", "i wanna go home", 95, false, GameItem.ItemCategory.Armor, ItemEnum.Armor.Light, 3, 4);
            Armor testChest2 = armorFactory.Create("Dev Chest 2", "i wanna go home", 95, false, GameItem.ItemCategory.Armor, ItemEnum.Armor.Light, 3, 4);

            Artifact testHead = artifactFactory.Create("Dev Head", "From Malai, from Thailand", 5, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Head);
            Artifact testHead2 = artifactFactory.Create("Dev Head 2", "From Malai, from Thailand", 5, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Head);
            Artifact testNeck = artifactFactory.Create("Dev Neck", "hmmmmm", 55, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Neck);
            Artifact testNeck2 = artifactFactory.Create("Dev Neck 2", "hmmmmm", 55, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Neck);
            Artifact testFingerOne = artifactFactory.Create("Dev Finger", "hygge fingers", 35, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
            Artifact testFingerTwo = artifactFactory.Create("The Second Ring", "hygge fingers", 99, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
            Artifact testFingerThree = artifactFactory.Create("The Third Ring", "hygge fingers", 1, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
            Artifact testFeet = artifactFactory.Create("Dev Feet", "Shoes", 555, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Feet);
            Artifact testFeet2 = artifactFactory.Create("Dev Feet 2", "Shoes", 555, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Feet);

            CurrentPlayer.Inventory.Add(testWeapon);
            CurrentPlayer.Inventory.Add(testWeapon2);
            CurrentPlayer.Inventory.Add(testShield);
            CurrentPlayer.Inventory.Add(testShield2);
            CurrentPlayer.Inventory.Add(testChest);
            CurrentPlayer.Inventory.Add(testChest2);
            CurrentPlayer.Inventory.Add(testHead);
            CurrentPlayer.Inventory.Add(testHead2);
            CurrentPlayer.Inventory.Add(testNeck);
            CurrentPlayer.Inventory.Add(testNeck2);
            CurrentPlayer.Inventory.Add(testFingerOne);
            CurrentPlayer.Inventory.Add(testFingerTwo);
            CurrentPlayer.Inventory.Add(testFingerThree);
            CurrentPlayer.Inventory.Add(testFeet);
            CurrentPlayer.Inventory.Add(testFeet2);
            CurrentPlayer.Inventory.Add(test2Hander);
            CurrentPlayer.Inventory.Add(testRanged);

            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, 0);

        }

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
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
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
        public void UseItem(object item)
        {
            if (item is Weapon)
            {
               string weaponName =  CurrentPlayer.Gear.EquipWeapon(CurrentPlayer, (Weapon)item);
               RaiseMessage($"You have equipped {weaponName}");
            }
            else if (item is Armor)
            {
                string armorName = CurrentPlayer.Gear.EquipArmor(CurrentPlayer, (Armor)item);
                RaiseMessage($"You have equipped {armorName}");
            }
            else if (item is Artifact)
            {
                string artifactName = CurrentPlayer.Gear.EquipArtifact(CurrentPlayer, (Artifact)item);
                RaiseMessage($"You have equipped {artifactName}");
            }
        }

        public void UnequipItem(object item)
        {
            if (item is Weapon)
            {
                string weaponName = CurrentPlayer.Gear.UnequipWeapon(CurrentPlayer, (Weapon)item);
                RaiseMessage($"You have unequipped {weaponName}");
            }
            else if (item is Armor)
            {
                string armorName = CurrentPlayer.Gear.UnequipArmor(CurrentPlayer, (Armor)item);
                RaiseMessage($"You have unequipped {armorName}");
            }
            else if (item is Artifact)
            {
                string artifactName = CurrentPlayer.Gear.UnequipArtifact(CurrentPlayer, (Artifact)item);
                RaiseMessage($"You have unequipped {artifactName}");
            }
        }

        public string ItemInfo(object item)
        {
            string itemInfo = "";
            
            if (item is Weapon)
            {
                itemInfo += CurrentPlayer.Gear.InfoWeapon(CurrentPlayer, (Weapon)item);
            }
            else if (item is Armor)
            {
                itemInfo += CurrentPlayer.Gear.InfoArmor(CurrentPlayer, (Armor)item);
            }
            else if (item is Artifact)
            {
                itemInfo += CurrentPlayer.Gear.InfoArtifact(CurrentPlayer, (Artifact)item);
            }

            return itemInfo;
        }

        #region Functions
        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }
        public void AttackCurrentMonster()
        {
            CurrentPlayer.UseAttackAction(CurrentMonster);

            if (CurrentMonster.IsDead)
            {
                // Add another monster. Maybe it should be changed to when you enter the zone. 
                //GetMonsterAtLocation();
                CurrentPlayer.ExperiencePoints += CurrentMonster.RewardExp;

                foreach (GameItem itemReward in CurrentMonster.Inventory)
                {
                    CurrentPlayer.Inventory.Add(itemReward);
                }
                CurrentMonster = null;
            }
            else
            {
                //Monster Attack
                CurrentMonster.UseAttackAction(CurrentPlayer);
            }
        }

        
        //Event Functions
        private void OnCurrentPlayerActionPerfomed(object sender, string result)
        {
            RaiseMessage(result);
        }
        private void OnCurrentMonsterPerformedAction(object sender, string result)
        {
            RaiseMessage(result);
        }
        private void OnCurrentMonsterKilled(object sender, System.EventArgs eventArgs)
        {
            RaiseMessage("");
            RaiseMessage($"You killed the {CurrentMonster.Name}!");
        }
        private void OnCurrentPlayerKilled(object sender, System.EventArgs eventArgs)
        {
            RaiseMessage("");
            RaiseMessage($"The {CurrentMonster.Name} killed you...");
            CurrentLocation = CurrentWorld.LocationAt(0, 0);
            CurrentPlayer.Heal(CurrentPlayer.HpMax);
        }
        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
        #endregion
    }
}
