using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using ValheimLib;
using ValheimLib.ODB;

namespace Terraheim.Weapons
{
    class AtgeirSilver
    {
        public static CustomItem customItem;
        public static CustomRecipe customRecipe;

        public const string TokenName = "$item_atgeir_silver";
        public const string TokenValue = "Silver Kresja";

        public const string TokenDescriptionName = "$item_atgeir_silver_description";
        public const string TokenDescriptionValue = "A hewing spear whose cold blade invokes the pale frost.";

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
            recipe.m_item = AssetHelper.AtgeirSilverPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["AtgeirSilver"]);

            customRecipe = new CustomRecipe(recipe, true, true);
            ObjectDBHelper.Add(customRecipe);
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.AtgeirSilverPrefab, true);

            if ((bool)balance["AtgeirSilver"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["AtgeirSilver"]);
            }

            ObjectDBHelper.Add(customItem);
        }
    }
}
