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
        public static CustomItem sledgeItem;
        public static CustomRecipe sledgeRecipe;

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

            recipeMace.m_item = AssetHelper.MaceFirePrefab.GetComponent<ItemDrop>();
            recipeGS.m_item = AssetHelper.GreatswordFirePrefab.GetComponent<ItemDrop>();
            recipeAtgeir.m_item = AssetHelper.AtgeirFirePrefab.GetComponent<ItemDrop>();
            recipeBow.m_item = AssetHelper.BowFirePrefab.GetComponent<ItemDrop>();
            recipeGaxe.m_item = AssetHelper.BattleaxeFirePrefab.GetComponent<ItemDrop>();
            recipeSledge.m_item = AssetHelper.SledgeFirePrefab.GetComponent<ItemDrop>();

            UtilityFunctions.GetRecipe(ref recipeMace, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeGS, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeBow, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeAtgeir, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeGaxe, balance["AxeForstasca"]);
            UtilityFunctions.GetRecipe(ref recipeSledge, balance["AxeForstasca"]);

            maceRecipe = new CustomRecipe(recipeMace, true, true);
            gsRecipe = new CustomRecipe(recipeGS, true, true);
            atgeirRecipe = new CustomRecipe(recipeAtgeir, true, true);
            bowRecipe = new CustomRecipe(recipeBow, true, true);
            gaxeRecipe = new CustomRecipe(recipeGaxe, true, true);
            sledgeRecipe = new CustomRecipe(recipeSledge, true, true);

            ItemManager.Instance.AddRecipe(maceRecipe);
            ItemManager.Instance.AddRecipe(gsRecipe);
            ItemManager.Instance.AddRecipe(atgeirRecipe);
            ItemManager.Instance.AddRecipe(bowRecipe);
            ItemManager.Instance.AddRecipe(gaxeRecipe);
            ItemManager.Instance.AddRecipe(sledgeRecipe);
        }

        private static void AddItem()
        {
            maceItem = new CustomItem(AssetHelper.MaceFirePrefab, true);
            gsItem = new CustomItem(AssetHelper.GreatswordFirePrefab, true);
            atgeirItem = new CustomItem(AssetHelper.AtgeirFirePrefab, true);
            bowItem = new CustomItem(AssetHelper.BowFirePrefab, true);
            gaxeItem = new CustomItem(AssetHelper.BattleaxeFirePrefab, true);
            sledgeItem = new CustomItem(AssetHelper.SledgeFirePrefab, true);

            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref maceItem, balance["AxeForstasca"]);
            }

            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref gsItem, balance["AxeForstasca"]);
            }

            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref atgeirItem, balance["AxeForstasca"]);
            }

            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref bowItem, balance["AxeForstasca"]);
            }

            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref gaxeItem, balance["AxeForstasca"]);
            }

            if ((bool)balance["AxeForstasca"]["modified"])
            {
                UtilityFunctions.ModifyWeaponDamage(ref sledgeItem, balance["AxeForstasca"]);
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

            ItemManager.Instance.AddItem(maceItem);
            ItemManager.Instance.AddItem(gsItem);
            ItemManager.Instance.AddItem(atgeirItem);
            ItemManager.Instance.AddItem(bowItem);
            ItemManager.Instance.AddItem(gaxeItem);
            ItemManager.Instance.AddItem(sledgeItem);
        }
    }
}
