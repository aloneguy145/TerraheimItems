using System.IO;
using BepInEx;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Managers;
using TerraheimItems.StatusEffects;
using TerraheimItems.Utility;
using TerraheimItems.Weapons;
using UnityEngine;

namespace TerraheimItems;

[BepInPlugin(ModGuid, ModName, ModVer)]
[BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("DasSauerkraut.Terraheim", BepInDependency.DependencyFlags.SoftDependency)]
internal class TerraheimItems : BaseUnityPlugin
{
	public const string ModGuid = "DasSauerkraut.TerraheimItems";

	private const string AuthorName = "DasSauerkraut";

	private const string ModName = "TerraheimItems";

	private const string ModVer = "2.2.3";

	public static readonly string ModPath = Path.GetDirectoryName(typeof(TerraheimItems).Assembly.Location);

	private readonly Harmony harmony = new Harmony(ModGuid);

	internal static TerraheimItems Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
		Log.Init(base.Logger);
		TranslationUtils.LoadTranslations();
		SetupStatusEffects();
		harmony.PatchAll();
		AssetHelper.Init();
		Greatswords.Init();
		Axes.Init();
		AtgeirSilver.Init();
		Knives.Init();
		ParryingDagger.Init();
		BowBlackmetal.Init();
		PickaxeBlackmetal.Init();
		SpearBlackmetal.Init();
		Battleaxes.Init();
		FlametalWeapons.Init();
		TorchOlympia.Init();
		Bombs.Init();
		ThrowingAxes.Init();
		Log.LogInfo("Patching complete");
	}

	public static void SetupStatusEffects()
	{
		ItemManager.Instance.AddStatusEffect(new CustomStatusEffect(ScriptableObject.CreateInstance<SE_HealthPercentDamage>(), fixReference: true));
		ItemManager.Instance.AddStatusEffect(new CustomStatusEffect(ScriptableObject.CreateInstance<SE_ChainExplosionListener>(), fixReference: true));
	}
}
