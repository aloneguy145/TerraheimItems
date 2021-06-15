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
    class AttackDrawUpdatePatch
    {

        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        [HarmonyPostfix]
        [HarmonyPatch(typeof(VisEquipment), "UpdateEquipmentVisuals")]
        static void UpdateEquipmentVisualsPatch(VisEquipment __instance)
        {
            //Log.LogMessage(__instance.m_leftItem + " " + __instance.m_leftItemInstance.name);
            //Log.LogMessage(__instance.m_rightItem + " " + __instance.m_rightItemInstance.name);
            var attach = __instance.m_leftItemInstance;
            if (attach != null && __instance.m_leftItem == "BowFireTH" && __instance.m_isPlayer)
            {
                if (Player.m_localPlayer != null && Player.m_localPlayer.GetAttackDrawPercentage() > 0f)
                {
                    foreach (Transform child in attach.transform)
                    {
                        if (child.name == "FullModel" && child.gameObject.GetComponent<MeshRenderer>().enabled)
                        {
                            child.gameObject.GetComponent<MeshRenderer>().enabled = false;
                            //Log.LogInfo($"Setting {child.name} to inactive");
                        }
                        else if (child.name == "HiddenModel")
                        {
                            if (child.gameObject.GetComponent<MeshRenderer>().enabled == false)
                                child.gameObject.GetComponent<MeshRenderer>().enabled = true;
                            child.gameObject.GetComponent<Renderer>().material.color = new UnityEngine.Color(1.0f, 1.0f, 1.0f, Mathf.Clamp(1.0f- Player.m_localPlayer.GetAttackDrawPercentage(), 0.05f, 1.0f));
                            //Log.LogInfo($"{child.name} transparency is {child.gameObject.GetComponent<Renderer>().material.color.a}");
                        }
                        else if (child.name == "effects" && child.gameObject.activeSelf)
                        {
                            //Log.LogInfo($"Setting {child.name} to inactive");
                            child.gameObject.SetActive(false);
                        }
                        else if (child.name == "effectsCharging" && !child.gameObject.activeSelf)
                        {
                            //Log.LogInfo($"Setting {child.name} to active");
                            child.gameObject.SetActive(true);
                        }
                    }
                }
                else if (Player.m_localPlayer != null && attach.transform.Find("FullModel").gameObject.GetComponent<MeshRenderer>().enabled == false)
                {
                    attach.transform.Find("FullModel").gameObject.GetComponent<MeshRenderer>().enabled = true;
                    attach.transform.Find("effects").gameObject.SetActive(true);
                    attach.transform.Find("effectsCharging").gameObject.SetActive(false);
                    attach.transform.Find("HiddenModel").gameObject.GetComponent<MeshRenderer>().enabled = false;
                    attach.transform.Find("HiddenModel").gameObject.GetComponent<Renderer>().material.color = new UnityEngine.Color(1.0f, 1.0f, 1.0f);
                }
            }
        }
    }
}
