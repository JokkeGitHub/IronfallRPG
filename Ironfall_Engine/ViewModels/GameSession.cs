using System;
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
        //public event EventHandler<GameMessageEventArgs> OnMessageRaised;
        private Location _currentLocation;

        LocalPlayer CurrentPlayer { get; set; }
        Location CurrentLocation 
        {
            get { return _currentLocation; }
            set 
            {
                _currentLocation = value;
                OnPropertyChanged();
            } 
        }
        World CurrentWorld { get; set; }
        

        public GameSession()
        {
            CurrentPlayer = new LocalPlayer();
            CurrentPlayer.Name = "Happy New Adventurer";
            CurrentPlayer.CharacterClass = "No Class";
            CurrentPlayer.HpMax = 10;
            CurrentPlayer.HpCurrent = CurrentPlayer.HpMax;
            CurrentPlayer.Gold = 1000000;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;
            CurrentPlayer.StatBody = 1;
            CurrentPlayer.StatSpirit = 1;
            CurrentPlayer.StatFellowship = 1;

            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, 0);
            
        }

        public void MoveNorth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }
        public void MoveSouth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);

        }
        public void MoveEast()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate +1 , CurrentLocation.YCoordinate);

        }
        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);

        }

    }
}
