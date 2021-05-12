using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.Weapons
{
    class Javelins
    {
        public static CustomItem customItemFlint;
        public static CustomRecipe customRecipeFlint;
        public static CustomItem customItemBronze;
        public static CustomRecipe customRecipeBronze;

        public const string TokenNameFlint = "$item_javelin_flint";
        public const string TokenValueFlint = "Flint Javelin";

        public const string TokenDescriptionFlintName = "$item_javelin_flint_description";
        public const string TokenDescriptionFlintValue = "A crude javelin, but it will do in a pinch.";

        public const string CraftingStationPrefabName = "piece_workbench";

        public const string TokenLanguage = "English";

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        internal static void Init()
        {
            AddRecipe();
            AddItem();
            /*
            Language.AddToken(TokenNameFlint, TokenValueFlint, TokenLanguage);
            Language.AddToken(TokenDescriptionFlintName, TokenDescriptionFlintValue, TokenLanguage);
            Language.AddToken("$item_javelin_bronze", "Bronze Javelin", TokenLanguage);
            Language.AddToken("$item_javelin_bronze_description", "A bronze javelin. Effective, but uninteresting.", TokenLanguage);*/
        }

        private static void AddRecipe()
        {
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            var recipeBronze = ScriptableObject.CreateInstance<Recipe>();

            recipe.m_item = AssetHelper.JavelinFlintPrefab.GetComponent<ItemDrop>();
            recipeBronze.m_item = AssetHelper.JavelinBronzePrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["JavelinFlint"]);
            UtilityFunctions.GetRecipe(ref recipeBronze, balance["JavelinBronze"]);

            customRecipeFlint = new CustomRecipe(recipe, true, true);
            customRecipeBronze = new CustomRecipe(recipeBronze, true, true);

            ItemManager.Instance.AddRecipe(customRecipeFlint);
            ItemManager.Instance.AddRecipe(customRecipeBronze);
        }

        private static void AddItem()
        {
            customItemFlint = new CustomItem(AssetHelper.JavelinFlintPrefab, true);
            customItemBronze = new CustomItem(AssetHelper.JavelinBronzePrefab, true);

            if ((bool)balance["JavelinFlint"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemFlint, balance["JavelinFlint"]);
            }
            if ((bool)balance["JavelinBronze"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemBronze, balance["JavelinBronze"]);
            }

            ItemManager.Instance.AddItem(customItemFlint);
            ItemManager.Instance.AddItem(customItemBronze);
        }
    }
}
