using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class AtgeirSilver
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
		recipe.m_item = AssetHelper.AtgeirSilverPrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["AtgeirSilver"]);
		customRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["AtgeirSilver"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipe);
		}
	}

	private static void AddItem()
	{
		customItem = new CustomItem(AssetHelper.AtgeirSilverPrefab, fixReference: true);
		UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["AtgeirSilver"]);
		if ((bool)balance["AtgeirSilver"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItem);
		}
	}
}
