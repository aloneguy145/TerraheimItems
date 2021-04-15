using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using ValheimLib;
using ValheimLib.ODB;

namespace Terraheim.Weapons
{
    class Bombs
    {
        public static CustomItem customItemFire;
        public static CustomRecipe customRecipeFire;

        public static CustomItem customItemFrost;
        public static CustomRecipe customRecipeFrost;

        public static CustomItem customItemLightning;
        public static CustomRecipe customRecipeLightning;

        public const string TokenNameFire = "$item_firebomb";
        public const string TokenValueFire = "Firebomb";

        public const string TokenDescriptionNameFire = "$item_firebomb_description";
        public const string TokenDescriptionValueFire = "A whiff of the ole brimstone...";

        public const string TokenNameFrost = "$item_frostbomb";
        public const string TokenValueFrost = "Frostbomb";

        public const string TokenDescriptionNameFrost = "$item_frostbomb_description";
        public const string TokenDescriptionValueFrost = "A piece of the artic in the palm of your hand.";

        public const string TokenNameLightning = "$item_lightningbomb";
        public const string TokenValueLightning = "Thunderbomb";

        public const string TokenDescriptionNameLightning = "$item_lightningbomb_description";
        public const string TokenDescriptionValueLightning = "Holding this makes the hairs on your neck stand on end...";

        public const string CraftingStationPrefabName = "piece_workbench";
        
        public const string TokenLanguage = "English";

        internal static void Init()
        {
            AddRecipe();
            AddItem();

            Language.AddToken(TokenNameFire, TokenValueFire, TokenLanguage);
            Language.AddToken(TokenDescriptionNameFire, TokenDescriptionValueFire, TokenLanguage);

            Language.AddToken(TokenNameFrost, TokenValueFrost, TokenLanguage);
            Language.AddToken(TokenDescriptionNameFrost, TokenDescriptionValueFrost, TokenLanguage);

            Language.AddToken(TokenNameLightning, TokenValueLightning, TokenLanguage);
            Language.AddToken(TokenDescriptionNameLightning, TokenDescriptionValueLightning, TokenLanguage);
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

            var itemReqsFrost = new List<Piece.Requirement>
            {
                MockRequirement.Create("FreezeGland", 5),
                MockRequirement.Create("Ooze", 5),
                MockRequirement.Create("LeatherScraps", 5),
            };

            var itemReqsLightning = new List<Piece.Requirement>
            {
                MockRequirement.Create("HardAntler", 1),
                MockRequirement.Create("Ooze", 5),
                MockRequirement.Create("LeatherScraps", 5),
            };

            recipeFire.m_resources = itemReqsFire.ToArray();
            recipeFrost.m_resources = itemReqsFrost.ToArray();
            recipeLightning.m_resources = itemReqsLightning.ToArray();

            recipeFire.m_craftingStation = Mock<CraftingStation>.Create(CraftingStationPrefabName);
            recipeFrost.m_craftingStation = Mock<CraftingStation>.Create(CraftingStationPrefabName);
            recipeLightning.m_craftingStation = Mock<CraftingStation>.Create(CraftingStationPrefabName);

            customRecipeFire = new CustomRecipe(recipeFire, true, true);
            customRecipeFrost = new CustomRecipe(recipeFrost, true, true);
            customRecipeLightning = new CustomRecipe(recipeLightning, true, true);

            ObjectDBHelper.Add(customRecipeFire);
            ObjectDBHelper.Add(customRecipeFrost);
            ObjectDBHelper.Add(customRecipeLightning);
        }

        private static void AddItem()
        {
            customItemFire = new CustomItem(AssetHelper.BombFirePrefab, true);
            customItemFrost = new CustomItem(AssetHelper.BombFrostPrefab, true);
            customItemLightning = new CustomItem(AssetHelper.BombLightningPrefab, true);

            ObjectDBHelper.Add(customItemFire);
            ObjectDBHelper.Add(customItemFrost);
            ObjectDBHelper.Add(customItemLightning);
        }
    }
}
