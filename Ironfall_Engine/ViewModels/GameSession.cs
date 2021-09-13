using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Models;

namespace Ironfall_Engine.ViewModels
{
    public class GameSession
    {
        public LocalPlayer CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }

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
            
        }

        public void MoveNorth()
        {

        }
        public void MoveSouth()
        {

        }
        public void MoveEast()
        {

        }
        public void MoveWest()
        {

        }
    }
}
