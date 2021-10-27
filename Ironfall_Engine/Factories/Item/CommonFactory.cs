using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Factories.Item
{
    class CommonFactory
    {
        public Common Create(int id, string name, string description, int value, bool isUnique, GameItem.ItemCategory category, Enum commonType)
        {
            return new Common(id, name, description, value, isUnique, category, commonType);
        }
    }
}
