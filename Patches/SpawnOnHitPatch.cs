using HarmonyLib;
using Newtonsoft.Json.Linq;
using Terraheim.Utility;
using UnityEngine;

namespace TerraheimItems.Patches
{
    [HarmonyPatch]
    class SpawnOnHitPatch
    {
        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        [HarmonyPatch(typeof(Projectile), "SpawnOnHit")]
        public static void Postfix(Projectile __instance, GameObject go, Collider collider)
        {
            if (!(bool)balance["FlametalWeaponsSpecialEffectsEnabled"])
                return;

            if (__instance.m_spawnItem != null && __instance.m_spawnItem.m_shared.m_name.Contains("spear_fire"))
            {
                Vector3 vector = __instance.transform.position + __instance.transform.TransformDirection(__instance.m_spawnOffset);
                Quaternion rotation = __instance.transform.rotation;
                if ((__instance.m_owner as Player) == Player.m_localPlayer)
                {
                    var inEffect = Object.Instantiate(AssetHelper.VFXSpearFireTeleportInPrefab, __instance.m_owner.GetCenterPoint(), Quaternion.identity);
                    ParticleSystem[] children = inEffect.GetComponentsInChildren<ParticleSystem>();
                    foreach (ParticleSystem particle in children)
                    {
                        particle.Play();
                    }
                    Player.m_localPlayer.transform.position = vector;
                    Player.m_localPlayer.transform.rotation = rotation;

                    var outEffect = Object.Instantiate(AssetHelper.VFXSpearFireTeleportOutPrefab, vector, rotation);
                    ParticleSystem[] children2 = outEffect.GetComponentsInChildren<ParticleSystem>();
                    foreach (ParticleSystem particle in children2)
                    {
                        particle.Play();
                    }
                }
            }
        }

    }
}
