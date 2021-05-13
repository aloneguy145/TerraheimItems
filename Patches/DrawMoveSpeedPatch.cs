using HarmonyLib;

namespace TerraheimItems.Patches
{
    [HarmonyPatch]
    class DrawMoveSpeedPatch
    {
        public void Awake()
        {
            Log.LogInfo("Draw Move Speed Patching Complete");
        }

        [HarmonyPatch(typeof(Player), "GetJogSpeedFactor")]

        public static void Postfix(Player __instance, ref float __result)
        {
            //Prevent movement while firing the flametal bow
            if (!TerraheimItems.hasTerraheim && __instance.GetCurrentWeapon().m_shared.m_name.Contains("bow_fireTH") && __instance.GetAttackDrawPercentage() > 0f)
            {
                __result *= 0;
            }
            //Log.LogMessage(__instance.GetAttackDrawPercentage());
        }

    }
}
