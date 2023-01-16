using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class Axes
{
	public static CustomItem customItem;

	public static CustomRecipe customRecipe;

	public static CustomItem serpItem;

	public static CustomRecipe serpRecipe;

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
		recipe.m_item = AssetHelper.AxeForstascaPrefab.GetComponent<ItemDrop>();
		recipe2.m_item = AssetHelper.AxeSerpentPrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["AxeForstasca"]);
		UtilityFunctions.GetRecipe(ref recipe2, balance["AxeSerpent"]);
		customRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		serpRecipe = new CustomRecipe(recipe2, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["AxeForstasca"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipe);
		}
		if ((bool)balance["AxeSerpent"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(serpRecipe);
		}
	}

	private static void AddItem()
	{
		customItem = new CustomItem(AssetHelper.AxeForstascaPrefab, fixReference: true);
		serpItem = new CustomItem(AssetHelper.AxeSerpentPrefab, fixReference: true);
		UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["AxeForstasca"]);
		UtilityFunctions.ModifyWeaponDamage(ref serpItem, balance["AxeSerpent"], "<i>Axe</i>\n", string.Format("\n\nThe secondary attack summons a bolt of lightning to the targeted location, dealing <color=cyan>{0}</color> damage.", (float)balance["AxeSerpent"]!["effectVal"]));
		if ((bool)balance["AxeForstasca"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItem);
		}
		if ((bool)balance["AxeSerpent"]!["enabled"])
		{
			ItemManager.Instance.AddItem(serpItem);
		}
	}
}
