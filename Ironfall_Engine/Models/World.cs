using System.Collections.Generic;

namespace Ironfall_Engine.Models
{
    public class World
    {
        private List<Location> _locationList = new List<Location>();
        internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName, bool isTravelAllowed = true)
        {
            _locationList.Add(new Location(xCoordinate, yCoordinate, name, description, $"/Ironfall_Engine;component/Resource/Images/Locations/{imageName}", isTravelAllowed));
        }

        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            foreach (Location location in _locationList)
            {
                if (location.XCoordinate == xCoordinate && location.YCoordinate == yCoordinate)
                {
                    return location;
                }
            }
            return null;
        }
    }
}
