using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Interfaces.Item
{
    interface IEnchantment
    {
        int Effect(int effect, int affectedStat);
    }
}
