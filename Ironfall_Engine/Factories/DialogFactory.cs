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
            Dialog riverDialog1 = new Dialog(NpcFactory.GetNpcByName("River"), 10, "Welcome to my shop! How can I help you?", false, true);
            Dialog riverDialog2 = new Dialog(NpcFactory.GetNpcByName("River"), 10.21, "Can I see your wares?", true, true);
            Dialog riverDialog3 = new Dialog(NpcFactory.GetNpcByName("River"), 10.22, "Do you need help with anything?", true, true);
            Dialog riverDialog4 = new Dialog(NpcFactory.GetNpcByName("River"), 10.23, "What are the rumors around town?", true, true);
            Dialog riverDialog5 = new Dialog(NpcFactory.GetNpcByName("River"), 10.24, "Thank you for your time.", true, true);
            Dialog riverDialog6 = new Dialog(NpcFactory.GetNpcByName("River"), 21, "Sure! I am ready to trade anytime.", false, true);
            Dialog riverDialog7 = new Dialog(NpcFactory.GetNpcByName("River"), 22, "Yes I have problems with some bandits (Insert Quest here)", false, true);
            Dialog riverDialog8 = new Dialog(NpcFactory.GetNpcByName("River"), 23, "Well, I heard that the Mercenary Company The Iron Daggers are stealing from the bank!", false, true);
            Dialog riverDialog8A = new Dialog(NpcFactory.GetNpcByName("River"), 23.31, "That is a blatant lie!", true, true);
            Dialog riverDialog8B = new Dialog(NpcFactory.GetNpcByName("River"), 23.32, "That is very interesting...", true, true);
            Dialog riverDialog9 = new Dialog(NpcFactory.GetNpcByName("River"), 24, "Okay Bye!", false, true);

            AddDialogToList(riverDialog1);
            AddDialogToList(riverDialog2);
            AddDialogToList(riverDialog3);
            AddDialogToList(riverDialog4);
            AddDialogToList(riverDialog5);
            AddDialogToList(riverDialog6);
            AddDialogToList(riverDialog7);
            AddDialogToList(riverDialog8);
            AddDialogToList(riverDialog8A);
            AddDialogToList(riverDialog8B);
            AddDialogToList(riverDialog9);
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
