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
                "You see a fountain here and two shops one to the north and one to the west. You live to the south",
                "townsquare.jpg");

            newWorld.AddLocation(-1, 1, "Trading Shop", "The shop of a trader.","shop.jpg");
            newWorld.LocationAt(-1, 1).NpcHere = NpcFactory.GetNpcByName("River");

            newWorld.AddLocation(0, 2, "Back Alley", "It's not a nice place to linger.", "backalley.png");
            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            newWorld.AddLocation(99,99, "The other world", "You are dead, how sad.", "backalley.png");



            return newWorld;
        }
    }
}
