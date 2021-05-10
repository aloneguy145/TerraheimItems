using BepInEx;
using HarmonyLib;
using Newtonsoft.Json.Linq;
using System.IO;
using Terraheim.StatusEffects;
using Terraheim.Utility;
using UnityEngine;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

namespace Terraheim
{
    [BepInPlugin(ModGuid, ModName, ModVer)]
    [BepInProcess("valheim.exe")]
    [BepInDependency("ValheimModdingTeam.ValheimLib", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("DasSauerkraut.Terraheim", BepInDependency.DependencyFlags.SoftDependency)]
    class TerraheimItems : BaseUnityPlugin
    {

        public const string ModGuid = AuthorName + "." + ModName;
        private const string AuthorName = "DasSauerkraut";
        private const string ModName = "TerraheimItems";
        private const string ModVer = "1.8.0";
        public static readonly string ModPath = Path.GetDirectoryName(typeof(TerraheimItems).Assembly.Location);
        public static bool hasTerraheim = false;

        private readonly Harmony harmony = new Harmony(ModGuid);

        internal static TerraheimItems Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            Log.Init(Logger);
            TranslationUtils.LoadTranslations();
            SetupStatusEffects();
            CheckTerraheim();
            harmony.PatchAll();
            Log.LogInfo(1);
            Utility.AssetHelper.Init();
            Log.LogInfo(2);
            Weapons.Greatswords.Init();
            Log.LogInfo(3);
            Weapons.AxeForstasca.Init();
            Log.LogInfo(4);
            Weapons.AtgeirSilver.Init();
            Log.LogInfo(5);
            Weapons.KnifeIron.Init();
            Log.LogInfo(6);
            Weapons.ParryingDagger.Init();
            Log.LogInfo(7);
            Weapons.BowBlackmetal.Init();
            Log.LogInfo(8);
            Weapons.PickaxeBlackmetal.Init();
            Log.LogInfo(9);
            Weapons.SpearBlackmetal.Init();
            Log.LogInfo(10);
            Weapons.Battleaxes.Init();
            Log.LogInfo(11);
            Weapons.FlametalWeapons.Init();
            Log.LogInfo(12);

            Weapons.TorchOlympia.Init();

            Weapons.Bombs.Init();
            Weapons.ThrowingAxes.Init();
            //Weapons.Javelins.Init();

            Weapons.ModWeapons.Init();

            Log.LogInfo("Patching complete");
        }

        public static void SetupStatusEffects()
        {
            ItemManager.Instance.AddStatusEffect(new CustomStatusEffect(ScriptableObject.CreateInstance<SE_HealthPercentDamage>(), fixReference: true));
            ItemManager.Instance.AddStatusEffect(new CustomStatusEffect(ScriptableObject.CreateInstance<SE_ChainExplosionListener>(), fixReference: true));
        }

        public static void CheckTerraheim()
        {
            if (!File.Exists(ModPath + "/Terraheim.dll"))
            {
                Log.LogMessage("Terraheim not found!");
                return;
            }
            hasTerraheim = true;
            Log.LogInfo("Terraheim Found!");
        }

    }
}
