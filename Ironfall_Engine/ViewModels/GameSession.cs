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
        #region Varibles etc

        public bool HasMonster => CurrentMonster != null;
        public bool HasNpc => CurrentNpc != null;
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;
        public event EventHandler<EventArgs> Trade;

        private Location _currentLocation;
        private Monster _currentMonster;
        private LocalPlayer _currentPlayer;
        private Npc _currentNpc;


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

                CurrentNpc = CurrentLocation.NpcHere;
            }
        }
        public Npc CurrentNpc
        {
            get { return _currentNpc; }
            set
            {
                _currentNpc = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasNpc));

                if (_currentNpc != null)
                {
                    if (CurrentNpc.NpcDialog.Count == 0)
                    {
                        DialogFactory.AddDialogToNpc(CurrentNpc);
                    }
                    if (CurrentNpc.NpcQuests.Count == 0)
                    {
                        QuestFactory.AddQuestToNpc(CurrentNpc);
                    }
                    RaiseMessage($"{CurrentNpc.NpcDialog.FirstOrDefault().DialogText}");
                }
            }
        }
        World CurrentWorld { get; set; }

        #endregion

        public GameSession()
        {
            ItemSlot gear = new ItemSlotFactory().Create();
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
                0                          //Gold
                );                         

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

            Artifact testHead = artifactFactory.Create(5991,"Dev Head", "From Malai, from Thailand", 5, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Head);
            Artifact testHead2 = artifactFactory.Create(5992,"Dev Head 2", "From Malai, from Thailand", 5, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Head);
            Artifact testNeck = artifactFactory.Create(5993,"Dev Neck", "hmmmmm", 55, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Neck);
            Artifact testNeck2 = artifactFactory.Create(5994,"Dev Neck 2", "hmmmmm", 55, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Neck);
            Artifact testFingerOne = artifactFactory.Create(5995,"Dev Finger", "hygge fingers", 35, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
            Artifact testFingerTwo = artifactFactory.Create(5996,"The Second Ring", "hygge fingers", 99, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
            Artifact testFingerThree = artifactFactory.Create(5997,"The Third Ring", "hygge fingers", 1, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
            Artifact testFeet = artifactFactory.Create(5998,"Dev Feet", "Shoes", 555, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Feet);
            Artifact testFeet2 = artifactFactory.Create(5999,"Dev Feet 2", "Shoes", 555, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Feet);

            CurrentPlayer.AddItemToInventory(testWeapon);
            CurrentPlayer.AddItemToInventory(testWeapon2);
            CurrentPlayer.AddItemToInventory(testShield);
            CurrentPlayer.AddItemToInventory(testShield2);
            CurrentPlayer.AddItemToInventory(testChest);
            CurrentPlayer.AddItemToInventory(testChest2);
            CurrentPlayer.AddItemToInventory(testHead);
            CurrentPlayer.AddItemToInventory(testHead2);
            CurrentPlayer.AddItemToInventory(testNeck);
            CurrentPlayer.AddItemToInventory(testNeck2);
            CurrentPlayer.AddItemToInventory(testFingerOne);
            CurrentPlayer.AddItemToInventory(testFingerTwo);
            CurrentPlayer.AddItemToInventory(testFingerThree);
            CurrentPlayer.AddItemToInventory(testFeet);
            CurrentPlayer.AddItemToInventory(testFeet2);
            CurrentPlayer.AddItemToInventory(test2Hander);
            CurrentPlayer.AddItemToInventory(testRanged);

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

        #region Functions

        #region Items
        public void UseItem(GroupedInventoryItem tempItem)
        {
            object item = tempItem.ReturnItem();

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
        #endregion

        #region Get and Attack
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
                RaiseMessage($"You have defeated the {CurrentMonster.Name}- You get {CurrentMonster.RewardExp} Experience.");

                foreach (GameItem itemReward in CurrentMonster.Inventory)
                {
                    CurrentPlayer.AddItemToInventory(itemReward);
                    RaiseMessage($"The {CurrentMonster.Name} have dropped {itemReward.Name}");
                }
                CurrentMonster = null;
            }
            else
            {
                //Monster Attack
                CurrentMonster.UseAttackAction(CurrentPlayer);
            }
        }
        #endregion

        #region Dialogue
        public void IngameDialogInitiation()
        {
            //This function is used at start, and also if the dialog returns to start. It clears to avoid dublications.  
            if (CurrentNpc.NpcCurrentDialogResponses.Any())
            {
                CurrentNpc.NpcCurrentDialogResponses.Clear();
            }

            Dialog currentDialog = CurrentNpc.NpcDialog.FirstOrDefault();

            //Add the start responses to response list. 
            foreach (Dialog dialog in CurrentNpc.NpcDialogResponses)
            {
                if (Math.Floor(dialog.DialogId) == currentDialog.DialogId && dialog.IsUsed != true)
                {
                    CurrentNpc.NpcCurrentDialogResponses.Add(dialog);
                }
            }
        }
        public void ChooseDialogOption(object obj)
        {
            double responseDialog = Convert.ToDouble(obj.ToString());

            //Formular to get the decimal number.  
            double responseNmb = (responseDialog - Math.Floor(responseDialog)) * 100;
            responseNmb = Math.Round(responseNmb);
            Dialog savedDialog = null;

            //bool to help check if there is any responses to the npc line. 
            bool emptyDialogChecker = true;

            //Looking through all the Npc's dialog. 
            foreach (Dialog dialog in CurrentNpc.NpcDialog)
            {
                //Create a check that sees if the second number in the line is equal to any number in dialog
                if (dialog.DialogId == responseNmb)
                {
                    RaiseMessage($"{dialog.DialogText}");
                    savedDialog = dialog;
                                        
                    //Clear the player responses for new responses. 
                    CurrentNpc.NpcCurrentDialogResponses.Clear();
                    
                    //Finds all the responses that match the new number. 
                    foreach (Dialog dialogR in CurrentNpc.NpcDialogResponses)
                    {
                        if (Math.Floor(dialogR.DialogId) == dialog.DialogId && dialogR.IsUsed == false)
                        {
                            CurrentNpc.NpcCurrentDialogResponses.Add(dialogR);
                            //If any responses is added, the number will rise, making sure the it wont reset.
                            emptyDialogChecker = false;
                            
                        }
                    }
                    if (emptyDialogChecker)
                    {
                        //There is no new dialog load the standard responses. 
                        foreach (Dialog dialogR in CurrentNpc.NpcDialogResponses)
                        {
                            if (Math.Floor(dialogR.DialogId) == 10 && dialogR.IsUsed == false)
                            {
                                CurrentNpc.NpcCurrentDialogResponses.Add(dialogR);
                            }
                        }
                    }
                    //Setting the dialog in question as used if it isn't recuring.
                    SetDialogToUsed(responseDialog);
                }
            }
            
            switch (responseNmb)
            {
                case 96:
                    foreach (Quest quest in CurrentNpc.NpcQuests)
                    {
                        if (quest.IsComplete != true && quest.ID == savedDialog.DialogQuestId)
                        {
                            CurrentPlayer.QuestLog.Add(quest);

                            //Finding the following dialog and activates it. 
                            foreach (Dialog dialog in CurrentNpc.NpcDialog)
                            {
                                if (dialog.DialogId == 97)
                                {
                                    dialog.IsUsed = false;
                                }
                            }
                        }
                    }
                    break;
                case 97:
                    //Check if quest is completed
                    RaiseMessage("Cheking if quest is completed");
                    CompleteQuest(savedDialog.DialogQuestId);
                    break;
                case 98:
                    Trade?.Invoke(this, new EventArgs()); 
                    break;
                case 99:
                    CurrentNpc.NpcCurrentDialogResponses.Clear();
                    break;
                default:
                    //Check to see if the dialog continues and then resets or ends. 
                    if (emptyDialogChecker == true)
                    {
                        IngameDialogInitiation();
                    }
                    break;
            }
        }
        public void SetDialogToUsed(double id)
        {
            foreach (Dialog dialog in CurrentNpc.NpcDialogResponses)
            {
                if (dialog.DialogId == id && dialog.IsRecurring == false)
                {
                    dialog.IsUsed = true;
                }
            }
        }
        #endregion

        #region Quest
        private void CompleteQuest(int questID)
        {
            foreach (Quest quest in CurrentPlayer.QuestLog)
            {
                if (quest != null && !quest.IsComplete && quest.ID == questID)
                {
                    if (CurrentPlayer.HasItemsToCompleteCheck(quest.ItemsToComplete))
                    {
                        // Remove the quest completion items from the player's inventory
                        foreach (GroupedInventoryItem groupedInventory in quest.ItemsToComplete)
                        {
                            for (int i = 0; i < groupedInventory.Quantity; i++)
                            {
                                CurrentPlayer.RemoveItemFromInventory(CurrentPlayer.Inventory.First(item => item.Id == groupedInventory.Item.Id));
                            }
                        }

                        RaiseMessage("");
                        RaiseMessage($"You completed the '{quest.Name}' quest");

                        // Give the player the quest rewards
                        CurrentPlayer.ExperiencePoints += quest.RewardExperience;
                        RaiseMessage($"You receive {quest.RewardExperience} experience points");

                        CurrentPlayer.Gold += quest.RewardGold;
                        RaiseMessage($"You receive {quest.RewardGold} gold");

                        foreach (GroupedInventoryItem item in quest.RewardItems)
                        {
                            for (int i = 0; i < item.Quantity; i++)
                            {
                                GameItem rewardItem = item.Item;

                                CurrentPlayer.AddItemToInventory(rewardItem);
                                RaiseMessage($"You receive a {rewardItem.Name}");
                            }
                        }

                        // Mark the Quest as completed
                        quest.IsComplete = true;
                    }
                }
            }
        }
        #endregion

        #region Event Functions
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

        #endregion
    }
}
