using HarmonyLib;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Patches;

[HarmonyPatch]
internal class AttackDrawUpdatePatch
{
	private static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

	[HarmonyPostfix]
	[HarmonyPatch(typeof(VisEquipment), "UpdateEquipmentVisuals")]
	private static void UpdateEquipmentVisualsPatch(VisEquipment __instance)
	{
		GameObject leftItemInstance = __instance.m_leftItemInstance;
		if (!(leftItemInstance != null) || !(__instance.m_leftItem == "BowFireTHnew") || !__instance.m_isPlayer)
		{
			return;
		}
		if (Player.m_localPlayer != null && Player.m_localPlayer.GetAttackDrawPercentage() > 0f)
		{
			foreach (Transform item in leftItemInstance.transform)
			{
				if (item.name == "FullModel" && item.gameObject.GetComponent<MeshRenderer>().enabled)
				{
					item.gameObject.GetComponent<MeshRenderer>().enabled = false;
				}
				else if (item.name == "HiddenModel")
				{
					if (!item.gameObject.GetComponent<MeshRenderer>().enabled)
					{
						item.gameObject.GetComponent<MeshRenderer>().enabled = true;
					}
					item.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, Mathf.Clamp(1f - Player.m_localPlayer.GetAttackDrawPercentage(), 0.05f, 1f));
				}
				else if (item.name == "effects" && item.gameObject.activeSelf)
				{
					item.gameObject.SetActive(value: false);
				}
				else if (item.name == "effectsCharging" && !item.gameObject.activeSelf)
				{
					item.gameObject.SetActive(value: true);
				}
			}
			return;
		}
		if (Player.m_localPlayer != null && !leftItemInstance.transform.Find("FullModel").gameObject.GetComponent<MeshRenderer>().enabled)
		{
			leftItemInstance.transform.Find("FullModel").gameObject.GetComponent<MeshRenderer>().enabled = true;
			leftItemInstance.transform.Find("effects").gameObject.SetActive(value: true);
			leftItemInstance.transform.Find("effectsCharging").gameObject.SetActive(value: false);
			leftItemInstance.transform.Find("HiddenModel").gameObject.GetComponent<MeshRenderer>().enabled = false;
			leftItemInstance.transform.Find("HiddenModel").gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
		}
	}
}
