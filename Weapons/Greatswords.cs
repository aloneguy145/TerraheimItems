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

        public const string TokenName = "$item_greatsword_folcbrand";
        public const string TokenValue = "Folcbrand";

        public const string IronTokenName = "$item_greatsword_iron";
        public const string IronTokenValue = "Iron Greatsword";

        public const string BMTokenName = "$item_greatsword_blackmetal";
        public const string BMTokenValue = "Blackmetal Greatsword";

        public const string TokenDescriptionName = "$item_greatsword_iron_description";
        public const string TokenDescriptionValue = "Blood-worm, wound-tool.";

        public const string BMTokenDescriptionName = "$item_greatsword_blackmetal_description";
        public const string BMTokenDescriptionValue = "An undulating blade of cold, dark steel.";

        public const string IronTokenDescriptionName = "$item_greatsword_folcbrand_description";
        public const string IronTokenDescriptionValue = "A keen sword, each strike cuts like a freezing gale.";

        public const string CraftingStationPrefabName = "forge";
        
        public const string TokenLanguage = "English";

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");


        internal static void Init()
        {
            AddRecipe();
            AddItem();

            Language.AddToken(TokenName, TokenValue, TokenLanguage);
            Language.AddToken(TokenDescriptionName, TokenDescriptionValue, TokenLanguage);

            Language.AddToken(IronTokenName, IronTokenValue, TokenLanguage);
            Language.AddToken(IronTokenDescriptionName, IronTokenDescriptionValue, TokenLanguage);

            Language.AddToken(BMTokenName, BMTokenValue, TokenLanguage);
            Language.AddToken(BMTokenDescriptionName, BMTokenDescriptionValue, TokenLanguage);
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
