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

        public const string TokenName = "$item_torch_olympia";
        public const string TokenValue = "O L Y M P I A";

        public const string TokenDescriptionName = "$item_torch_olympia_description";
        public const string TokenDescriptionValue = "Some dude in a toga gave you this...";

        public const string CraftingStationPrefabName = "piece_workbench";
        
        public const string TokenLanguage = "English";

        internal static void Init()
        {
            AddRecipe();
            AddItem();

            Language.AddToken(TokenName, TokenValue, TokenLanguage);
            Language.AddToken(TokenDescriptionName, TokenDescriptionValue, TokenLanguage);
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
