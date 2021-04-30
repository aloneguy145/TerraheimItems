using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using ValheimLib;
using ValheimLib.ODB;

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

            recipeMace.m_item = AssetHelper.MaceFirePrefab.GetComponent<ItemDrop>();
            recipeGS.m_item = AssetHelper.GreatswordFirePrefab.GetComponent<ItemDrop>();
            recipeAtgeir.m_item = AssetHelper.AtgeirFirePrefab.GetComponent<ItemDrop>();
            recipeBow.m_item = AssetHelper.BowFirePrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipeMace, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeGS, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeAtgeir, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeAtgeir, balance["AxeForstasca"]);

            maceRecipe = new CustomRecipe(recipeMace, true, true);
            gsRecipe = new CustomRecipe(recipeGS, true, true);
            atgeirRecipe = new CustomRecipe(recipeAtgeir, true, true);
            bowRecipe = new CustomRecipe(recipeBow, true, true);

            ObjectDBHelper.Add(maceRecipe);
            ObjectDBHelper.Add(gsRecipe);
            ObjectDBHelper.Add(atgeirRecipe);
            ObjectDBHelper.Add(bowRecipe);
        }

        private static void AddItem()
        {
            maceItem = new CustomItem(AssetHelper.MaceFirePrefab, true);
            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref maceItem, balance["AxeForstasca"]);
            }
            ObjectDBHelper.Add(maceItem);

            gsItem = new CustomItem(AssetHelper.GreatswordFirePrefab, true);
            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref gsItem, balance["AxeForstasca"]);
            }
            ObjectDBHelper.Add(gsItem);

            atgeirItem = new CustomItem(AssetHelper.AtgeirFirePrefab, true);
            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref atgeirItem, balance["AxeForstasca"]);
            }
            ObjectDBHelper.Add(atgeirItem);

            bowItem = new CustomItem(AssetHelper.BowFirePrefab, true);
            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref bowItem, balance["AxeForstasca"]);
            }
            ObjectDBHelper.Add(bowItem);
        }
    }
}
