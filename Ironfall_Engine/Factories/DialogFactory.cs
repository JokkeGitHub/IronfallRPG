using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Models;

namespace Ironfall_Engine.Factories
{
    class DialogFactory
    {
        private static readonly ObservableCollection<Dialog> _listOfNpcDialog = new ObservableCollection<Dialog>();

        static DialogFactory()
        {
            /// Dialogue, how does it work?
            /// A dialog has an id that is a double and a response bool. The response bool help sorts into the things the npc says
            /// and lines the player can say. If the double has a decimal, it means it will continue. So 10.XX means it's a follow up to
            /// 10. Then the dialogue goes to 23 and then the responses is 23.XX and so on.
            
            // 98 Trade, 99 is exit. 96 Starts Quest, 97 checks if it's complete. 
            //Dialog ID NpcID + Dialog Number
            Dialog riverDialog10 = new Dialog(NpcFactory.GetNpcByName("River"), 110, 10, "Welcome to my shop! How can I help you?", 0, false, true);
            Dialog riverDialog1023 = new Dialog(NpcFactory.GetNpcByName("River"), 110.23, 10.23, "What are the rumors around town?", 0, true, true);
            Dialog riverDialog1096 = new Dialog(NpcFactory.GetNpcByName("River"), 110.96, 10.96, "Do you need help with anything?", 0, true, false);
            Dialog riverDialog1097 = new Dialog(NpcFactory.GetNpcByName("River"), 110.97, 10.97, "I have killed the bandits", 1, true, true, true);
            Dialog riverDialog1098 = new Dialog(NpcFactory.GetNpcByName("River"), 110.98, 10.98, "Can I see your wares?", 0, true, true);
            Dialog riverDialog1099 = new Dialog(NpcFactory.GetNpcByName("River"), 110.98, 10.99, "Thank you for your time.", 0, true, true);
            Dialog riverDialog23 = new Dialog(NpcFactory.GetNpcByName("River"), 123, 23, "Well, I heard that the Mercenary Company The Iron Daggers are stealing from the bank!", 0, false, true);
            Dialog riverDialog2331 = new Dialog(NpcFactory.GetNpcByName("River"), 123.31, 23.31, "That is a blatant lie!", 0, true, true);
            Dialog riverDialog2332 = new Dialog(NpcFactory.GetNpcByName("River"), 123.32, 23.32, "That is very interesting...", 0, true, true);
            Dialog riverDialog31 = new Dialog(NpcFactory.GetNpcByName("River"), 131, 31, "What! Are you calling me a liar? You can leave then.", 0, false, true);
            Dialog riverDialog32 = new Dialog(NpcFactory.GetNpcByName("River"), 132, 32, "I know right! They are nothing but trouble.", 0, false, true);
            Dialog riverDialog96 = new Dialog(NpcFactory.GetNpcByName("River"), 196, 96, "Yes I have problems with some bandits (Questlog Updated)", 1, false, true);
            Dialog riverDialog97 = new Dialog(NpcFactory.GetNpcByName("River"), 197, 97, "", 1, false, true);
            Dialog riverDialog9701 = new Dialog(NpcFactory.GetNpcByName("River"), 197.01, 97.01, "Oh you are god send! Thank you so much!", 1, false, true);
            Dialog riverDialog9702 = new Dialog(NpcFactory.GetNpcByName("River"), 197.02, 97.02, "Sorry, but you are not done.", 1, false, true);
            Dialog riverDialog98 = new Dialog(NpcFactory.GetNpcByName("River"), 198, 98, "Sure! I am ready to trade anytime.", 0, false, true);
            Dialog riverDialog99 = new Dialog(NpcFactory.GetNpcByName("River"), 199, 99, "Okay Bye!", 0, false, true);

            AddDialogToList(riverDialog10);
            AddDialogToList(riverDialog1023);
            AddDialogToList(riverDialog1096);
            AddDialogToList(riverDialog1097);
            AddDialogToList(riverDialog1098);
            AddDialogToList(riverDialog1099);
            AddDialogToList(riverDialog23);
            AddDialogToList(riverDialog2331);
            AddDialogToList(riverDialog2332);
            AddDialogToList(riverDialog31);
            AddDialogToList(riverDialog32);
            AddDialogToList(riverDialog96);
            AddDialogToList(riverDialog97);
            AddDialogToList(riverDialog9701);
            AddDialogToList(riverDialog9702);
            AddDialogToList(riverDialog98);
            AddDialogToList(riverDialog99);
        }

        public static Dialog GetDialogByID(double id)
        {
            return _listOfNpcDialog.FirstOrDefault(t => t.DialogID == id);
        }

        public static Dialog GetDialogByName(Npc npc)
        {
            return _listOfNpcDialog.FirstOrDefault(t => t.DialogNpc == npc);
        }

        private static void AddDialogToList(Dialog dialog)
        {
            if (_listOfNpcDialog.Any(t => t.DialogNumber == dialog.DialogNumber))
            {
                throw new ArgumentException($"There is already a Dialog with id '{dialog.DialogNumber}'");
            }
            _listOfNpcDialog.Add(dialog);
        }

        public static void AddDialogToNpc(Npc npc)
        {
            if (npc != null)
            {
                foreach (Dialog dialog in _listOfNpcDialog)
                {
                    if (dialog.DialogNpc.Name == npc.Name && dialog.IsResponse == false)
                    {
                        npc.NpcDialog.Add(dialog);
                    }
                    else if (dialog.DialogNpc.Name == npc.Name && dialog.IsResponse == true)
                    {
                        npc.PlayerDialogResponses.Add(dialog);
                    }
                }
            }
        }
    }
}
