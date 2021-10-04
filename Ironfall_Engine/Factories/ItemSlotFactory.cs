using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ironfall_Engine.Factories.Item;
using Ironfall_Engine.Models.Item;

namespace Ironfall_Engine.Factories
{
    class ItemSlotFactory
    {
        public ItemSlot Create()
        {
            WeaponFactory weaponFactory = new WeaponFactory();
            ArmorFactory armorFactory = new ArmorFactory();
            ArtifactFactory artifactFactory = new ArtifactFactory();

            Artifact head = artifactFactory.GetEmptyHead();
            Artifact neck = artifactFactory.GetEmptyNeck();
            Armor chest = armorFactory.GetEmptyChest();
            Weapon mainHand = weaponFactory.GetEmptyMainHand();
            Weapon offHand = weaponFactory.GetEmptyOffHand();
            Artifact fingerRight = artifactFactory.GetEmptyFingerRight();
            Artifact fingerLeft = artifactFactory.GetEmptyFingerLeft();
            Artifact feet = artifactFactory.GetEmptyFeet();

            return new ItemSlot(head, neck, chest, mainHand, offHand, fingerRight, fingerLeft, feet);
        }
    }
}
