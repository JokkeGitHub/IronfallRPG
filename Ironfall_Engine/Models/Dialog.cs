using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models
{
    class Dialog
    {
        public Npc DialogNpc { get; set; }
        public int DialogId { get; set; }
        public string DialogText { get; set; }
        public bool IsRecurring { get; set; }
        public int ResponseNmb { get; set; }


        public Dialog(Npc dialogNpc, int dialogId, string dialogText, bool isRecurring, int responseNmb)
        {
            DialogNpc = dialogNpc;
            DialogId = dialogId;
            DialogText = dialogText;
            IsRecurring = isRecurring;
            ResponseNmb = responseNmb;
        }
    }
}
