using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class PickaxeBlackmetal
{
	public static CustomItem customItem;

	public static CustomRecipe customRecipe;

	public const string CraftingStationPrefabName = "forge";

	private static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

	internal static void Init()
	{
		AddRecipe();
		AddItem();
	}

	private static void AddRecipe()
	{
		Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
		recipe.m_item = AssetHelper.PickaxeBlackmetalPrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["PickaxeBlackmetal"]);
		customRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["PickaxeBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipe);
		}
	}

	private static void AddItem()
	{
		customItem = new CustomItem(AssetHelper.PickaxeBlackmetalPrefab, fixReference: true);
		UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["PickaxeBlackmetal"]);
		if ((bool)balance["PickaxeBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItem);
		}
	}
}
