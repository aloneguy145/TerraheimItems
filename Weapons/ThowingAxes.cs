using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.Weapons
{
    class ThrowingAxes
    {
        public static CustomItem customItemFlint;
        public static CustomRecipe customRecipeFlint; 
        public static CustomItem customItemBronze;
        public static CustomRecipe customRecipeBronze;
        public static CustomItem customItemIron;
        public static CustomRecipe customRecipeIron;
        public static CustomItem customItemSilver;
        public static CustomRecipe customRecipeSilver;
        public static CustomItem customItemBlackmetal;
        public static CustomRecipe customRecipeBlackmetal;

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        internal static void Init()
        {
            AddRecipe();
            AddItem();
        }

        private static void AddRecipe()
        {
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            var recipeBronze = ScriptableObject.CreateInstance<Recipe>();
            var recipeIron = ScriptableObject.CreateInstance<Recipe>();
            var recipeSilver = ScriptableObject.CreateInstance<Recipe>();
            var recipeBlackmetal = ScriptableObject.CreateInstance<Recipe>();

            recipe.m_item = AssetHelper.ThrowingAxeFlintPrefab.GetComponent<ItemDrop>();
            recipeBronze.m_item = AssetHelper.ThrowingAxeBronzePrefab.GetComponent<ItemDrop>();
            recipeIron.m_item = AssetHelper.ThrowingAxeIronPrefab.GetComponent<ItemDrop>();
            recipeSilver.m_item = AssetHelper.ThrowingAxeSilverPrefab.GetComponent<ItemDrop>();
            recipeBlackmetal.m_item = AssetHelper.ThrowingAxeBlackmetalPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["ThrowingAxeFlint"]);
            UtilityFunctions.GetRecipe(ref recipeBronze, balance["ThrowingAxeBronze"]);
            UtilityFunctions.GetRecipe(ref recipeIron, balance["ThrowingAxeIron"]);
            UtilityFunctions.GetRecipe(ref recipeSilver, balance["ThrowingAxeSilver"]);
            UtilityFunctions.GetRecipe(ref recipeBlackmetal, balance["ThrowingAxeBlackmetal"]);

            customRecipeFlint = new CustomRecipe(recipe, true, true);
            customRecipeBronze = new CustomRecipe(recipeBronze, true, true);
            customRecipeIron = new CustomRecipe(recipeIron, true, true);
            customRecipeSilver = new CustomRecipe(recipeSilver, true, true);
            customRecipeBlackmetal = new CustomRecipe(recipeBlackmetal, true, true);

            ItemManager.Instance.AddRecipe(customRecipeFlint);
            ItemManager.Instance.AddRecipe(customRecipeBronze);
            ItemManager.Instance.AddRecipe(customRecipeIron);
            ItemManager.Instance.AddRecipe(customRecipeSilver);
            ItemManager.Instance.AddRecipe(customRecipeBlackmetal);
        }

        private static void AddItem()
        {
            customItemFlint = new CustomItem(AssetHelper.ThrowingAxeFlintPrefab, true);
            customItemBronze = new CustomItem(AssetHelper.ThrowingAxeBronzePrefab, true);
            customItemIron = new CustomItem(AssetHelper.ThrowingAxeIronPrefab, true);
            customItemSilver = new CustomItem(AssetHelper.ThrowingAxeSilverPrefab, true);
            customItemBlackmetal = new CustomItem(AssetHelper.ThrowingAxeBlackmetalPrefab, true);

            if ((bool)balance["ThrowingAxeFlint"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemFlint, balance["ThrowingAxeFlint"]);
            }
            if ((bool)balance["ThrowingAxeBronze"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemBronze, balance["ThrowingAxeBronze"]);
            }
            if ((bool)balance["ThrowingAxeIron"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemIron, balance["ThrowingAxeIron"]);
            }
            if ((bool)balance["ThrowingAxeSilver"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemSilver, balance["ThrowingAxeSilver"]);
            }
            if ((bool)balance["ThrowingAxeBlackmetal"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemBlackmetal, balance["ThrowingAxeBlackmetal"]);
            }

            ItemManager.Instance.AddItem(customItemFlint);
            ItemManager.Instance.AddItem(customItemBronze);
            ItemManager.Instance.AddItem(customItemIron);
            ItemManager.Instance.AddItem(customItemSilver);
            ItemManager.Instance.AddItem(customItemBlackmetal);
        }
    }
}
