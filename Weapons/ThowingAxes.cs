using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TerraheimItems.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace TerraheimItems.Weapons
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


            if ((bool)balance["ThrowingAxeFlint"]["enabled"])
            {
                ItemManager.Instance.AddRecipe(customRecipeFlint);
            }
            if ((bool)balance["ThrowingAxeBronze"]["enabled"])
            {
                ItemManager.Instance.AddRecipe(customRecipeBronze);
            }
            if ((bool)balance["ThrowingAxeIron"]["enabled"])
            {
                ItemManager.Instance.AddRecipe(customRecipeIron);
            }
            if ((bool)balance["ThrowingAxeSilver"]["enabled"])
            {
                ItemManager.Instance.AddRecipe(customRecipeSilver);
            }
            if ((bool)balance["ThrowingAxeBlackmetal"]["enabled"])
            {
                ItemManager.Instance.AddRecipe(customRecipeBlackmetal);
            }
        }

        private static void AddItem()
        {
            customItemFlint = new CustomItem(AssetHelper.ThrowingAxeFlintPrefab, true);
            customItemBronze = new CustomItem(AssetHelper.ThrowingAxeBronzePrefab, true);
            customItemIron = new CustomItem(AssetHelper.ThrowingAxeIronPrefab, true);
            customItemSilver = new CustomItem(AssetHelper.ThrowingAxeSilverPrefab, true);
            customItemBlackmetal = new CustomItem(AssetHelper.ThrowingAxeBlackmetalPrefab, true);

            UtilityFunctions.ModifyWeaponDamage(ref customItemFlint, balance["ThrowingAxeFlint"]);
            UtilityFunctions.ModifyWeaponDamage(ref customItemBronze, balance["ThrowingAxeBronze"]);
            UtilityFunctions.ModifyWeaponDamage(ref customItemIron, balance["ThrowingAxeIron"]);
            UtilityFunctions.ModifyWeaponDamage(ref customItemSilver, balance["ThrowingAxeSilver"]);
            UtilityFunctions.ModifyWeaponDamage(ref customItemBlackmetal, balance["ThrowingAxeBlackmetal"]);

            if ((bool)balance["ThrowingAxeFlint"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItemFlint);
            }
            if ((bool)balance["ThrowingAxeBronze"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItemBronze);
            }
            if ((bool)balance["ThrowingAxeIron"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItemIron);
            }
            if ((bool)balance["ThrowingAxeSilver"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItemSilver);
            }
            if ((bool)balance["ThrowingAxeBlackmetal"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItemBlackmetal);
            }
        }
    }
}
