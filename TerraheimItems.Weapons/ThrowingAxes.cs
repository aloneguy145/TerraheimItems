using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class ThrowingAxes
{
	public static CustomItem customItemFlint;

	public static CustomRecipe customRecipeFlint;

	public static CustomItem customItemBronze;

	public static CustomRecipe customRecipeBronze;

	public static CustomItem customItemIron;

	public static CustomRecipe customRecipeIron;

	public static CustomItem customItemSilver;

	public static CustomRecipe customRecipeSilver;

	public static CustomItem customItemBlackmetal;

	public static CustomRecipe customRecipeBlackmetal;

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
		recipe.m_item = AssetHelper.ThrowingAxeFlintPrefab.GetComponent<ItemDrop>();
		recipe2.m_item = AssetHelper.ThrowingAxeBronzePrefab.GetComponent<ItemDrop>();
		recipe3.m_item = AssetHelper.ThrowingAxeIronPrefab.GetComponent<ItemDrop>();
		recipe4.m_item = AssetHelper.ThrowingAxeSilverPrefab.GetComponent<ItemDrop>();
		recipe5.m_item = AssetHelper.ThrowingAxeBlackmetalPrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["ThrowingAxeFlint"]);
		UtilityFunctions.GetRecipe(ref recipe2, balance["ThrowingAxeBronze"]);
		UtilityFunctions.GetRecipe(ref recipe3, balance["ThrowingAxeIron"]);
		UtilityFunctions.GetRecipe(ref recipe4, balance["ThrowingAxeSilver"]);
		UtilityFunctions.GetRecipe(ref recipe5, balance["ThrowingAxeBlackmetal"]);
		customRecipeFlint = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		customRecipeBronze = new CustomRecipe(recipe2, fixReference: true, fixRequirementReferences: true);
		customRecipeIron = new CustomRecipe(recipe3, fixReference: true, fixRequirementReferences: true);
		customRecipeSilver = new CustomRecipe(recipe4, fixReference: true, fixRequirementReferences: true);
		customRecipeBlackmetal = new CustomRecipe(recipe5, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["ThrowingAxeFlint"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipeFlint);
		}
		if ((bool)balance["ThrowingAxeBronze"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipeBronze);
		}
		if ((bool)balance["ThrowingAxeIron"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipeIron);
		}
		if ((bool)balance["ThrowingAxeSilver"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipeSilver);
		}
		if ((bool)balance["ThrowingAxeBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipeBlackmetal);
		}
	}

	private static void AddItem()
	{
		customItemFlint = new CustomItem(AssetHelper.ThrowingAxeFlintPrefab, fixReference: true);
		customItemBronze = new CustomItem(AssetHelper.ThrowingAxeBronzePrefab, fixReference: true);
		customItemIron = new CustomItem(AssetHelper.ThrowingAxeIronPrefab, fixReference: true);
		customItemSilver = new CustomItem(AssetHelper.ThrowingAxeSilverPrefab, fixReference: true);
		customItemBlackmetal = new CustomItem(AssetHelper.ThrowingAxeBlackmetalPrefab, fixReference: true);
		UtilityFunctions.ModifyWeaponDamage(ref customItemFlint, balance["ThrowingAxeFlint"]);
		UtilityFunctions.ModifyWeaponDamage(ref customItemBronze, balance["ThrowingAxeBronze"]);
		UtilityFunctions.ModifyWeaponDamage(ref customItemIron, balance["ThrowingAxeIron"]);
		UtilityFunctions.ModifyWeaponDamage(ref customItemSilver, balance["ThrowingAxeSilver"]);
		UtilityFunctions.ModifyWeaponDamage(ref customItemBlackmetal, balance["ThrowingAxeBlackmetal"]);
		if ((bool)balance["ThrowingAxeFlint"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItemFlint);
		}
		if ((bool)balance["ThrowingAxeBronze"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItemBronze);
		}
		if ((bool)balance["ThrowingAxeIron"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItemIron);
		}
		if ((bool)balance["ThrowingAxeSilver"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItemSilver);
		}
		if ((bool)balance["ThrowingAxeBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItemBlackmetal);
		}
	}
}
