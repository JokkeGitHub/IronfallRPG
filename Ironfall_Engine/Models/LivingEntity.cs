using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models
{
    public class LivingEntity
    {
        public string Name { get; set; }
        public int HpMax { get; set; }
        public int HpCurrent { get; set; }
        public int MpMax { get; set; }
        public int MpCurrent { get; set; }
        public int ApMax { get; set; }
        public int ApCurrent { get; set; }
        public int Defence { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public string Picture { get; set; }
    }
}
