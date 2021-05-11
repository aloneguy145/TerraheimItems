using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.Weapons
{
    class AxeForstasca
    {
        public static CustomItem customItem;
        public static CustomRecipe customRecipe;

        public const string CraftingStationPrefabName = "forge";
        
        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        internal static void Init()
        {
            AddRecipe();
            AddItem();
        }

        private static void AddRecipe()
        {
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.m_item = AssetHelper.AxeForstascaPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["AxeForstasca"]);

            customRecipe = new CustomRecipe(recipe, true, true);
            ItemManager.Instance.AddRecipe(customRecipe);
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.AxeForstascaPrefab, true);
            UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["AxeForstasca"]);
            
            if ((bool)balance["AxeForstasca"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItem);
            }
        }
    }
}
