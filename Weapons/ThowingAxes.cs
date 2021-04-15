using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using ValheimLib;
using ValheimLib.ODB;

namespace Terraheim.Weapons
{
    class ThrowingAxes
    {
        public static CustomItem customItemFlint;
        public static CustomRecipe customRecipeFlint; 
        public static CustomItem customItemBronze;
        public static CustomRecipe customRecipeBronze;

        public const string TokenName = "$item_throwingaxe_flint";
        public const string TokenValue = "Flint Throwing Axe";

        public const string TokenNameBronze = "$item_throwingaxe_bronze";
        public const string TokenValueBronze = "Bronze Throwing Axe";

        public const string TokenDescriptionName = "$item_throwingaxe_flint_description";
        public const string TokenDescriptionValue = "May your aim be true...";

        public const string TokenDescriptionNameBronze = "$item_throwingaxe_bronze_description";
        public const string TokenDescriptionValueBronze = "May your arm be swift...";

        //may your eye be keen...
        //may your axe find its mark...

        public const string CraftingStationPrefabName = "piece_workbench";
        public const string ForgePrefabName = "forge";

        public const string TokenLanguage = "English";

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        internal static void Init()
        {
            AddRecipe();
            AddItem();

            Language.AddToken(TokenName, TokenValue, TokenLanguage);
            Language.AddToken(TokenDescriptionName, TokenDescriptionValue, TokenLanguage);
            Language.AddToken(TokenNameBronze, TokenValueBronze, TokenLanguage);
            Language.AddToken(TokenDescriptionNameBronze, TokenDescriptionValueBronze, TokenLanguage);
        }

        private static void AddRecipe()
        {
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            var recipeBronze = ScriptableObject.CreateInstance<Recipe>();

            recipe.m_item = AssetHelper.ThrowingAxeFlintPrefab.GetComponent<ItemDrop>();
            recipeBronze.m_item = AssetHelper.ThrowingAxeBronzePrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipe, balance["ThrowingAxeFlint"]);
            UtilityFunctions.GetRecipe(ref recipeBronze, balance["ThrowingAxeBronze"]);

            customRecipeFlint = new CustomRecipe(recipe, true, true);
            customRecipeBronze = new CustomRecipe(recipeBronze, true, true);

            ObjectDBHelper.Add(customRecipeFlint);
            ObjectDBHelper.Add(customRecipeBronze);
        }

        private static void AddItem()
        {
            customItemFlint = new CustomItem(AssetHelper.ThrowingAxeFlintPrefab, true);
            customItemBronze = new CustomItem(AssetHelper.ThrowingAxeBronzePrefab, true);

            if ((bool)balance["ThrowingAxeFlint"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemFlint, balance["ThrowingAxeFlint"]);
            }
            if ((bool)balance["ThrowingAxeBronze"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref customItemBronze, balance["ThrowingAxeBronze"]);
            }

            ObjectDBHelper.Add(customItemFlint);
            ObjectDBHelper.Add(customItemBronze);
        }
    }
}
