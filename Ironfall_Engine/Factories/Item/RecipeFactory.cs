using Ironfall_Engine.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ironfall_Engine.Factories.Item
{
    class RecipeFactory
    {
        public Recipe Create(int id, string name, string description, int value, bool isUnique, GameItem.ItemCategory category, Enum recipeType, int qualityLowChance, int qualityNormalChance, int qualityHighChance, string material1, string material2, string material3, string material4)
        {
            return new Recipe(id, name, description, value, isUnique, category, recipeType, qualityLowChance, qualityNormalChance, qualityHighChance, material1, material2, material3, material4);
        }
    }
}