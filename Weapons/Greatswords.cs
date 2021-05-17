using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TerraheimItems.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace TerraheimItems.Weapons
{
    class Greatswords
    {
        public static CustomItem folcbrandItem;
        public static CustomRecipe folcbrandRecipe;
        public static CustomItem ironItem;
        public static CustomRecipe ironRecipe; 
        public static CustomItem blackmetalItem;
        public static CustomRecipe blackmetalRecipe;
        public static CustomItem chitinItem;
        public static CustomRecipe chitinRecipe;

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
            var chRecipe = ScriptableObject.CreateInstance<Recipe>();

            frRecipe.m_item = AssetHelper.FolcbrandPrefab.GetComponent<ItemDrop>();
            irRecipe.m_item = AssetHelper.GreatswordIronPrefab.GetComponent<ItemDrop>();
            bmRecipe.m_item = AssetHelper.GreatswordBlackmetalPrefab.GetComponent<ItemDrop>();
            chRecipe.m_item = AssetHelper.GreatswordChitinPrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref frRecipe, balance["GreatswordFolcbrand"]);
            UtilityFunctions.GetRecipe(ref irRecipe, balance["GreatswordIron"]);
            UtilityFunctions.GetRecipe(ref bmRecipe, balance["GreatswordBlackmetal"]);
            UtilityFunctions.GetRecipe(ref chRecipe, balance["GreatswordChitin"]);


            folcbrandRecipe = new CustomRecipe(frRecipe, true, true);
            ironRecipe = new CustomRecipe(irRecipe, true, true);
            blackmetalRecipe = new CustomRecipe(bmRecipe, true, true);
            chitinRecipe = new CustomRecipe(chRecipe, true, true);


            if ((bool)balance["GreatswordFolcbrand"]["enabled"])
                ItemManager.Instance.AddRecipe(folcbrandRecipe);
            if ((bool)balance["GreatswordIron"]["enabled"])
                ItemManager.Instance.AddRecipe(ironRecipe);
            if ((bool)balance["GreatswordBlackmetal"]["enabled"])
                ItemManager.Instance.AddRecipe(blackmetalRecipe);
            if ((bool)balance["GreatswordChitin"]["enabled"])
                ItemManager.Instance.AddRecipe(chitinRecipe);
        }

        private static void AddItem()
        {
            folcbrandItem = new CustomItem(AssetHelper.FolcbrandPrefab, true);
            ironItem = new CustomItem(AssetHelper.GreatswordIronPrefab, true);
            blackmetalItem = new CustomItem(AssetHelper.GreatswordBlackmetalPrefab, true);
            chitinItem = new CustomItem(AssetHelper.GreatswordChitinPrefab, true);

            UtilityFunctions.ModifyWeaponDamage(ref folcbrandItem, balance["GreatswordFolcbrand"]);
            UtilityFunctions.ModifyWeaponDamage(ref ironItem, balance["GreatswordIron"]);
            UtilityFunctions.ModifyWeaponDamage(ref blackmetalItem, balance["GreatswordBlackmetal"]);
            UtilityFunctions.ModifyWeaponDamage(ref chitinItem, balance["GreatswordChitin"]);

            if ((bool)balance["GreatswordFolcbrand"]["enabled"])
                ItemManager.Instance.AddItem(folcbrandItem);
            if ((bool)balance["GreatswordIron"]["enabled"])
                ItemManager.Instance.AddItem(ironItem);
            if ((bool)balance["GreatswordBlackmetal"]["enabled"])
                ItemManager.Instance.AddItem(blackmetalItem);
            if ((bool)balance["GreatswordChitin"]["enabled"])
                ItemManager.Instance.AddItem(chitinItem);

        }
    }
}
