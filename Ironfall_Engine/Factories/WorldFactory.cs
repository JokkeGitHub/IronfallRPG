using Ironfall_Engine.Models;

namespace Ironfall_Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(0, 0, "Home", "Test Location", "home.jpg");

            newWorld.AddLocation(0, 1, "Town square",
                "You see a fountain here and two shops one to the north and one to the east. You live to the south",
                "TownSquare.jpg");

            newWorld.AddLocation(-1, 1, "Trading Shop",
                "The shop of a trader.",
                "Shop.jpg");

            newWorld.AddLocation(0, 2, "Back Alley", "It's not a nice place to linger.", "backalley.png");
            newWorld.LocationAt(0, 2).AddMonster(1, 100);


            return newWorld;
        }
    }
}
