using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class Knives
{
	public static CustomItem customItem;

	public static CustomRecipe customRecipe;

	public static CustomItem customItemSil;

	public static CustomRecipe customRecipeSil;

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
		recipe.m_item = AssetHelper.KnifeIronPrefab.GetComponent<ItemDrop>();
		recipe2.m_item = AssetHelper.KnifeSilverPrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["KnifeIron"]);
		UtilityFunctions.GetRecipe(ref recipe2, balance["KnifeSilver"]);
		customRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["KnifeIron"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipe);
		}
		customRecipeSil = new CustomRecipe(recipe2, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["KnifeSilver"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipeSil);
		}
	}

	private static void AddItem()
	{
		customItem = new CustomItem(AssetHelper.KnifeIronPrefab, fixReference: true);
		customItemSil = new CustomItem(AssetHelper.KnifeSilverPrefab, fixReference: true);
		UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["KnifeIron"]);
		UtilityFunctions.ModifyWeaponDamage(ref customItemSil, balance["KnifeSilver"]);
		if ((bool)balance["KnifeIron"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItem);
		}
		if ((bool)balance["KnifeSilver"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItemSil);
		}
	}
}
