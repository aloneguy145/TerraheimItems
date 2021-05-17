using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TerraheimItems.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace TerraheimItems.Weapons
{
    class AxeForstasca
    {
        public static CustomItem customItem;
        public static CustomRecipe customRecipe;
        public static CustomItem serpItem;
        public static CustomRecipe serpRecipe;

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        internal static void Init()
        {
            AddRecipe();
            AddItem();
        }

        private static void AddRecipe()
        {
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            var recipeSerp = ScriptableObject.CreateInstance<Recipe>();
            recipe.m_item = AssetHelper.AxeForstascaPrefab.GetComponent<ItemDrop>();
            recipeSerp.m_item = AssetHelper.AxeSerpentPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeSerp, balance["AxeSerpent"]);

            customRecipe = new CustomRecipe(recipe, true, true);
            serpRecipe = new CustomRecipe(recipe, true, true);

            if ((bool)balance["AxeForstasca"]["enabled"])
                ItemManager.Instance.AddRecipe(customRecipe);
            if ((bool)balance["AxeSerpent"]["enabled"])
                ItemManager.Instance.AddRecipe(serpRecipe);
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.AxeForstascaPrefab, true);
            serpItem = new CustomItem(AssetHelper.AxeSerpentPrefab, true);

            UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["AxeForstasca"]);
            UtilityFunctions.ModifyWeaponDamage(ref serpItem, balance["AxeSerpent"], "<i>Axe</i>\n", $"\n\nThe secondary attack summons a bolt of lightning to the targeted location, dealing <color=cyan>{(float)balance["AxeSerpent"]["effectVal"]}</color> damage.");

            if ((bool)balance["AxeForstasca"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItem);
            }

            if ((bool)balance["AxeSerpent"]["enabled"])
            {
                ItemManager.Instance.AddItem(serpItem);
            }
        }
    }
}
