using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine
{
    class RNG
    {
        // The Random Number Generator

        private static readonly Random _simpleNumberGenerator = new Random();

        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            return _simpleNumberGenerator.Next(minimumValue, maximumValue + 1);
        }
    }
}
