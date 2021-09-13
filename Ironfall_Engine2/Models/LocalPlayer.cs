using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models
{
    public class LocalPlayer : LivingEntity
    {
        public string CharacterClass { get; set; }
        public string UserID { get; set; }
        public int ExperiencePoints { get; set; }
        public int StatBody { get; set; }
        public int StatSpirit { get; set; }
        public int StatFellowship { get; set; }


    }
}
