using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.StatusEffects;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class FlametalWeapons
{
	public static CustomItem maceItem;

	public static CustomRecipe maceRecipe;

	public static CustomItem gsItem;

	public static CustomRecipe gsRecipe;

	public static CustomItem atgeirItem;

	public static CustomRecipe atgeirRecipe;

	public static CustomItem bowItem;

	public static CustomRecipe bowRecipe;

	public static CustomItem gaxeItem;

	public static CustomRecipe gaxeRecipe;

	public static CustomItem sledgeItem;

	public static CustomRecipe sledgeRecipe;

	public static CustomItem axeItem;

	public static CustomRecipe axeRecipe;

	public static CustomItem knifeItem;

	public static CustomRecipe knifeRecipe;

	public static CustomItem spearItem;

	public static CustomRecipe spearRecipe;

	public static CustomItem taxeItem;

	public static CustomRecipe taxeRecipe;

	public static CustomItem arrowItem;

	public static CustomRecipe arrowRecipe;

	public static CustomItem swordItem;

	public static CustomRecipe swordRecipe;

	public static CustomItem shieldItem;

	public static CustomRecipe shieldRecipe;

	public static CustomItem gshieldItem;

	public static CustomRecipe gshieldRecipe;

	private static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

	internal static void Init()
	{
		AddRecipe();
		AddItem();
	}

	private static void AddRecipe()
	{
		Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe2 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe3 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe4 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe5 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe6 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe7 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe8 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe9 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe10 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe11 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe12 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe13 = ScriptableObject.CreateInstance<Recipe>();
		Recipe recipe14 = ScriptableObject.CreateInstance<Recipe>();
		recipe.m_item = AssetHelper.MaceFirePrefab.GetComponent<ItemDrop>();
		recipe2.m_item = AssetHelper.GreatswordFirePrefab.GetComponent<ItemDrop>();
		recipe3.m_item = AssetHelper.AtgeirFirePrefab.GetComponent<ItemDrop>();
		recipe4.m_item = AssetHelper.BowFirePrefab.GetComponent<ItemDrop>();
		recipe5.m_item = AssetHelper.BattleaxeFirePrefab.GetComponent<ItemDrop>();
		recipe6.m_item = AssetHelper.SledgeFirePrefab.GetComponent<ItemDrop>();
		recipe7.m_item = AssetHelper.AxeFirePrefab.GetComponent<ItemDrop>();
		recipe8.m_item = AssetHelper.KnifeFirePrefab.GetComponent<ItemDrop>();
		recipe9.m_item = AssetHelper.SpearFirePrefab.GetComponent<ItemDrop>();
		recipe10.m_item = AssetHelper.ThrowingAxeFirePrefab.GetComponent<ItemDrop>();
		recipe11.m_item = AssetHelper.ArrowGreatFirePrefab.GetComponent<ItemDrop>();
		recipe12.m_item = AssetHelper.SwordFirePrefab.GetComponent<ItemDrop>();
		recipe13.m_item = AssetHelper.ShieldFirePrefab.GetComponent<ItemDrop>();
		recipe14.m_item = AssetHelper.ShieldFireTowerPrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["MaceFire"]);
		UtilityFunctions.GetRecipe(ref recipe2, balance["GreatswordFire"]);
		UtilityFunctions.GetRecipe(ref recipe4, balance["AtgeirFire"]);
		UtilityFunctions.GetRecipe(ref recipe3, balance["BowFire"]);
		UtilityFunctions.GetRecipe(ref recipe5, balance["BattleaxeFire"]);
		UtilityFunctions.GetRecipe(ref recipe6, balance["SledgeFire"]);
		UtilityFunctions.GetRecipe(ref recipe7, balance["AxeFire"]);
		UtilityFunctions.GetRecipe(ref recipe8, balance["KnifeFire"]);
		UtilityFunctions.GetRecipe(ref recipe9, balance["SpearFire"]);
		UtilityFunctions.GetRecipe(ref recipe10, balance["ThrowingAxeFire"]);
		UtilityFunctions.GetRecipe(ref recipe11, balance["ArrowGreatFire"]);
		UtilityFunctions.GetRecipe(ref recipe12, balance["SwordFire"]);
		UtilityFunctions.GetRecipe(ref recipe13, balance["ShieldFire"]);
		UtilityFunctions.GetRecipe(ref recipe14, balance["ShieldFireTower"]);
		maceRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		gsRecipe = new CustomRecipe(recipe2, fixReference: true, fixRequirementReferences: true);
		atgeirRecipe = new CustomRecipe(recipe3, fixReference: true, fixRequirementReferences: true);
		bowRecipe = new CustomRecipe(recipe4, fixReference: true, fixRequirementReferences: true);
		gaxeRecipe = new CustomRecipe(recipe5, fixReference: true, fixRequirementReferences: true);
		sledgeRecipe = new CustomRecipe(recipe6, fixReference: true, fixRequirementReferences: true);
		axeRecipe = new CustomRecipe(recipe7, fixReference: true, fixRequirementReferences: true);
		knifeRecipe = new CustomRecipe(recipe8, fixReference: true, fixRequirementReferences: true);
		spearRecipe = new CustomRecipe(recipe9, fixReference: true, fixRequirementReferences: true);
		taxeRecipe = new CustomRecipe(recipe10, fixReference: true, fixRequirementReferences: true);
		arrowRecipe = new CustomRecipe(recipe11, fixReference: true, fixRequirementReferences: true);
		swordRecipe = new CustomRecipe(recipe12, fixReference: true, fixRequirementReferences: true);
		shieldRecipe = new CustomRecipe(recipe13, fixReference: true, fixRequirementReferences: true);
		gshieldRecipe = new CustomRecipe(recipe14, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["MaceFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(maceRecipe);
		}
		if ((bool)balance["GreatswordFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(gsRecipe);
		}
		if ((bool)balance["AtgeirFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(atgeirRecipe);
		}
		if ((bool)balance["BowFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(bowRecipe);
		}
		if ((bool)balance["BattleaxeFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(gaxeRecipe);
		}
		if ((bool)balance["SledgeFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(sledgeRecipe);
		}
		if ((bool)balance["AxeFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(axeRecipe);
		}
		if ((bool)balance["KnifeFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(knifeRecipe);
		}
		if ((bool)balance["SpearFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(spearRecipe);
		}
		if ((bool)balance["ThrowingAxeFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(taxeRecipe);
		}
		if ((bool)balance["ArrowGreatFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(arrowRecipe);
		}
		if ((bool)balance["SwordFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(swordRecipe);
		}
		if ((bool)balance["ShieldFire"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(shieldRecipe);
		}
		if ((bool)balance["ShieldFireTower"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(gshieldRecipe);
		}
	}

	private static void AddItem()
	{
		maceItem = new CustomItem(AssetHelper.MaceFirePrefab, fixReference: true);
		gsItem = new CustomItem(AssetHelper.GreatswordFirePrefab, fixReference: true);
		atgeirItem = new CustomItem(AssetHelper.AtgeirFirePrefab, fixReference: true);
		bowItem = new CustomItem(AssetHelper.BowFirePrefab, fixReference: true);
		gaxeItem = new CustomItem(AssetHelper.BattleaxeFirePrefab, fixReference: true);
		sledgeItem = new CustomItem(AssetHelper.SledgeFirePrefab, fixReference: true);
		axeItem = new CustomItem(AssetHelper.AxeFirePrefab, fixReference: true);
		knifeItem = new CustomItem(AssetHelper.KnifeFirePrefab, fixReference: true);
		spearItem = new CustomItem(AssetHelper.SpearFirePrefab, fixReference: true);
		taxeItem = new CustomItem(AssetHelper.ThrowingAxeFirePrefab, fixReference: true);
		arrowItem = new CustomItem(AssetHelper.ArrowGreatFirePrefab, fixReference: true);
		swordItem = new CustomItem(AssetHelper.SwordFirePrefab, fixReference: true);
		shieldItem = new CustomItem(AssetHelper.ShieldFirePrefab, fixReference: true);
		gshieldItem = new CustomItem(AssetHelper.ShieldFireTowerPrefab, fixReference: true);
		UtilityFunctions.ModifyWeaponDamage(ref maceItem, balance["MaceFire"], "<i>Mace</i>\n", string.Format("\n\nFoes struck by its secondary attack are Pinned for <color=cyan>{0}</color> seconds. Pinned enemies are vulnerable to all damage types and have reduced movement speed.", (float)balance["MaceFire"]!["effectVal"]));
		UtilityFunctions.ModifyWeaponDamage(ref gsItem, balance["GreatswordFire"], "<i>Greatsword</i>\n", string.Format("\n\nIts secondary attack flings an explosive wave of fire across the battlefield, dealing <color=cyan>{0}</color> fire damage.", (float)balance["GreatswordFire"]!["effectVal"]));
		UtilityFunctions.ModifyWeaponDamage(ref atgeirItem, balance["AtgeirFire"], "<i>Atgeir</i>\n", string.Format("\n\nFoes struck by its secondary attack will suffer damage equal to <color=cyan>{0}%</color> of their Current HP after 1.3 seconds.", (float)balance["AtgeirFire"]!["effectVal"] * 100f));
		UtilityFunctions.ModifyWeaponDamage(ref bowItem, balance["BowFire"], "<i>Bow</i>\n", "\n\nArrows fired by Gwynttorrwr explode on impact. While drawing the bow, your movement speed is greatly reduced.");
		UtilityFunctions.ModifyWeaponDamage(ref gaxeItem, balance["BattleaxeFire"], "<i>Battleaxe</i>\n", string.Format("\n\nIts secondary fires a short range burst of fireballs. Each fireball deals <color=cyan>{0}</color> fire damage.", (float)balance["BattleaxeFire"]!["effectVal"]));
		UtilityFunctions.ModifyWeaponDamage(ref sledgeItem, balance["SledgeFire"], "<i>Sledgehammer</i>\n", "\n\nThe force at which the hammer is flung into the earth leaves a firey puddle for 5 seconds after a slam.");
		UtilityFunctions.ModifyWeaponDamage(ref axeItem, balance["AxeFire"], "<i>Axe</i>\n", string.Format("\n\nKilling a foe imbues their corpse with volatile energy, causing them to explode soon after death. The explosion deals damage equal to <color=cyan>{0}%</color> of the foes max hp. These explosions can chain.", (float)balance["AxeFire"]!["effectVal"] * 100f));
		axeItem.ItemDrop.m_itemData.m_shared.m_attackStatusEffect = ScriptableObject.CreateInstance<SE_ChainExplosionListener>();
		UtilityFunctions.ModifyWeaponDamage(ref knifeItem, balance["KnifeFire"], "<i>Knife</i>\n", string.Format("\n\nStriking a foe with your secondary attack Marks them for 1 hit. Marked enemies suffer <color=cyan>{0}%</color> more damage.", (float)balance["KnifeFire"]!["effectVal"] * 100f));
		UtilityFunctions.ModifyWeaponDamage(ref spearItem, balance["SpearFire"], "<i>Spear</i>\n", "\n\nHurling Rhongomiant across the battlefield will cause you to teleport to whatever location the spear landed.");
		UtilityFunctions.ModifyWeaponDamage(ref taxeItem, balance["ThrowingAxeFire"], "<i>Throwing Axe</i>\n", "\n\nTyrfing hurls spectral versions of itself, depleting durability, not ammo.");
		UtilityFunctions.ModifyWeaponDamage(ref swordItem, balance["SwordFire"], "<i>Sword</i>\n", string.Format("\n\nThe secondary attack emits a deadly beam of fire that deals <color=cyan>{0}</color> damage on impact.", (float)balance["SwordFire"]!["effectVal"]));
		UtilityFunctions.ModifyWeaponDamage(ref arrowItem, balance["ArrowGreatFire"]);
		shieldItem.ItemDrop.m_itemData.m_shared.m_description = "<i>Shield</i>\n" + shieldItem.ItemDrop.m_itemData.m_shared.m_description + string.Format("\n\nParrying a foes attack reduces their damage by <color=cyan>{0}%</color> for {1}s. After this effect wears off, {2}s must pass before it can be reapplied.\nPridwen sings to Arthur's other weapons, boosting their damage.", (float)balance["ShieldFire"]!["effectVal"] * 100f, (float)balance["ShieldFire"]!["effectDur"], (float)balance["ShieldFire"]!["effectCooldown"]);
		gshieldItem.ItemDrop.m_itemData.m_shared.m_description = "<i>Tower Shield</i>\n" + gshieldItem.ItemDrop.m_itemData.m_shared.m_description + string.Format("\n\nKilling enemies with Svalinn equipped stores a portion of their Max HP. Once 4 enemies have been slain, a <color=cyan>healing</color> nova is released, healing you and your allies within 4m the average of the stored HP.\nWhile Svalinn is equipped, damage from projectiles is reduced by <color=cyan>{0}%</color>.", (float)balance["ShieldFireTower"]!["projProtection"] * 100f);
		if ((bool)balance["MaceFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(maceItem);
		}
		if ((bool)balance["GreatswordFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(gsItem);
		}
		if ((bool)balance["AtgeirFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(atgeirItem);
		}
		if ((bool)balance["BowFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(bowItem);
		}
		if ((bool)balance["BattleaxeFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(gaxeItem);
		}
		if ((bool)balance["SledgeFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(sledgeItem);
		}
		if ((bool)balance["AxeFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(axeItem);
		}
		if ((bool)balance["KnifeFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(knifeItem);
		}
		if ((bool)balance["SpearFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(spearItem);
		}
		if ((bool)balance["ThrowingAxeFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(taxeItem);
		}
		if ((bool)balance["ArrowGreatFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(arrowItem);
		}
		if ((bool)balance["SwordFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(swordItem);
		}
		if ((bool)balance["ShieldFire"]!["enabled"])
		{
			ItemManager.Instance.AddItem(shieldItem);
		}
		if ((bool)balance["ShieldFireTower"]!["enabled"])
		{
			ItemManager.Instance.AddItem(gshieldItem);
		}
	}
}
