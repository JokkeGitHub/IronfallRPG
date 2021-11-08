using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Models.Item
{
    public class Recipe : GameItem
    {
        public Enum RecipeType { get; set; }
        public int QualityLowChance { get; set; }
        public int QualityNormalChance { get; set; }
        public int QualityHighChance { get; set; }
        public string Material1 { get; set; }
        public string Material2 { get; set; }
        public string Material3 { get; set; }
        public string Material4 { get; set; }

        public Recipe(int id, string name, string description, int value, bool isUnique, ItemCategory category, Enum recipeType, int qualityLowChance, int qualityNormalChance, int qualityHighChance, string material1, string material2, string material3, string material4)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsUnique = isUnique;
            Category = category;
            RecipeType = recipeType;
            QualityLowChance = qualityLowChance;
            QualityNormalChance = qualityNormalChance;
            QualityHighChance = qualityHighChance;
            Material1 = material1;
            Material2 = material2;
            Material3 = material3;
            Material4 = material4;
        }
    }
}
