using System.Collections.Generic;
using Jotunn.Entities;
using Jotunn.Managers;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Weapons;

internal class Bombs
{
	public static CustomItem customItemFire;

	public static CustomRecipe customRecipeFire;

	public static CustomItem customItemFrost;

	public static CustomRecipe customRecipeFrost;

	public static CustomItem customItemLightning;

	public static CustomRecipe customRecipeLightning;

	public const string CraftingStationPrefabName = "piece_workbench";

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
		recipe.m_item = AssetHelper.BombFirePrefab.GetComponent<ItemDrop>();
		recipe2.m_item = AssetHelper.BombFrostPrefab.GetComponent<ItemDrop>();
		recipe3.m_item = AssetHelper.BombLightningPrefab.GetComponent<ItemDrop>();
		List<Piece.Requirement> list = new List<Piece.Requirement>
		{
			MockRequirement.Create("Coal", 10),
			MockRequirement.Create("Ooze", 5),
			MockRequirement.Create("LeatherScraps", 5)
		};
		recipe.m_amount = 5;
		recipe.name = "Recipe_BombFire";
		List<Piece.Requirement> list2 = new List<Piece.Requirement>
		{
			MockRequirement.Create("FreezeGland", 5),
			MockRequirement.Create("Ooze", 5),
			MockRequirement.Create("LeatherScraps", 5)
		};
		recipe2.m_amount = 5;
		recipe2.name = "Recipe_BombFrost";
		List<Piece.Requirement> list3 = new List<Piece.Requirement>
		{
			MockRequirement.Create("HardAntler"),
			MockRequirement.Create("Ooze", 5),
			MockRequirement.Create("LeatherScraps", 5)
		};
		recipe3.m_amount = 5;
		recipe3.name = "Recipe_BombLightning";
		recipe.m_resources = list.ToArray();
		recipe2.m_resources = list2.ToArray();
		recipe3.m_resources = list3.ToArray();
		recipe.m_craftingStation = Mock<CraftingStation>.Create("piece_workbench");
		recipe2.m_craftingStation = Mock<CraftingStation>.Create("piece_workbench");
		recipe3.m_craftingStation = Mock<CraftingStation>.Create("piece_workbench");
		customRecipeFire = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		customRecipeFrost = new CustomRecipe(recipe2, fixReference: true, fixRequirementReferences: true);
		customRecipeLightning = new CustomRecipe(recipe3, fixReference: true, fixRequirementReferences: true);
		ItemManager.Instance.AddRecipe(customRecipeFire);
		ItemManager.Instance.AddRecipe(customRecipeFrost);
		ItemManager.Instance.AddRecipe(customRecipeLightning);
	}

	private static void AddItem()
	{
		customItemFire = new CustomItem(AssetHelper.BombFirePrefab, fixReference: true);
		customItemFrost = new CustomItem(AssetHelper.BombFrostPrefab, fixReference: true);
		customItemLightning = new CustomItem(AssetHelper.BombLightningPrefab, fixReference: true);
		ItemManager.Instance.AddItem(customItemFire);
		ItemManager.Instance.AddItem(customItemFrost);
		ItemManager.Instance.AddItem(customItemLightning);
	}
}
