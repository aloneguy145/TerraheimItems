using HarmonyLib;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using TerraheimItems;
using TerraheimItems.StatusEffects;
using TerraheimItems.Utility;
using UnityEngine;
//using Terraheim.ArmorEffects;

namespace TerraheimItems.Patches
{
    [HarmonyPatch]
    class MeleeProjectilePatch
    {

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Attack), "OnAttackTrigger")]
        static void OnAttackTriggerPatch(Attack __instance)
        {
            if (!(bool)balance["FlametalWeaponsSpecialEffectsEnabled"] || !__instance.m_character.IsPlayer())
                return;
            if (UtilityFunctions.HasProjectileAttack(__instance.GetWeapon().m_shared.m_name) && __instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
            {
                //Log.LogInfo("Melee Projectile");
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
            else if (__instance.GetWeapon().m_shared.m_name.Contains("_mace_fire"))
            {
                if (__instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
                {
                    Terraheim.ArmorEffects.SE_Pinned status = ScriptableObject.CreateInstance<Terraheim.ArmorEffects.SE_Pinned>();
                    status.SetPinTTL((float)balance["MaceFire"]["effectVal"]);
                    status.SetPinCooldownTTL((float)balance["MaceFire"]["cooldownVal"]);
                    __instance.m_weapon.m_shared.m_attackStatusEffect = status;
                    __instance.GetWeapon().m_durability -= (int)balance["FlametalWeaponSpecialDurabilityDrain"];

                }
                else if (__instance.m_weapon.m_shared.m_attackStatusEffect != null)
                    __instance.m_weapon.m_shared.m_attackStatusEffect = null;
            }
            else if (__instance.GetWeapon().m_shared.m_name.Contains("_knife_fire"))
            {
                if (__instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
                {
                    Terraheim.ArmorEffects.SE_MarkedForDeath status = ScriptableObject.CreateInstance<Terraheim.ArmorEffects.SE_MarkedForDeath>();
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
}
