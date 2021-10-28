using Ironfall_Engine.Enums;
using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Factories.Item
{
    class ArtifactFactory
    {
        public Artifact Create(int id, string name, string description, int value, bool isUnique, GameItem.ItemCategory category, Enum artifactType)
        {
            return new Artifact(id, name, description, value, isUnique, category, artifactType);
        }

        public Artifact GetEmptyHead()
        {
            Artifact emptyHead = ItemList.head;
            return emptyHead;
        }

        public Artifact GetEmptyNeck()
        {
            Artifact emptyNeck = ItemList.neck;
            return emptyNeck;
        }

        public Artifact GetEmptyFingerRight()
        {
            Artifact emptyFingerRight = ItemList.fingerRight;
            return emptyFingerRight;
        }

        public Artifact GetEmptyFingerLeft()
        {
            Artifact emptyFingerLeft = ItemList.fingerLeft;
            return emptyFingerLeft;
        }

        public Artifact GetEmptyFeet()
        {
            Artifact emptyFeet = ItemList.feet;
            return emptyFeet;
        }

    }
}
