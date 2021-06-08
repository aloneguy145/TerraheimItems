using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TerraheimItems.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace TerraheimItems.Weapons { 
    class Knives
    {
        public static CustomItem customItem;
        public static CustomRecipe customRecipe;

        public static CustomItem customItemSil;
        public static CustomRecipe customRecipeSil;

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
            var recipeSil = ScriptableObject.CreateInstance<Recipe>();
            recipe.m_item = AssetHelper.KnifeIronPrefab.GetComponent<ItemDrop>();
            recipeSil.m_item = AssetHelper.KnifeSilverPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["KnifeIron"]);
            UtilityFunctions.GetRecipe(ref recipeSil, balance["KnifeSilver"]);

            customRecipe = new CustomRecipe(recipe, true, true);
            if ((bool)balance["KnifeIron"]["enabled"])
            {
                ItemManager.Instance.AddRecipe(customRecipe);
            }

            customRecipeSil = new CustomRecipe(recipeSil, true, true);
            if ((bool)balance["KnifeSilver"]["enabled"])
            {
                ItemManager.Instance.AddRecipe(customRecipeSil);
            }
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.KnifeIronPrefab, true);
            customItemSil = new CustomItem(AssetHelper.KnifeSilverPrefab, true);
            UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["KnifeIron"]);
            UtilityFunctions.ModifyWeaponDamage(ref customItemSil, balance["KnifeSilver"]);

            if ((bool)balance["KnifeIron"]["enabled"])
            {
                 ItemManager.Instance.AddItem(customItem);
            }

            if ((bool)balance["KnifeSilver"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItemSil);
            }
        }
    }
}
