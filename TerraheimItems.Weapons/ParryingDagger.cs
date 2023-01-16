using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class ParryingDagger
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
		recipe.m_item = AssetHelper.ParryingDaggerPrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["ParryingDagger"]);
		customRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		ItemManager.Instance.AddRecipe(customRecipe);
	}

	private static void AddItem()
	{
		customItem = new CustomItem(AssetHelper.ParryingDaggerPrefab, fixReference: true);
		ItemManager.Instance.AddItem(customItem);
	}
}
