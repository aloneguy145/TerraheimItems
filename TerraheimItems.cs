using BepInEx;
using HarmonyLib;
using Newtonsoft.Json.Linq;
using Terraheim.Utility;

namespace Terraheim
{
    [BepInPlugin(ModGuid, ModName, ModVer)]
    [BepInProcess("valheim.exe")]
    [BepInDependency("ValheimModdingTeam.ValheimLib", BepInDependency.DependencyFlags.HardDependency)]
    class TerraheimItems : BaseUnityPlugin
    {

        public const string ModGuid = AuthorName + "." + ModName;
        private const string AuthorName = "DasSauerkraut";
        private const string ModName = "TerraheimItems";
        private const string ModVer = "1.4.0";

        private readonly Harmony harmony = new Harmony(ModGuid);

        internal static TerraheimItems Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            Log.Init(Logger);
            harmony.PatchAll();
            Utility.AssetHelper.Init();
            Weapons.Greatswords.Init();
            Weapons.AxeForstasca.Init();
            Weapons.AtgeirSilver.Init();
            Weapons.KnifeIron.Init();

            Weapons.PickaxeBlackmetal.Init();
            Weapons.SpearBlackmetal.Init();
            Weapons.Battleaxes.Init();

            Weapons.TorchOlympia.Init();

            Weapons.Bombs.Init();
            Weapons.ThrowingAxes.Init();
            Weapons.Javelins.Init();

            Log.LogInfo("Patching complete");
        }

    }
}
