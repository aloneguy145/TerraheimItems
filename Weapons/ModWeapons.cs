using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim.Weapons
{
    class ModWeapons
    {

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        internal static void Init()
        {
            ItemManager.OnItemsRegistered += ModItems;
        }

        private static void ModItems()
        {
            var fireSword = PrefabManager.Cache.GetPrefab<ItemDrop>("SwordIronFire");
            AssetHelper.SwordIronFireProjPrefab.GetComponent<Projectile>().m_damage.m_fire = (float)balance["SwordIronFire"]["effectVal"];
            fireSword.m_itemData.m_shared.m_secondaryAttack.m_attackProjectile = AssetHelper.SwordIronFireProjPrefab;
            fireSword.m_itemData.m_shared.m_secondaryAttack.m_projectileAccuracy = 0.1f;
            fireSword.m_itemData.m_shared.m_secondaryAttack.m_projectileVel = 20f;
            fireSword.m_itemData.m_shared.m_secondaryAttack.m_attackOffset = 0.2f;

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.m_item = fireSword;

            UtilityFunctions.GetRecipe(ref recipe, balance["SwordIronFire"]);

            CustomRecipe customRecipe = new CustomRecipe(recipe, true, true);
            ItemManager.Instance.AddRecipe(customRecipe);
        }
    }
}
