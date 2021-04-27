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

            recipeMace.m_item = AssetHelper.MaceFirePrefab.GetComponent<ItemDrop>();
            recipeGS.m_item = AssetHelper.GreatswordFirePrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipeMace, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeGS, balance["AxeForstasca"]);

            maceRecipe = new CustomRecipe(recipeMace, true, true);
            gsRecipe = new CustomRecipe(recipeGS, true, true);
            ObjectDBHelper.Add(maceRecipe);
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
        }
    }
}
