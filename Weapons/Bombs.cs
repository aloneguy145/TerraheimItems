using System.Collections.Generic;
using TerraheimItems.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace TerraheimItems.Weapons
{
    class Bombs
    {
        public static CustomItem customItemFire;
        public static CustomRecipe customRecipeFire;

        public static CustomItem customItemFrost;
        public static CustomRecipe customRecipeFrost;

        public static CustomItem customItemLightning;
        public static CustomRecipe customRecipeLightning;

        public const string CraftingStationPrefabName = "piece_workbench";
        
        internal static void Init()
        {
            AddRecipe();
            AddItem();
        }

        private static void AddRecipe()
        {
            var recipeFire = ScriptableObject.CreateInstance<Recipe>();
            var recipeFrost = ScriptableObject.CreateInstance<Recipe>();
            var recipeLightning = ScriptableObject.CreateInstance<Recipe>();

            recipeFire.m_item = AssetHelper.BombFirePrefab.GetComponent<ItemDrop>();
            recipeFrost.m_item = AssetHelper.BombFrostPrefab.GetComponent<ItemDrop>();
            recipeLightning.m_item = AssetHelper.BombLightningPrefab.GetComponent<ItemDrop>();

            var itemReqsFire = new List<Piece.Requirement>
            {
                MockRequirement.Create("Coal", 10),
                MockRequirement.Create("Ooze", 5),
                MockRequirement.Create("LeatherScraps", 5),
            };
            recipeFire.m_amount = 5;
            recipeFire.name = "Recipe_BombFire";
            var itemReqsFrost = new List<Piece.Requirement>
            {
                MockRequirement.Create("FreezeGland", 5),
                MockRequirement.Create("Ooze", 5),
                MockRequirement.Create("LeatherScraps", 5),
            };
            recipeFrost.m_amount = 5;
            recipeFrost.name = "Recipe_BombFrost";

            var itemReqsLightning = new List<Piece.Requirement>
            {
                MockRequirement.Create("HardAntler", 1),
                MockRequirement.Create("Ooze", 5),
                MockRequirement.Create("LeatherScraps", 5),
            };
            recipeLightning.m_amount = 5;
            recipeLightning.name = "Recipe_BombLightning";

            recipeFire.m_resources = itemReqsFire.ToArray();
            recipeFrost.m_resources = itemReqsFrost.ToArray();
            recipeLightning.m_resources = itemReqsLightning.ToArray();

            recipeFire.m_craftingStation = Mock<CraftingStation>.Create(CraftingStationPrefabName);
            recipeFrost.m_craftingStation = Mock<CraftingStation>.Create(CraftingStationPrefabName);
            recipeLightning.m_craftingStation = Mock<CraftingStation>.Create(CraftingStationPrefabName);

            customRecipeFire = new CustomRecipe(recipeFire, true, true);
            customRecipeFrost = new CustomRecipe(recipeFrost, true, true);
            customRecipeLightning = new CustomRecipe(recipeLightning, true, true);

            ItemManager.Instance.AddRecipe(customRecipeFire);
            ItemManager.Instance.AddRecipe(customRecipeFrost);
            ItemManager.Instance.AddRecipe(customRecipeLightning);
        }

        private static void AddItem()
        {
            customItemFire = new CustomItem(AssetHelper.BombFirePrefab, true);
            customItemFrost = new CustomItem(AssetHelper.BombFrostPrefab, true);
            customItemLightning = new CustomItem(AssetHelper.BombLightningPrefab, true);

            ItemManager.Instance.AddItem(customItemFire);
            ItemManager.Instance.AddItem(customItemFrost);
            ItemManager.Instance.AddItem(customItemLightning);
        }
    }
}
