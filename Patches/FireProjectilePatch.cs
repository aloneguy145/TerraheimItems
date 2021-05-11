using HarmonyLib;
using Terraheim;
using Terraheim.Utility;
using UnityEngine;

namespace TerraheimItems.Patches
{
    [HarmonyPatch]
    class FireProjectilePatch
    {
        [HarmonyPatch(typeof(Attack), "FireProjectileBurst")]
        [HarmonyPrefix]
        public static void FireProjectileBurstPrefix(ref Attack __instance)
        {
            //Log.LogInfo("Items bowshot");
            if (!Terraheim.TerraheimItems.hasTerraheim && __instance.GetWeapon().m_shared.m_name.Contains("bow_fireTH"))
            {
                //Log.LogInfo("Items firebow");
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
