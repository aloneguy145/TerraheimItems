using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;
using Terraheim.StatusEffects;

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
        public static CustomItem sledgeItem;
        public static CustomRecipe sledgeRecipe;
        public static CustomItem axeItem;
        public static CustomRecipe axeRecipe;
        public static CustomItem knifeItem;
        public static CustomRecipe knifeRecipe;
        public static CustomItem spearItem;
        public static CustomRecipe spearRecipe;
        public static CustomItem taxeItem;
        public static CustomRecipe taxeRecipe;
        public static CustomItem arrowItem;
        public static CustomRecipe arrowRecipe;

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
            var recipeSledge = ScriptableObject.CreateInstance<Recipe>();
            var recipeAxe = ScriptableObject.CreateInstance<Recipe>();
            var recipeKnife = ScriptableObject.CreateInstance<Recipe>();
            var recipeSpear = ScriptableObject.CreateInstance<Recipe>();
            var recipeTAxe = ScriptableObject.CreateInstance<Recipe>();
            var recipeArrow = ScriptableObject.CreateInstance<Recipe>();

            recipeMace.m_item = AssetHelper.MaceFirePrefab.GetComponent<ItemDrop>();
            recipeGS.m_item = AssetHelper.GreatswordFirePrefab.GetComponent<ItemDrop>();
            recipeAtgeir.m_item = AssetHelper.AtgeirFirePrefab.GetComponent<ItemDrop>();
            recipeBow.m_item = AssetHelper.BowFirePrefab.GetComponent<ItemDrop>();
            recipeGaxe.m_item = AssetHelper.BattleaxeFirePrefab.GetComponent<ItemDrop>();
            recipeSledge.m_item = AssetHelper.SledgeFirePrefab.GetComponent<ItemDrop>();
            recipeAxe.m_item = AssetHelper.AxeFirePrefab.GetComponent<ItemDrop>();
            recipeKnife.m_item = AssetHelper.KnifeFirePrefab.GetComponent<ItemDrop>();
            recipeSpear.m_item = AssetHelper.SpearFirePrefab.GetComponent<ItemDrop>();
            recipeTAxe.m_item = AssetHelper.ThrowingAxeFirePrefab.GetComponent<ItemDrop>();
            recipeArrow.m_item = AssetHelper.ArrowGreatFirePrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipeMace, balance["MaceFire"]);
            UtilityFunctions.GetRecipe(ref recipeGS, balance["GreatswordFire"]);
            UtilityFunctions.GetRecipe(ref recipeBow, balance["AtgeirFire"]);
            UtilityFunctions.GetRecipe(ref recipeAtgeir, balance["BowFire"]);
            UtilityFunctions.GetRecipe(ref recipeGaxe, balance["BattleaxeFire"]);
            UtilityFunctions.GetRecipe(ref recipeSledge, balance["SledgeFire"]);
            UtilityFunctions.GetRecipe(ref recipeAxe, balance["AxeFire"]);
            UtilityFunctions.GetRecipe(ref recipeKnife, balance["KnifeFire"]);
            UtilityFunctions.GetRecipe(ref recipeSpear, balance["SpearFire"]);
            UtilityFunctions.GetRecipe(ref recipeTAxe, balance["ThrowingAxeFire"]);
            UtilityFunctions.GetRecipe(ref recipeArrow, balance["ArrowGreatFire"]);

            maceRecipe = new CustomRecipe(recipeMace, true, true);
            gsRecipe = new CustomRecipe(recipeGS, true, true);
            atgeirRecipe = new CustomRecipe(recipeAtgeir, true, true);
            bowRecipe = new CustomRecipe(recipeBow, true, true);
            gaxeRecipe = new CustomRecipe(recipeGaxe, true, true);
            sledgeRecipe = new CustomRecipe(recipeSledge, true, true);
            axeRecipe = new CustomRecipe(recipeAxe, true, true);
            knifeRecipe = new CustomRecipe(recipeKnife, true, true);
            spearRecipe = new CustomRecipe(recipeSpear, true, true);
            taxeRecipe = new CustomRecipe(recipeTAxe, true, true);
            arrowRecipe = new CustomRecipe(recipeArrow, true, true);

            ItemManager.Instance.AddRecipe(maceRecipe);
            ItemManager.Instance.AddRecipe(gsRecipe);
            ItemManager.Instance.AddRecipe(atgeirRecipe);
            ItemManager.Instance.AddRecipe(bowRecipe);
            ItemManager.Instance.AddRecipe(gaxeRecipe);
            ItemManager.Instance.AddRecipe(sledgeRecipe);
            ItemManager.Instance.AddRecipe(axeRecipe);
            ItemManager.Instance.AddRecipe(knifeRecipe);
            ItemManager.Instance.AddRecipe(spearRecipe);
            ItemManager.Instance.AddRecipe(taxeRecipe);
            ItemManager.Instance.AddRecipe(arrowRecipe);
        }

        private static void AddItem()
        {
            maceItem = new CustomItem(AssetHelper.MaceFirePrefab, true);
            gsItem = new CustomItem(AssetHelper.GreatswordFirePrefab, true);
            atgeirItem = new CustomItem(AssetHelper.AtgeirFirePrefab, true);
            bowItem = new CustomItem(AssetHelper.BowFirePrefab, true);
            gaxeItem = new CustomItem(AssetHelper.BattleaxeFirePrefab, true);
            sledgeItem = new CustomItem(AssetHelper.SledgeFirePrefab, true);
            axeItem = new CustomItem(AssetHelper.AxeFirePrefab, true);
            knifeItem = new CustomItem(AssetHelper.KnifeFirePrefab, true);
            spearItem = new CustomItem(AssetHelper.SpearFirePrefab, true);
            taxeItem = new CustomItem(AssetHelper.ThrowingAxeFirePrefab, true);
            arrowItem = new CustomItem(AssetHelper.ArrowGreatFirePrefab, true);

            UtilityFunctions.ModifyWeaponDamage(ref maceItem, balance["MaceFire"]);
            UtilityFunctions.ModifyWeaponDamage(ref gsItem, balance["GreatswordFire"]);
            UtilityFunctions.ModifyWeaponDamage(ref atgeirItem, balance["AtgeirFire"]);
            UtilityFunctions.ModifyWeaponDamage(ref bowItem, balance["BowFire"]);
            UtilityFunctions.ModifyWeaponDamage(ref gaxeItem, balance["BattleaxeFire"]);
            UtilityFunctions.ModifyWeaponDamage(ref sledgeItem, balance["SledgeFire"]);
            UtilityFunctions.ModifyWeaponDamage(ref axeItem, balance["AxeFire"]);
            axeItem.ItemDrop.m_itemData.m_shared.m_attackStatusEffect = ScriptableObject.CreateInstance<SE_ChainExplosionListener>();
            UtilityFunctions.ModifyWeaponDamage(ref knifeItem, balance["KnifeFire"]);
            UtilityFunctions.ModifyWeaponDamage(ref spearItem, balance["SpearFire"]);
            UtilityFunctions.ModifyWeaponDamage(ref taxeItem, balance["ThrowingAxeFire"]);
            UtilityFunctions.ModifyWeaponDamage(ref arrowItem, balance["ArrowGreatFire"]);

            if ((bool)balance["MaceFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(maceItem);
            }

            if ((bool)balance["GreatswordFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(gsItem);
            }

            if ((bool)balance["AtgeirFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(atgeirItem);
            }

            if ((bool)balance["BowFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(bowItem);
            }

            if ((bool)balance["BattleaxeFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(gaxeItem);
            }

            if ((bool)balance["SledgeFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(sledgeItem);
            }

            if ((bool)balance["AxeFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(axeItem);
            }

            if ((bool)balance["KnifeFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(knifeItem);
            }

            if ((bool)balance["SpearFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(spearItem);
            }

            if ((bool)balance["ThrowingAxeFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(taxeItem);
            }

            if ((bool)balance["ArrowGreatFire"]["enabled"])
            {
                ItemManager.Instance.AddItem(arrowItem);
            }

            /* maceItem.ItemDrop.m_itemData.m_shared.m_description = $"<i>Mace</i>\n" + maceItem.ItemDrop.m_itemData.m_shared.m_description;
             maceItem.ItemDrop.m_itemData.m_shared.m_description += $"\nFoes struck by its secondary attack are Pinned for seconds. Pinned enemies are vulnerable to all damage types and have reduced movement speed.";

             gsItem.ItemDrop.m_itemData.m_shared.m_description = $"<i>Greatsword</i>\n" + gsItem.ItemDrop.m_itemData.m_shared.m_description;
             gsItem.ItemDrop.m_itemData.m_shared.m_description += $"\nIts secondary attack flings an explosive wave of fire across the battlefield, dealing fire damage.";

             atgeirItem.ItemDrop.m_itemData.m_shared.m_description = $"<i>Atgeir</i>\n" + atgeirItem.ItemDrop.m_itemData.m_shared.m_description;
             atgeirItem.ItemDrop.m_itemData.m_shared.m_description += $"\nFoes struck by its secondary attack will suffer damage equal to <color=cyan>{(float)balance["AtgeirFire"]["effectVal"]*100}%</color> of their Current HP after 1.3 seconds.";

             bowItem.ItemDrop.m_itemData.m_shared.m_description = $"<i>Bow</i>\n" + bowItem.ItemDrop.m_itemData.m_shared.m_description;
             bowItem.ItemDrop.m_itemData.m_shared.m_description += $"\nArrows fired by Gwynttorrwr explode on impact. While drawing the bow, your movement speed is greatly reduced.";

             gaxeItem.ItemDrop.m_itemData.m_shared.m_description = $"<i>Battleaxe</i>\n" + gaxeItem.ItemDrop.m_itemData.m_shared.m_description;
             gaxeItem.ItemDrop.m_itemData.m_shared.m_description += $"\nIts secondary fires a short range burst of fireballs.";

             gaxeItem.ItemDrop.m_itemData.m_shared.m_description = $"<i>Sledgehammer</i>\n" + gaxeItem.ItemDrop.m_itemData.m_shared.m_description;
             gaxeItem.ItemDrop.m_itemData.m_shared.m_description += $"\nThe force at which the hammer is flung into the earth leaves a firey puddle for 5 seconds after a slam.";*/

        }
    }
}
