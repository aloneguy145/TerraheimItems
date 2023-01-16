using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class Greatswords
{
	public static CustomItem folcbrandItem;

	public static CustomRecipe folcbrandRecipe;

	public static CustomItem ironItem;

	public static CustomRecipe ironRecipe;

	public static CustomItem blackmetalItem;

	public static CustomRecipe blackmetalRecipe;

	public static CustomItem chitinItem;

	public static CustomRecipe chitinRecipe;

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
		recipe.m_item = AssetHelper.FolcbrandPrefab.GetComponent<ItemDrop>();
		recipe2.m_item = AssetHelper.GreatswordIronPrefab.GetComponent<ItemDrop>();
		recipe3.m_item = AssetHelper.GreatswordBlackmetalPrefab.GetComponent<ItemDrop>();
		recipe4.m_item = AssetHelper.GreatswordChitinPrefab.GetComponent<ItemDrop>();
		UtilityFunctions.GetRecipe(ref recipe, balance["GreatswordFolcbrand"]);
		UtilityFunctions.GetRecipe(ref recipe2, balance["GreatswordIron"]);
		UtilityFunctions.GetRecipe(ref recipe3, balance["GreatswordBlackmetal"]);
		UtilityFunctions.GetRecipe(ref recipe4, balance["GreatswordChitin"]);
		folcbrandRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		ironRecipe = new CustomRecipe(recipe2, fixReference: true, fixRequirementReferences: true);
		blackmetalRecipe = new CustomRecipe(recipe3, fixReference: true, fixRequirementReferences: true);
		chitinRecipe = new CustomRecipe(recipe4, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["GreatswordFolcbrand"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(folcbrandRecipe);
		}
		if ((bool)balance["GreatswordIron"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(ironRecipe);
		}
		if ((bool)balance["GreatswordBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(blackmetalRecipe);
		}
		if ((bool)balance["GreatswordChitin"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(chitinRecipe);
		}
	}

	private static void AddItem()
	{
		folcbrandItem = new CustomItem(AssetHelper.FolcbrandPrefab, fixReference: true);
		ironItem = new CustomItem(AssetHelper.GreatswordIronPrefab, fixReference: true);
		blackmetalItem = new CustomItem(AssetHelper.GreatswordBlackmetalPrefab, fixReference: true);
		chitinItem = new CustomItem(AssetHelper.GreatswordChitinPrefab, fixReference: true);
		UtilityFunctions.ModifyWeaponDamage(ref folcbrandItem, balance["GreatswordFolcbrand"]);
		UtilityFunctions.ModifyWeaponDamage(ref ironItem, balance["GreatswordIron"]);
		UtilityFunctions.ModifyWeaponDamage(ref blackmetalItem, balance["GreatswordBlackmetal"]);
		UtilityFunctions.ModifyWeaponDamage(ref chitinItem, balance["GreatswordChitin"]);
		if ((bool)balance["GreatswordFolcbrand"]!["enabled"])
		{
			ItemManager.Instance.AddItem(folcbrandItem);
		}
		if ((bool)balance["GreatswordIron"]!["enabled"])
		{
			ItemManager.Instance.AddItem(ironItem);
		}
		if ((bool)balance["GreatswordBlackmetal"]!["enabled"])
		{
			ItemManager.Instance.AddItem(blackmetalItem);
		}
		if ((bool)balance["GreatswordChitin"]!["enabled"])
		{
			ItemManager.Instance.AddItem(chitinItem);
		}
	}
}
