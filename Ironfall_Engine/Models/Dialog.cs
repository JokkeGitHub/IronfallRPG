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
        public double DialogID { get; set; }
        public double DialogNumber { get; set; }
        public string DialogText { get; set; }
        public int DialogQuestId { get; set; }
        public bool IsResponse { get; set; }
        public bool IsRecurring { get; set; }
        public bool IsUsed { get; set; }

        public Dialog(Npc dialogNpc, double dialogID, double dialogNumber, string dialogText, int dialogQuestId, bool isResponse, bool isRecurring, bool isUsed = false)
        {
            DialogNpc = dialogNpc;
            DialogID = dialogID;
            DialogNumber = dialogNumber;
            DialogText = dialogText;
            DialogQuestId = dialogQuestId;
            IsResponse = isResponse;
            IsRecurring = isRecurring;
            IsUsed = isUsed;
        }
    }
}
