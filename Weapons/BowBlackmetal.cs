using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;



namespace Terraheim.Weapons
{
    class BowBlackmetal
    {
        public static CustomItem customItem;
        public static CustomRecipe customRecipe;

        public const string TokenLanguage = "English";

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        internal static void Init()
        {
            AddRecipe();
            AddItem();
        }

        private static void AddRecipe()
        {
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.m_item = AssetHelper.BowBlackmetalPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["BowBlackmetal"]);

            customRecipe = new CustomRecipe(recipe, true, true);
            ItemManager.Instance.AddRecipe(customRecipe);
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.BowBlackmetalPrefab, true);
            if ((bool)balance["BowBlackmetal"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["BowBlackmetal"]);
            }
            ItemManager.Instance.AddItem(customItem);
        }
    }
}
