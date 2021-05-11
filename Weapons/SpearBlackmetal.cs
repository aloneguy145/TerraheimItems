using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;


namespace Terraheim.Weapons
{
    class SpearBlackmetal
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
            recipe.m_item = AssetHelper.SpearBlackmetalPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["SpearBlackmetal"]);

            customRecipe = new CustomRecipe(recipe, true, true);
            ItemManager.Instance.AddRecipe(customRecipe);
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.SpearBlackmetalPrefab, true);
            UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["SpearBlackmetal"]);
            if ((bool)balance["SpearBlackmetal"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItem);
            }
        }
    }
}
