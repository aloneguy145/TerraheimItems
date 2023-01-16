using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class Battleaxes
{
	public static CustomItem customItem;

	public static CustomRecipe customRecipe;

	public static CustomItem customItemBronze;

	public static CustomRecipe customRecipeBronze;

	public static CustomItem customItemBM;

	public static CustomRecipe customRecipeBM;

	public static CustomItem customItemSil;

	public static CustomRecipe customRecipeSil;

	public static CustomItem customItemFlint;

	public static CustomRecipe customRecipeFlint;

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
		recipe.m_item = AssetHelper.BattleaxeBlackmetalPrefab.GetComponent<ItemDrop>();
		recipe2.m_item = AssetHelper.BattleaxeBronzePrefab.GetComponent<ItemDrop>();
		recipe3.m_item = AssetHelper.GreateaxeBlackmetalPrefab.GetComponent<ItemDrop>();
		recipe4.m_item = AssetHelper.BattleaxeSilverPrefab.GetComponent<ItemDrop>();
		recipe5.m_item = AssetHelper.BattleaxeFlintPrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["AxehammerBlackmetal"]);
		UtilityFunctions.GetRecipe(ref recipe3, balance["BattleaxeBlackmetal"]);
		UtilityFunctions.GetRecipe(ref recipe2, balance["BattleaxeBronze"]);
		UtilityFunctions.GetRecipe(ref recipe4, balance["BattleaxeSilver"]);
		UtilityFunctions.GetRecipe(ref recipe5, balance["BattleaxeFlint"]);
		customRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		customRecipeBronze = new CustomRecipe(recipe2, fixReference: true, fixRequirementReferences: true);
		customRecipeBM = new CustomRecipe(recipe3, fixReference: true, fixRequirementReferences: true);
		customRecipeSil = new CustomRecipe(recipe4, fixReference: true, fixRequirementReferences: true);
		customRecipeFlint = new CustomRecipe(recipe5, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["AxehammerBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipe);
		}
		if ((bool)balance["BattleaxeBronze"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipeBronze);
		}
		if ((bool)balance["BattleaxeBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipeBM);
		}
		if ((bool)balance["BattleaxeSilver"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipeSil);
		}
		if ((bool)balance["BattleaxeFlint"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipeFlint);
		}
	}

	private static void AddItem()
	{
		customItem = new CustomItem(AssetHelper.BattleaxeBlackmetalPrefab, fixReference: true);
		customItemBronze = new CustomItem(AssetHelper.BattleaxeBronzePrefab, fixReference: true);
		customItemBM = new CustomItem(AssetHelper.GreateaxeBlackmetalPrefab, fixReference: true);
		customItemSil = new CustomItem(AssetHelper.BattleaxeSilverPrefab, fixReference: true);
		customItemFlint = new CustomItem(AssetHelper.BattleaxeFlintPrefab, fixReference: true);
		UtilityFunctions.ModifyWeaponDamage(ref customItemBronze, balance["BattleaxeBronze"]);
		UtilityFunctions.ModifyWeaponDamage(ref customItemBM, balance["BattleaxeBlackmetal"]);
		UtilityFunctions.ModifyWeaponDamage(ref customItemSil, balance["BattleaxeSilver"]);
		UtilityFunctions.ModifyWeaponDamage(ref customItem, balance["AxehammerBlackmetal"]);
		UtilityFunctions.ModifyWeaponDamage(ref customItemFlint, balance["BattleaxeFlint"]);
		if ((bool)balance["AxehammerBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItem);
		}
		if ((bool)balance["BattleaxeBronze"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItemBronze);
		}
		if ((bool)balance["BattleaxeBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItemBM);
		}
		if ((bool)balance["BattleaxeSilver"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItemSil);
		}
		if ((bool)balance["BattleaxeFlint"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItemFlint);
		}
	}
}
