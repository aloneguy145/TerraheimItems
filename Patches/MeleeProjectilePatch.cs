using HarmonyLib;

[HarmonyPatch]
class MeleeProjectilePatch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(Attack), "OnAttackTrigger")]
    static void OnAttackTriggerPatch(Attack __instance)
    {
        if (__instance.GetWeapon().m_shared.m_name.Contains("_greatsword_fire") && __instance.m_attackAnimation == __instance.GetWeapon().m_shared.m_secondaryAttack.m_attackAnimation)
        {
            __instance.ProjectileAttackTriggered();
        }
    }
}