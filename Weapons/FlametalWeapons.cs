using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.Weapons
{
    class FlametalWeapons
    {
        public static CustomItem maceItem;
        public static CustomRecipe maceRecipe;
        public static CustomItem gsItem;
        public static CustomRecipe gsRecipe;
        public static CustomItem atgeirItem;
        public static CustomRecipe atgeirRecipe;
        public static CustomItem bowItem;
        public static CustomRecipe bowRecipe;
        public static CustomItem gaxeItem;
        public static CustomRecipe gaxeRecipe;

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        internal static void Init()
        {
            AddRecipe();
            AddItem();
        }

        private static void AddRecipe()
        {
            var recipeMace = ScriptableObject.CreateInstance<Recipe>();
            var recipeGS = ScriptableObject.CreateInstance<Recipe>();
            var recipeAtgeir = ScriptableObject.CreateInstance<Recipe>();
            var recipeBow = ScriptableObject.CreateInstance<Recipe>();
            var recipeGaxe = ScriptableObject.CreateInstance<Recipe>();

            recipeMace.m_item = AssetHelper.MaceFirePrefab.GetComponent<ItemDrop>();
            recipeGS.m_item = AssetHelper.GreatswordFirePrefab.GetComponent<ItemDrop>();
            recipeAtgeir.m_item = AssetHelper.AtgeirFirePrefab.GetComponent<ItemDrop>();
            recipeBow.m_item = AssetHelper.BowFirePrefab.GetComponent<ItemDrop>();
            recipeGaxe.m_item = AssetHelper.BattleaxeFirePrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipeMace, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeGS, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeBow, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeAtgeir, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeGaxe, balance["AxeForstasca"]);

            maceRecipe = new CustomRecipe(recipeMace, true, true);
            gsRecipe = new CustomRecipe(recipeGS, true, true);
            atgeirRecipe = new CustomRecipe(recipeAtgeir, true, true);
            bowRecipe = new CustomRecipe(recipeBow, true, true);
            gaxeRecipe = new CustomRecipe(recipeGaxe, true, true);

            ItemManager.Instance.AddRecipe(maceRecipe);
            ItemManager.Instance.AddRecipe(gsRecipe);
            ItemManager.Instance.AddRecipe(atgeirRecipe);
            ItemManager.Instance.AddRecipe(bowRecipe);
            ItemManager.Instance.AddRecipe(gaxeRecipe);
        }

        private static void AddItem()
        {
            maceItem = new CustomItem(AssetHelper.MaceFirePrefab, true);
            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref maceItem, balance["AxeForstasca"]);
            }
            ItemManager.Instance.AddItem(maceItem);

            gsItem = new CustomItem(AssetHelper.GreatswordFirePrefab, true);
            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref gsItem, balance["AxeForstasca"]);
            }
            ItemManager.Instance.AddItem(gsItem);

            atgeirItem = new CustomItem(AssetHelper.AtgeirFirePrefab, true);
            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref atgeirItem, balance["AxeForstasca"]);
            }
            //atgeirItem.ItemDrop.m_itemData.m_shared.m_description += $"\nFoes struck by its secondary attack will suffer damage equal to <color=cyan>{(float)balance["AtgeirFire"]["effectVal"]*100}%</color> of their Current HP after 1.3 seconds.";
            ItemManager.Instance.AddItem(atgeirItem);

            bowItem = new CustomItem(AssetHelper.BowFirePrefab, true);
            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref bowItem, balance["AxeForstasca"]);
            }
            ItemManager.Instance.AddItem(bowItem);

            gaxeItem = new CustomItem(AssetHelper.BattleaxeFirePrefab, true);
            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref gaxeItem, balance["AxeForstasca"]);
            }
            ItemManager.Instance.AddItem(gaxeItem);
        }
    }
}
