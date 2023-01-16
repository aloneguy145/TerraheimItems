using HarmonyLib;

namespace TerraheimItems.Patches;

[HarmonyPatch]
internal class ProjectileSpawnOnHitPatch
{
	public static int stackHolder = -1;

	[HarmonyPrefix]
	[HarmonyPatch(typeof(Projectile), "SpawnOnHit")]
	private static void ProjectileSetupPatch(ref ItemDrop.ItemData ___m_spawnItem)
	{
		if (___m_spawnItem != null && ___m_spawnItem.m_stack > 1)
		{
			stackHolder = ___m_spawnItem.m_stack;
			___m_spawnItem.m_stack = 1;
		}
		else
		{
			stackHolder = -1;
		}
	}

	[HarmonyPostfix]
	[HarmonyPatch(typeof(Projectile), "SpawnOnHit")]
	private static void ProjectileSetupPostfix(ref ItemDrop.ItemData ___m_spawnItem)
	{
		if (___m_spawnItem != null && stackHolder > -1)
		{
			___m_spawnItem.m_stack = stackHolder;
		}
	}
}
