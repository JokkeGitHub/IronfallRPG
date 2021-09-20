using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Factories
{
    class ItemSlotFactory
    {
        public ItemSlot Create()
        {
            return new ItemSlot(
                        new Models.Item.Weapon(-1, "Right Hand", "Unarmed", 0, false, Models.Item.GameItem.ItemCategory.Weapon, Enums.ItemEnum.Weapon.OneHanded, 0, 0),
                        new Models.Item.Weapon(-1, "Left Hand", "Unarmed", 0, false, Models.Item.GameItem.ItemCategory.Weapon, Enums.ItemEnum.Weapon.OneHanded, 0, 0),
                        new Models.Item.Armor(-1, "Chest", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Armor, Enums.ItemEnum.Armor.Light, 0, 0),
                        new Models.Item.Artifact(-1, "Head", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Head),
                        new Models.Item.Artifact(-1, "Neck", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Neck),
                        new Models.Item.Artifact(-1, "Feet", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Feet),
                        new Models.Item.Artifact(-1, "Right Finger", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Finger),
                        new Models.Item.Artifact(-1, "Left Finger", "Unarmored", 0, false, Models.Item.GameItem.ItemCategory.Artefact, Enums.ItemEnum.Artifact.Finger)
                        );
        }
    }
}
