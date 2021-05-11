using HarmonyLib;
using Newtonsoft.Json.Linq;
using Terraheim;
using Terraheim.StatusEffects;
using Terraheim.Utility;
using UnityEngine;
using Terraheim.ArmorEffects;

[HarmonyPatch]
class MeleeProjectilePatch
{
    
    static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");
    
    [HarmonyPrefix]
    [HarmonyPatch(typeof(Attack), "OnAttackTrigger")]
    static void OnAttackTriggerPatch(Attack __instance)
    {
        if (Terraheim.Utility.UtilityFunctions.HasProjectileAttack(__instance.GetWeapon().m_shared.m_name) && __instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
        {
            Log.LogInfo("Melee Projectile");
            __instance.ProjectileAttackTriggered();
            __instance.GetWeapon().m_durability -= (int)balance["FlametalWeaponSpecialDurabilityDrain"];
        }
        else if (__instance.GetWeapon().m_shared.m_name.Contains("_atgeir_fire"))
        {
            if (__instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
            {
                //Log.LogWarning("Atgeir Secondary Triggered!");
                __instance.m_weapon.m_shared.m_attackStatusEffect = ScriptableObject.CreateInstance<SE_HealthPercentDamage>();
                __instance.GetWeapon().m_durability -= (int)balance["FlametalWeaponSpecialDurabilityDrain"];

            }
            else if (__instance.m_weapon.m_shared.m_attackStatusEffect != null)
                __instance.m_weapon.m_shared.m_attackStatusEffect = null;
        }
        else if (Terraheim.TerraheimItems.hasTerraheim && __instance.GetWeapon().m_shared.m_name.Contains("_mace_fire"))
        {
            if (__instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
            {
                SE_Pinned status = ScriptableObject.CreateInstance<SE_Pinned>();
                status.SetPinTTL((float)balance["MaceFire"]["effectVal"]);
                status.SetPinCooldownTTL((float)balance["MaceFire"]["cooldownVal"]);
                __instance.m_weapon.m_shared.m_attackStatusEffect = status;
                __instance.GetWeapon().m_durability -= (int)balance["FlametalWeaponSpecialDurabilityDrain"];

            }
            else if (__instance.m_weapon.m_shared.m_attackStatusEffect != null)
                __instance.m_weapon.m_shared.m_attackStatusEffect = null;
        }
        else if (Terraheim.TerraheimItems.hasTerraheim && __instance.GetWeapon().m_shared.m_name.Contains("_knife_fire"))
        {
            if (__instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
            {
                SE_MarkedForDeath status = ScriptableObject.CreateInstance<SE_MarkedForDeath>();
                status.SetActivationCount((int)balance["KnifeFire"]["effectThreshold"]);
                status.SetHitDuration((int)balance["KnifeFire"]["effectDur"]);
                status.SetDamageBonus((float)balance["KnifeFire"]["effectVal"]);
                __instance.m_weapon.m_shared.m_attackStatusEffect = status;
                __instance.GetWeapon().m_durability -= (int)balance["FlametalWeaponSpecialDurabilityDrain"];

            }
            else if (__instance.m_weapon.m_shared.m_attackStatusEffect != null)
                __instance.m_weapon.m_shared.m_attackStatusEffect = null;
        }
    }
}