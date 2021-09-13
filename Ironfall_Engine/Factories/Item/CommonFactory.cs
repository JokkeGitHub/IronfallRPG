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
        static int id = 400;

        public Common Create(string name, string description, int value, bool isUnique, Enum type, int quantity)
        {
            id += 1;

            return new Common(id, name, description, value, isUnique, type, quantity);
        }
    }
}
