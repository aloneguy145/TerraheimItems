using HarmonyLib;
using Newtonsoft.Json.Linq;
using Terraheim.ArmorEffects;
using TerraheimItems.StatusEffects;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Patches;

[HarmonyPatch]
internal class MeleeProjectilePatch
{
	private static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

	[HarmonyPrefix]
	[HarmonyPatch(typeof(Attack), "OnAttackTrigger")]
	private static void OnAttackTriggerPatch(Attack __instance)
	{
		if (!(bool)balance["FlametalWeaponsSpecialEffectsEnabled"] || !__instance.m_character.IsPlayer())
		{
			return;
		}
		if (UtilityFunctions.HasProjectileAttack(__instance.GetWeapon().m_shared.m_name) && __instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
		{
			__instance.ProjectileAttackTriggered();
			__instance.GetWeapon().m_durability -= (int)balance["FlametalWeaponSpecialDurabilityDrain"];
		}
		else if (__instance.GetWeapon().m_shared.m_name.Contains("_atgeir_fire"))
		{
			if (__instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
			{
				__instance.m_weapon.m_shared.m_attackStatusEffect = ScriptableObject.CreateInstance<SE_HealthPercentDamage>();
				__instance.GetWeapon().m_durability -= (int)balance["FlametalWeaponSpecialDurabilityDrain"];
			}
			else if (__instance.m_weapon.m_shared.m_attackStatusEffect != null)
			{
				__instance.m_weapon.m_shared.m_attackStatusEffect = null;
			}
		}
		else if (__instance.GetWeapon().m_shared.m_name.Contains("_mace_fire"))
		{
			if (__instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
			{
				SE_Pinned sE_Pinned = ScriptableObject.CreateInstance<SE_Pinned>();
				sE_Pinned.SetPinTTL((float)balance["MaceFire"]!["effectVal"]);
				sE_Pinned.SetPinCooldownTTL((float)balance["MaceFire"]!["cooldownVal"]);
				__instance.m_weapon.m_shared.m_attackStatusEffect = sE_Pinned;
				__instance.GetWeapon().m_durability -= (int)balance["FlametalWeaponSpecialDurabilityDrain"];
			}
			else if (__instance.m_weapon.m_shared.m_attackStatusEffect != null)
			{
				__instance.m_weapon.m_shared.m_attackStatusEffect = null;
			}
		}
		else if (__instance.GetWeapon().m_shared.m_name.Contains("_knife_fire"))
		{
			if (__instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
			{
				SE_MarkedForDeath sE_MarkedForDeath = ScriptableObject.CreateInstance<SE_MarkedForDeath>();
				sE_MarkedForDeath.SetActivationCount((int)balance["KnifeFire"]!["effectThreshold"]);
				sE_MarkedForDeath.SetHitDuration((int)balance["KnifeFire"]!["effectDur"]);
				sE_MarkedForDeath.SetDamageBonus((float)balance["KnifeFire"]!["effectVal"]);
				__instance.m_weapon.m_shared.m_attackStatusEffect = sE_MarkedForDeath;
				__instance.GetWeapon().m_durability -= (int)balance["FlametalWeaponSpecialDurabilityDrain"];
			}
			else if (__instance.m_weapon.m_shared.m_attackStatusEffect != null)
			{
				__instance.m_weapon.m_shared.m_attackStatusEffect = null;
			}
		}
	}
}
