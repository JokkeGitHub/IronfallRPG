using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine
{
    class ItemSlot
    {
        public Weapon HandRight { get; set; }
        public Weapon HandLeft { get; set; }
        public Armor Chest { get; set; }
        public Artifact Head { get; set; }
        public Artifact Feet { get; set; }
        public Artifact Neck { get; set; }
        public Artifact FingerRight { get; set; }
        public Artifact FingerLeft { get; set; }
    }
}
