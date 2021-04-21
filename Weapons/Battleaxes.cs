using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using ValheimLib;
using ValheimLib.ODB;

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

            ObjectDBHelper.Add(customRecipe);
            ObjectDBHelper.Add(customRecipeBronze);
            ObjectDBHelper.Add(customRecipeBM);
            ObjectDBHelper.Add(customRecipeSil);
        }

        private static void AddItem()
        {
            customItem = new CustomItem(AssetHelper.BattleaxeBlackmetalPrefab, true);
            customItemBronze = new CustomItem(AssetHelper.BattleaxeBronzePrefab, true);
            customItemBM = new CustomItem(AssetHelper.GreateaxeBlackmetalPrefab, true);
            customItemSil = new CustomItem(AssetHelper.BattleaxeSilverPrefab, true);

            if ((bool)balance["BattleaxeBronze"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemBronze, balance["BattleaxeBronze"]);
            }
            if ((bool)balance["BattleaxeBlackmetal"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemBM, balance["BattleaxeBlackmetal"]);
            }
            if ((bool)balance["BattleaxeSilver"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemSil, balance["BattleaxeSilver"]);
            }
            if ((bool)balance["AxehammerBlackmetal"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["AxehammerBlackmetal"]);
            }

            ObjectDBHelper.Add(customItem);
            ObjectDBHelper.Add(customItemBronze);
            ObjectDBHelper.Add(customItemBM);
            ObjectDBHelper.Add(customItemSil);
        }
    }
}
