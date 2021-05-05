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
            Utility.AssetHelper.Init();
            Weapons.Greatswords.Init();
            Weapons.AxeForstasca.Init();
            Weapons.AtgeirSilver.Init();
            Weapons.KnifeIron.Init();
            Weapons.ParryingDagger.Init();
            Weapons.BowBlackmetal.Init();
            Weapons.PickaxeBlackmetal.Init();
            Weapons.SpearBlackmetal.Init();
            Weapons.Battleaxes.Init();
            Weapons.FlametalWeapons.Init();

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
