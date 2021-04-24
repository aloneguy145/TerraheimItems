using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Terraheim.Utility
{
    class AssetHelper
    {
        public const string AssetBundleName = "bundle_terraheim";
        public static AssetBundle TerraheimAssetBundle;

        public static GameObject FolcbrandPrefab;
        public static GameObject GreatswordIronPrefab;
        public static GameObject GreatswordBlackmetalPrefab;

        public static GameObject AtgeirSilverPrefab;
        public static GameObject AxeForstascaPrefab;

        public static GameObject KnifeIronPrefab;

        public static GameObject PickaxeBlackmetalPrefab;
        public static GameObject SpearBlackmetalPrefab;

        public static GameObject BattleaxeBronzePrefab;
        public static GameObject BattleaxeBlackmetalPrefab;
        public static GameObject BattleaxeSilverPrefab;
        public static GameObject GreateaxeBlackmetalPrefab;

        public static GameObject MaceFirePrefab;
        public static GameObject GreatswordFirePrefab;

        public static GameObject TorchOlympiaPrefab;

        public static GameObject BombFirePrefab;
        public static GameObject BombFrostPrefab;
        public static GameObject BombLightningPrefab;

        public static GameObject ThrowingAxeFlintPrefab;
        public static GameObject ThrowingAxeBronzePrefab;
        public static GameObject ThrowingAxeIronPrefab;
        public static GameObject ThrowingAxeSilverPrefab;
        public static GameObject ThrowingAxeBlackmetalPrefab;

        public static GameObject JavelinFlintPrefab;
        public static GameObject JavelinBronzePrefab;


        public static void Init()
        {
            TerraheimAssetBundle = GetAssetBundleFromResources(AssetBundleName);

            FolcbrandPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/folcbrand/SwordFolcbrand.prefab");
            GreatswordIronPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/greatswordiron/GreatswordIron.prefab");
            GreatswordBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/greatswordblackmetal/GreatswordBlackmetal.prefab");

            AtgeirSilverPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/kresja/AtgeirSilver.prefab");
            AxeForstascaPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/forstasca/AxeForstasca.prefab");
            
            BattleaxeBronzePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/BattleaxeBronze/BattleaxeBronzeTerraheim.prefab");
            KnifeIronPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ironKnife/KnifeIron.prefab");

            PickaxeBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/blackironPickaxe/PickaxeBlackmetal.prefab");
            SpearBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/blackmetalspear/SpearBlackmetal.prefab");
            BattleaxeBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/blackmetalAxehammer/BattleaxeBlackmetal.prefab");
            BattleaxeSilverPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/BattleaxeSilver/BattleaxeSilver.prefab");
            GreateaxeBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/BattleaxeBlackmetal/GreataxeBlackmetal.prefab");

            MaceFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/mace/MaceFire.prefab");
            GreatswordFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/greatsword/GreatswordFire.prefab");

            TorchOlympiaPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/Olympia/TorchOlympia.prefab");

            BombFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/firebomb/BombFire.prefab");
            BombFrostPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/frostbomb/BombFrost.prefab");
            BombLightningPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/lightningbomb/BombLightning.prefab");

            ThrowingAxeFlintPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ThrowingAxes/Flint/ThrowingAxeFlint.prefab");
            ThrowingAxeBronzePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ThrowingAxes/Bronze/ThrowingAxeBronze.prefab");
            ThrowingAxeIronPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ThrowingAxes/Iron/ThrowingAxeIron.prefab");
            ThrowingAxeSilverPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ThrowingAxes/Silver/ThrowingAxeSilver.prefab");
            ThrowingAxeBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ThrowingAxes/Blackmetal/ThrowingAxeBlackmetal.prefab");

            JavelinFlintPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/Javelins/Flint/JavelinFlint.prefab");
            JavelinBronzePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/Javelins/Bronze/JavelinBronze.prefab");
        }

        public static AssetBundle GetAssetBundleFromResources(string filename)
        {
            var execAssembly = Assembly.GetExecutingAssembly();
            var resourceName = execAssembly.GetManifestResourceNames().Single(str => str.EndsWith(filename));

            using (var stream = execAssembly.GetManifestResourceStream(resourceName))
            {
                return AssetBundle.LoadFromStream(stream);
            }
        }
    }
}
