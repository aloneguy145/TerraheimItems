using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.Weapons
{
    class Battleaxes
    {
        public static CustomItem customItem;
        public static CustomRecipe customRecipe;
        public static CustomItem customItemBronze;
        public static CustomRecipe customRecipeBronze;
        public static CustomItem customItemBM;
        public static CustomRecipe customRecipeBM;
        public static CustomItem customItemSil;
        public static CustomRecipe customRecipeSil;


        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        internal static void Init()
        {
            AddRecipe();
            AddItem();
        }

        private static void AddRecipe()
        {
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            var recipeBR = ScriptableObject.CreateInstance<Recipe>();
            var recipeBM = ScriptableObject.CreateInstance<Recipe>();
            var recipeSil = ScriptableObject.CreateInstance<Recipe>();

            recipe.m_item = AssetHelper.BattleaxeBlackmetalPrefab.GetComponent<ItemDrop>();
            recipeBR.m_item = AssetHelper.BattleaxeBronzePrefab.GetComponent<ItemDrop>();
            recipeBM.m_item = AssetHelper.GreateaxeBlackmetalPrefab.GetComponent<ItemDrop>();
            recipeSil.m_item = AssetHelper.BattleaxeSilverPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["AxehammerBlackmetal"]);

            UtilityFunctions.GetRecipe(ref recipeBM, balance["BattleaxeBlackmetal"]);

            UtilityFunctions.GetRecipe(ref recipeBR, balance["BattleaxeBronze"]);

            UtilityFunctions.GetRecipe(ref recipeSil, balance["BattleaxeSilver"]);

            customRecipe = new CustomRecipe(recipe, true, true);
            customRecipeBronze = new CustomRecipe(recipeBR, true, true);
            customRecipeBM = new CustomRecipe(recipeBM, true, true);
            customRecipeSil = new CustomRecipe(recipeSil, true, true);

            ItemManager.Instance.AddRecipe(customRecipe);
            ItemManager.Instance.AddRecipe(customRecipeBronze);
            ItemManager.Instance.AddRecipe(customRecipeBM);
            ItemManager.Instance.AddRecipe(customRecipeSil);
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.BattleaxeBlackmetalPrefab, true);
            customItemBronze = new CustomItem(AssetHelper.BattleaxeBronzePrefab, true);
            customItemBM = new CustomItem(AssetHelper.GreateaxeBlackmetalPrefab, true);
            customItemSil = new CustomItem(AssetHelper.BattleaxeSilverPrefab, true);
            
            UtilityFunctions.ModifyWeaponDamage(ref customItemBronze, balance["BattleaxeBronze"]);
            UtilityFunctions.ModifyWeaponDamage(ref customItemBM, balance["BattleaxeBlackmetal"]);
            UtilityFunctions.ModifyWeaponDamage(ref customItemSil, balance["BattleaxeSilver"]);
            UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["AxehammerBlackmetal"]);

            if ((bool)balance["BattleaxeBronze"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItem);
            }
            if ((bool)balance["BattleaxeBlackmetal"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItemBronze);
            }
            if ((bool)balance["BattleaxeSilver"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItemBM);
            }
            if ((bool)balance["AxehammerBlackmetal"]["enabled"])
            {
                ItemManager.Instance.AddItem(customItemSil);
            }
        }
    }
}
