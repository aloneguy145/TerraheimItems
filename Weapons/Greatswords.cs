using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using ValheimLib;
using ValheimLib.ODB;

namespace Terraheim.Weapons
{
    class Greatswords
    {
        public static CustomItem folcbrandItem;
        public static CustomRecipe folcbrandRecipe;
        public static CustomItem ironItem;
        public static CustomRecipe ironRecipe; 
        public static CustomItem blackmetalItem;
        public static CustomRecipe blackmetalRecipe;

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");


        internal static void Init()
        {
            AddRecipe();
            AddItem();
        }

        private static void AddRecipe()
        {
            var frRecipe = ScriptableObject.CreateInstance<Recipe>();
            var irRecipe = ScriptableObject.CreateInstance<Recipe>();
            var bmRecipe = ScriptableObject.CreateInstance<Recipe>();

            frRecipe.m_item = AssetHelper.FolcbrandPrefab.GetComponent<ItemDrop>();
            irRecipe.m_item = AssetHelper.GreatswordIronPrefab.GetComponent<ItemDrop>();
            bmRecipe.m_item = AssetHelper.GreatswordBlackmetalPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref frRecipe, balance["GreatswordFolcbrand"]);
            UtilityFunctions.GetRecipe(ref irRecipe, balance["GreatswordIron"]);
            UtilityFunctions.GetRecipe(ref bmRecipe, balance["GreatswordBlackmetal"]);


            folcbrandRecipe = new CustomRecipe(frRecipe, true, true);
            ironRecipe = new CustomRecipe(irRecipe, true, true);
            blackmetalRecipe = new CustomRecipe(bmRecipe, true, true);

            ObjectDBHelper.Add(folcbrandRecipe);
            ObjectDBHelper.Add(ironRecipe);
            ObjectDBHelper.Add(blackmetalRecipe);
        }

        private static void AddItem()
        {
            folcbrandItem = new CustomItem(AssetHelper.FolcbrandPrefab, true);
            ironItem = new CustomItem(AssetHelper.GreatswordIronPrefab, true);
            blackmetalItem = new CustomItem(AssetHelper.GreatswordBlackmetalPrefab, true);

            if ((bool)balance["GreatswordFolcbrand"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref folcbrandItem, balance["GreatswordFolcbrand"]);
            }
            if ((bool)balance["GreatswordIron"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref ironItem, balance["GreatswordIron"]);
            }
            if ((bool)balance["GreatswordBlackmetal"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref blackmetalItem, balance["GreatswordBlackmetal"]);
            }

            ObjectDBHelper.Add(folcbrandItem);
            ObjectDBHelper.Add(ironItem);
            ObjectDBHelper.Add(blackmetalItem);
        }
    }
}
