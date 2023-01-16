using HarmonyLib;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Patches;

[HarmonyPatch]
internal class SpawnOnHitPatch
{
	private static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

	[HarmonyPatch(typeof(Projectile), "SpawnOnHit")]
	public static void Postfix(Projectile __instance, GameObject go, Collider collider)
	{
		if (!(bool)balance["FlametalWeaponsSpecialEffectsEnabled"] || __instance.m_spawnItem == null || !__instance.m_spawnItem.m_shared.m_name.Contains("spear_fire"))
		{
			return;
		}
		Vector3 position = __instance.transform.position + __instance.transform.TransformDirection(__instance.m_spawnOffset);
		Quaternion rotation = __instance.transform.rotation;
		if (__instance.m_owner as Player == Player.m_localPlayer)
		{
			GameObject gameObject = Object.Instantiate(AssetHelper.VFXSpearFireTeleportInPrefab, __instance.m_owner.GetCenterPoint(), Quaternion.identity);
			ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>();
			ParticleSystem[] array = componentsInChildren;
			foreach (ParticleSystem particleSystem in array)
			{
				particleSystem.Play();
			}
			Player.m_localPlayer.transform.position = position;
			Player.m_localPlayer.transform.rotation = rotation;
			GameObject gameObject2 = Object.Instantiate(AssetHelper.VFXSpearFireTeleportOutPrefab, position, rotation);
			ParticleSystem[] componentsInChildren2 = gameObject2.GetComponentsInChildren<ParticleSystem>();
			ParticleSystem[] array2 = componentsInChildren2;
			foreach (ParticleSystem particleSystem2 in array2)
			{
				particleSystem2.Play();
			}
		}
	}
}
