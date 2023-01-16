using System.Collections.Generic;
using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class TorchOlympia
{
	public static CustomItem customItem;

	public static CustomRecipe customRecipe;

	public const string CraftingStationPrefabName = "piece_workbench";

	private static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

	internal static void Init()
	{
		AddRecipe();
		AddItem();
	}

	private static void AddRecipe()
	{
		Recipe recipe = ScriptableObject.CreateInstance<Recipe>();
		recipe.m_item = AssetHelper.TorchOlympiaPrefab.GetComponent<ItemDrop>();
		List<Piece.Requirement> list = new List<Piece.Requirement>
		{
			MockRequirement.Create("HelmetYule"),
			MockRequirement.Create("Flametal", 70),
			MockRequirement.Create("YagluthDrop", 100),
			MockRequirement.Create("YmirRemains", 20)
		};
		recipe.name = "Recipe_Secret";
		recipe.m_resources = list.ToArray();
		recipe.m_craftingStation = Mock<CraftingStation>.Create("piece_workbench");
		customRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		if ((bool)balance["TorchOlympia"]!["enabled"])
		{
			ItemManager.Instance.AddRecipe(customRecipe);
		}
	}

	private static void AddItem()
	{
		customItem = new CustomItem(AssetHelper.TorchOlympiaPrefab, fixReference: true);
		if ((bool)balance["TorchOlympia"]!["enabled"])
		{
			ItemManager.Instance.AddItem(customItem);
		}
	}
}
