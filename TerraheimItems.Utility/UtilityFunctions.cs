using System.Collections.Generic;
using System.IO;
using Jotunn.Entities;
using Newtonsoft.Json.Linq;
using Terraheim.Utility;

namespace TerraheimItems.Utility;

internal class UtilityFunctions
{
	public static JObject GetJsonFromFile(string filename)
	{
		string path = Path.Combine(TerraheimItems.ModPath, filename);
		string json = File.ReadAllText(path);
		return JObject.Parse(json);
	}

	public static void ModifyWeaponDamage(ref CustomItem item, JToken damages, string type = "", string description = "")
	{
		foreach (JToken item2 in (IEnumerable<JToken>)(damages["damages"]!))
		{
			switch ((string?)item2["type"])
			{
			case "blunt":
				item.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)item2["value"];
				break;
			case "slash":
				item.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)item2["value"];
				break;
			case "pierce":
				item.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)item2["value"];
				break;
			case "chop":
				item.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)item2["value"];
				break;
			case "pickaxe":
				item.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)item2["value"];
				break;
			case "fire":
				item.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)item2["value"];
				break;
			case "frost":
				item.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)item2["value"];
				break;
			case "lightning":
				item.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)item2["value"];
				break;
			case "poison":
				item.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)item2["value"];
				break;
			case "spirit":
				item.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)item2["value"];
				break;
			default:
				Log.LogWarning("Terraheim: Warning damage type not found! " + (string?)item2["type"]);
				break;
			}
		}
		if (type != "")
		{
			item.ItemDrop.m_itemData.m_shared.m_description = type + item.ItemDrop.m_itemData.m_shared.m_description;
		}
		if (description != "")
		{
			item.ItemDrop.m_itemData.m_shared.m_description += description;
		}
	}

	public static void GetRecipe(ref Recipe recipe, JToken json, bool useName = true)
	{
		List<Piece.Requirement> list = new List<Piece.Requirement>();
		int num = 0;
		foreach (JToken item2 in (IEnumerable<JToken>)(json["recipe"]!))
		{
			if ((string?)item2["item"] == "SalamanderFur")
			{
				Piece.Requirement item = new Piece.Requirement
				{
					m_resItem = SharedResources.SalamanderItem.ItemDrop,
					m_amount = (int)item2["amount"]
				};
				list.Add(item);
			}
			else
			{
				list.Add(MockRequirement.Create((string?)item2["item"], (int)item2["amount"]));
				list[num].m_amountPerLevel = (int)item2["perLevel"];
			}
			num++;
		}
		if (useName)
		{
			recipe.name = "Recipe_" + json.Path;
		}
		recipe.m_resources = list.ToArray();
		recipe.m_craftingStation = Mock<CraftingStation>.Create((string?)json["station"]);
		recipe.m_amount = (int)json["amountCrafted"];
	}

	public static bool HasProjectileAttack(string name)
	{
		if (name.Contains("_greatsword_fire"))
		{
			return true;
		}
		if (name.Contains("_battleaxe_fire"))
		{
			return true;
		}
		if (name.Contains("_sword_fire"))
		{
			return true;
		}
		if (name.Contains("_sledge_fire"))
		{
			return true;
		}
		if (name.Contains("_axe_serpent"))
		{
			return true;
		}
		return false;
	}
}
