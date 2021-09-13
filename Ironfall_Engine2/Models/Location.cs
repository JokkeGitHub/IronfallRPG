using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models
{
    public class Location
    {

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public bool IsTravelAllowed { get; set; }

        public Location(int xCoordinate, int yCoordinate, string name, string description, string imageName, bool isTravelAllowed)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            ImageName = imageName;
            IsTravelAllowed = isTravelAllowed;
        }

    }
}
