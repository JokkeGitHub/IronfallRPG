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
        static int id = 100;

        public Artifact Create(string name, string description, int value, bool isUnique, GameItem.ItemCategory category, Enum artifactType)
        {
            id += 1;

            return new Artifact(id, name, description, value, isUnique, category, artifactType);
        }
    }
}
