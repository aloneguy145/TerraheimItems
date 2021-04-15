using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using ValheimLib;
using ValheimLib.ODB;

namespace Terraheim.Weapons
{
    class SpearBlackmetal
    {
        public static CustomItem customItem;
        public static CustomRecipe customRecipe;

        public const string TokenName = "$item_spear_blackmetal";
        public const string TokenValue = "Blackmetal Spear";

        public const string TokenDescriptionName = "$item_spear_blackmetal_description";
        public const string TokenDescriptionValue = "A poised killer of unbreakable black iron.";

        public const string CraftingStationPrefabName = "forge";
        
        public const string TokenLanguage = "English";
        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

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
            recipe.m_item = AssetHelper.SpearBlackmetalPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["SpearBlackmetal"]);

            customRecipe = new CustomRecipe(recipe, true, true);
            ObjectDBHelper.Add(customRecipe);
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.SpearBlackmetalPrefab, true);
            if ((bool)balance["SpearBlackmetal"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["SpearBlackmetal"]);
            }
            ObjectDBHelper.Add(customItem);
        }
    }
}
