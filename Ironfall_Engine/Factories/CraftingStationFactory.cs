using Ironfall_Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Factories
{
    class CraftingStationFactory
    {
        private static readonly List<CraftingStation> _craftingStation = new List<CraftingStation>();
        static CraftingStationFactory()
        {
            CraftingStation earlsForge = new CraftingStation("Forge", CraftingStation.Type.Forge);
            AddCraftingStationToList(earlsForge);
        }

        public static CraftingStation GetCraftingStationByName(string name)
        {
            return _craftingStation.FirstOrDefault(t => t.Name == name);
        }

        private static void AddCraftingStationToList(CraftingStation craftingStation)
        {
            if (_craftingStation.Any(t => t.Name == craftingStation.Name))
            {
                throw new ArgumentException($"There is already a CraftingStation named '{craftingStation.Name}'");
            }
            _craftingStation.Add(craftingStation);
        }
    }
}
