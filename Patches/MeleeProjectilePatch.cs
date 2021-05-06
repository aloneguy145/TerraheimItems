using HarmonyLib;
using Terraheim;
using Terraheim.StatusEffects;
using UnityEngine;

[HarmonyPatch]
class MeleeProjectilePatch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(Attack), "OnAttackTrigger")]
    static void OnAttackTriggerPatch(Attack __instance)
    {
        if (Terraheim.Utility.UtilityFunctions.HasProjectileAttack(__instance.GetWeapon().m_shared.m_name) && __instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
        {
            Log.LogInfo("Melee Projectile");
            __instance.ProjectileAttackTriggered();
        }
        else if (__instance.GetWeapon().m_shared.m_name.Contains("_atgeir_fire"))
        {
            if (__instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
            {
                //Log.LogWarning("Atgeir Secondary Triggered!");
                __instance.m_weapon.m_shared.m_attackStatusEffect = ScriptableObject.CreateInstance<SE_HealthPercentDamage>();
            }
            else if (__instance.m_weapon.m_shared.m_attackStatusEffect != null)
                __instance.m_weapon.m_shared.m_attackStatusEffect = null;
        }
    }
}