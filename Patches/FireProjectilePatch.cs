using HarmonyLib;
using Newtonsoft.Json.Linq;
using Terraheim;
using Terraheim.Utility;
using UnityEngine;

namespace TerraheimItems.Patches
{
    [HarmonyPatch]
    class FireProjectilePatch
    {
        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        [HarmonyPatch(typeof(Attack), "FireProjectileBurst")]
        [HarmonyPrefix]
        public static void FireProjectileBurstPrefix(ref Attack __instance)
        {
            if (!(bool)balance["FlametalWeaponsSpecialEffectsEnabled"])
                return;
            //Log.LogInfo("Items bowshot");
            if (!Terraheim.TerraheimItems.hasTerraheim && __instance.GetWeapon().m_shared.m_name.Contains("bow_fireTH"))
            {
                //Log.LogInfo("Items firebow");
                AssetHelper.BowFireExplosionPrefab.GetComponent<Aoe>().m_damage.m_fire = (float)balance["BowFire"]["effectVal"];
                __instance.m_ammoItem.m_shared.m_attack.m_attackProjectile.GetComponent<Projectile>().m_spawnOnHit = AssetHelper.BowFireExplosionPrefab;
                __instance.m_ammoItem.m_shared.m_attack.m_attackProjectile.GetComponent<Projectile>().m_spawnOnHitChance = 1;
            }
            else if(__instance.GetWeapon().m_shared.m_itemType == ItemDrop.ItemData.ItemType.Bow && __instance.m_ammoItem.m_shared.m_attack.m_attackProjectile.GetComponent<Projectile>().m_spawnOnHit == AssetHelper.BowFireExplosionPrefab)
            {
                __instance.m_ammoItem.m_shared.m_attack.m_attackProjectile.GetComponent<Projectile>().m_spawnOnHit = null;
                __instance.m_ammoItem.m_shared.m_attack.m_attackProjectile.GetComponent<Projectile>().m_spawnOnHitChance = 0;
            }
        }
    }
}
