using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class Javelins
{
	public static CustomItem customItemFlint;

	public static CustomRecipe customRecipeFlint;

	public static CustomItem customItemBronze;

	public static CustomRecipe customRecipeBronze;

	public const string TokenNameFlint = "$item_javelin_flint";

	public const string TokenValueFlint = "Flint Javelin";

	public const string TokenDescriptionFlintName = "$item_javelin_flint_description";

	public const string TokenDescriptionFlintValue = "A crude javelin, but it will do in a pinch.";

	public const string CraftingStationPrefabName = "piece_workbench";

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
		Recipe recipe2 = ScriptableObject.CreateInstance<Recipe>();
		recipe.m_item = AssetHelper.JavelinFlintPrefab.GetComponent<ItemDrop>();
		recipe2.m_item = AssetHelper.JavelinBronzePrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["JavelinFlint"]);
		UtilityFunctions.GetRecipe(ref recipe2, balance["JavelinBronze"]);
		customRecipeFlint = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		customRecipeBronze = new CustomRecipe(recipe2, fixReference: true, fixRequirementReferences: true);
		ItemManager.Instance.AddRecipe(customRecipeFlint);
		ItemManager.Instance.AddRecipe(customRecipeBronze);
	}

	private static void AddItem()
	{
		customItemFlint = new CustomItem(AssetHelper.JavelinFlintPrefab, fixReference: true);
		customItemBronze = new CustomItem(AssetHelper.JavelinBronzePrefab, fixReference: true);
		if ((bool)balance["JavelinFlint"]!["modified"])
		{
			UtilityFunctions.ModifyWeaponDamage(ref customItemFlint, balance["JavelinFlint"]);
		}
		if ((bool)balance["JavelinBronze"]!["modified"])
		{
			UtilityFunctions.ModifyWeaponDamage(ref customItemBronze, balance["JavelinBronze"]);
		}
		ItemManager.Instance.AddItem(customItemFlint);
		ItemManager.Instance.AddItem(customItemBronze);
	}
}
