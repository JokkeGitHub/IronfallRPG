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
            Artifact emptyHead = new Artifact(-4, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Head);
            return emptyHead;
        }

        public Artifact GetEmptyNeck()
        {
            Artifact emptyNeck = new Artifact(-5, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Neck);
            return emptyNeck;
        }

        public Artifact GetEmptyFingerRight()
        {
            Artifact emptyFingerRight = new Artifact(-6, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
            return emptyFingerRight;
        }

        public Artifact GetEmptyFingerLeft()
        {
            Artifact emptyFingerLeft = new Artifact(-7, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Finger);
            return emptyFingerLeft;
        }

        public Artifact GetEmptyFeet()
        {
            Artifact emptyFeet = new Artifact(-8, "Empty", "Nothing is eqiupped in this slot.", 0, false, GameItem.ItemCategory.Artefact, ItemEnum.Artifact.Feet);
            return emptyFeet;
        }

    }
}
