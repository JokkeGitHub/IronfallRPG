using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models
{
    public class Dialog
    {
        public Npc DialogNpc { get; set; }
        public int DialogId { get; set; }
        public string DialogText { get; set; }
        public bool IsResponse { get; set; }
        public bool IsRecurring { get; set; }

        public Dialog(Npc dialogNpc, int dialogId, string dialogText, bool isResponse, bool isRecurring)
        {
            DialogNpc = dialogNpc;
            DialogId = dialogId;
            DialogText = dialogText;
            IsResponse = isResponse;
            IsRecurring = isRecurring;
        }
    }
}
