using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using ValheimLib;
using ValheimLib.ODB;

namespace Terraheim.Weapons
{
    class TorchOlympia
    {
        public static CustomItem customItem;
        public static CustomRecipe customRecipe;

        public const string CraftingStationPrefabName = "piece_workbench";
        
        internal static void Init()
        {
            AddRecipe();
            AddItem();
        }

        private static void AddRecipe()
        {
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.m_item = AssetHelper.TorchOlympiaPrefab.GetComponent<ItemDrop>();

            var itemReqs = new List<Piece.Requirement>
            {
                MockRequirement.Create("HelmetYule", 1),
                MockRequirement.Create("Flametal", 70),
                MockRequirement.Create("YagluthDrop", 100),
                MockRequirement.Create("YmirRemains", 20),
            };

            recipe.m_resources = itemReqs.ToArray();
            recipe.m_craftingStation = Mock<CraftingStation>.Create(CraftingStationPrefabName);
            customRecipe = new CustomRecipe(recipe, true, true);
            ObjectDBHelper.Add(customRecipe);
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.TorchOlympiaPrefab, true);
            ObjectDBHelper.Add(customItem);
        }
    }
}
