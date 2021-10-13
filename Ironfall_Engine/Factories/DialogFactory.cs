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
            Dialog riverDialog10 = new Dialog(NpcFactory.GetNpcByName("River"), 10, "Welcome to my shop! How can I help you?", false, true);
            Dialog riverDialog1021 = new Dialog(NpcFactory.GetNpcByName("River"), 10.21, "Can I see your wares?", true, true);
            Dialog riverDialog1022 = new Dialog(NpcFactory.GetNpcByName("River"), 10.22, "Do you need help with anything?", true, true);
            Dialog riverDialog1023 = new Dialog(NpcFactory.GetNpcByName("River"), 10.23, "What are the rumors around town?", true, true);
            Dialog riverDialog1024 = new Dialog(NpcFactory.GetNpcByName("River"), 10.99, "Thank you for your time.", true, true);
            Dialog riverDialog21 = new Dialog(NpcFactory.GetNpcByName("River"), 21, "Sure! I am ready to trade anytime.", false, true);
            Dialog riverDialog22 = new Dialog(NpcFactory.GetNpcByName("River"), 22, "Yes I have problems with some bandits (Insert Quest here)", false, true);
            Dialog riverDialog23 = new Dialog(NpcFactory.GetNpcByName("River"), 23, "Well, I heard that the Mercenary Company The Iron Daggers are stealing from the bank!", false, true);
            Dialog riverDialog2331 = new Dialog(NpcFactory.GetNpcByName("River"), 23.31, "That is a blatant lie!", true, true);
            Dialog riverDialog2332 = new Dialog(NpcFactory.GetNpcByName("River"), 23.32, "That is very interesting...", true, true);
            Dialog riverDialog31 = new Dialog(NpcFactory.GetNpcByName("River"), 31, "What! Are you calling me a liar? You can leave then.", false, true);
            Dialog riverDialog32 = new Dialog(NpcFactory.GetNpcByName("River"), 32, "I know right! They are nothing but trouble.", false, true);
            Dialog riverDialog99 = new Dialog(NpcFactory.GetNpcByName("River"), 99, "Okay Bye!", false, true);

            AddDialogToList(riverDialog10);
            AddDialogToList(riverDialog1021);
            AddDialogToList(riverDialog1022);
            AddDialogToList(riverDialog1023);
            AddDialogToList(riverDialog1024);
            AddDialogToList(riverDialog21);
            AddDialogToList(riverDialog22);
            AddDialogToList(riverDialog23);
            AddDialogToList(riverDialog2331);
            AddDialogToList(riverDialog2332);
            AddDialogToList(riverDialog31);
            AddDialogToList(riverDialog32);
            AddDialogToList(riverDialog99);
        }

        public static Dialog GetDialogByID(int id)
        {
            return _listOfNpcDialog.FirstOrDefault(t => t.DialogId == id);
        }

        public static Dialog GetDialogByName(Npc npc)
        {
            return _listOfNpcDialog.FirstOrDefault(t => t.DialogNpc == npc);
        }

        private static void AddDialogToList(Dialog dialog)
        {
            if (_listOfNpcDialog.Any(t => t.DialogId == dialog.DialogId))
            {
                throw new ArgumentException($"There is already a Dialog with id '{dialog.DialogId}'");
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
                        npc.NpcDialogResponses.Add(dialog);
                    }
                }
            }
        }
    }
}
