using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using ValheimLib;
using ValheimLib.ODB;

namespace Terraheim.Weapons { 
    class KnifeIron
    {
        public static CustomItem customItem;
        public static CustomRecipe customRecipe;

        public const string TokenName = "$item_knife_iron";
        public const string TokenValue = "Iron Knife";

        public const string TokenDescriptionName = "$item_knife_iron_description";
        public const string TokenDescriptionValue = "A faint reminder of your former life.";

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
            recipe.m_item = AssetHelper.KnifeIronPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["KnifeIron"]);

            customRecipe = new CustomRecipe(recipe, true, true);
            ObjectDBHelper.Add(customRecipe);
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.KnifeIronPrefab, true);
            if ((bool)balance["KnifeIron"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["KnifeIron"]);
            }
            ObjectDBHelper.Add(customItem);
        }
    }
}
