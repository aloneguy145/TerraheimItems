using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class SpearBlackmetal
{
	public static CustomItem customItem;

	public static CustomRecipe customRecipe;

	public const string TokenLanguage = "English";

	private static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

	internal static void Init()
	{
		AddRecipe();
		AddItem();
	}

	private static void AddRecipe()
	{
		Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
		recipe.m_item = AssetHelper.SpearBlackmetalPrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["SpearBlackmetal"]);
		customRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["SpearBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipe);
		}
	}

	private static void AddItem()
	{
		customItem = new CustomItem(AssetHelper.SpearBlackmetalPrefab, fixReference: true);
		UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["SpearBlackmetal"]);
		if ((bool)balance["SpearBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItem);
		}
	}
}
