using System.Collections.Generic;
using HarmonyLib;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Patches;

[HarmonyPatch]
internal class ApplyDamagePatch
{
	private static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

	private static Dictionary<int, float> explosionList = new Dictionary<int, float>();

	[HarmonyPrefix]
	[HarmonyPatch(typeof(SEMan), "OnDamaged")]
	public static void DamagePrefix(SEMan __instance, HitData hit)
	{
		if (__instance.m_character.IsPlayer() && hit.m_statusEffect == "ChainExplosionListener")
		{
			hit.m_damage.m_damage = 0f;
		}
	}

	[HarmonyPrefix]
	[HarmonyPatch(typeof(Ragdoll), "SaveLootList")]
	public static void SaveLootListPrefix(Ragdoll __instance, CharacterDrop characterDrop)
	{
		if (characterDrop.m_character.GetSEMan().HaveStatusEffect("ChainExplosionListener"))
		{
			explosionList.Add(__instance.GetInstanceID(), characterDrop.m_character.GetMaxHealth() * (float)balance["AxeFire"]!["effectVal"]);
		}
	}

	[HarmonyPostfix]
	[HarmonyPatch(typeof(Ragdoll), "SpawnLoot")]
	public static void SpawnLootPostfix(Ragdoll __instance, Vector3 center)
	{
		if (explosionList.ContainsKey(__instance.GetInstanceID()))
		{
			AssetHelper.AxeFireExplosionPrefab.GetComponent<Aoe>().m_hitFriendly = false;
			AssetHelper.AxeFireExplosionPrefab.GetComponent<Aoe>().m_hitOwner = false;
			AssetHelper.AxeFireExplosionPrefab.GetComponent<Aoe>().m_damage.m_damage = explosionList[__instance.GetInstanceID()];
			Object.Instantiate(AssetHelper.AxeFireExplosionPrefab, center, Quaternion.identity);
			explosionList.Remove(__instance.GetInstanceID());
		}
	}
}
