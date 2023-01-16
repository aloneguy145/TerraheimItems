using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Newtonsoft.Json.Linq;
using Terraheim.ArmorEffects;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Patches;

[HarmonyPatch]
internal class AnimationSpeedPatches
{
	public static Dictionary<string, float> baseAnimationSpeeds = new Dictionary<string, float>();

	private static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

	[HarmonyPrefix]
	[HarmonyPatch(typeof(CharacterAnimEvent), "FixedUpdate")]
	private static void CharacterAnimFixedUpdatePrefix(ref Animator ___m_animator, Character ___m_character)
	{
		if (Player.m_localPlayer == null || !___m_character.IsPlayer() || (___m_character.IsPlayer() && (___m_character as Player).GetPlayerID() != Player.m_localPlayer.GetPlayerID()))
		{
			return;
		}
		Animator obj = ___m_animator;
		if ((object)obj == null || obj.GetCurrentAnimatorClipInfo(0)?.Any() != true || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip == null || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Idle") || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Jog") || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Run") || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Walk") || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Standing") || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("jump") || (baseAnimationSpeeds.ContainsKey(___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name) && baseAnimationSpeeds[___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name] != ___m_animator.speed))
		//if ((object)obj == null || obj.GetCurrentAnimatorClipInfo(0)?.Any() != true || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip() == null || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name.Contains("Idle") || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name.Contains("Jog") || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name.Contains("Run") || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name.Contains("Walk") || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name.Contains("Standing") || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name.Contains("jump") || (baseAnimationSpeeds.ContainsKey(___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name) && baseAnimationSpeeds[___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name] != ___m_animator.speed))
		{
			return;
		}
		float num = 0f;
		if (___m_character.GetSEMan().HaveStatusEffect("Two Hand Attack Speed"))
		{
			ItemDrop.ItemData currentWeapon = (___m_character as Humanoid).GetCurrentWeapon();
			if (currentWeapon != null && currentWeapon.m_shared?.m_itemType == ItemDrop.ItemData.ItemType.TwoHandedWeapon)
			{
				num += (___m_character.GetSEMan().GetStatusEffect("Two Hand Attack Speed") as SE_TwoHandAttackSpeed).GetSpeed();
			}
		}
		if (___m_character.GetSEMan().HaveStatusEffect("Adrenaline"))
		{
			num += (___m_character.GetSEMan().GetStatusEffect("Adrenaline") as SE_Adrenaline).GetAttackSpeed();
		}
		float num2 = 0f;
		if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.StartsWith("Bomb"))
		//if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name.StartsWith("Bomb"))
		{
			if (((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("throwingaxe")).Value)
			{
				num2 = (float)balance["ThrowingAxeAnimationSpeedAdjust"];
			}
		}
		else if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.StartsWith("BattleAxe1"))
		//else if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name.StartsWith("BattleAxe1"))
		{
			if (((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("greatsword")).Value)
			{
				num2 = (float)balance["GreatswordStartAnimationSpeedAdjust"];
			}
		}
		else if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.StartsWith("BattleAxe") && ((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("greatsword")).Value)
		//else if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name.StartsWith("BattleAxe") && ((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("greatsword")).Value)
		{
			num2 = (float)balance["GreatswordAnimationSpeedAdjust"];
		}
		if (num2 + num != 0f)
		{
			___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, num2, num);
			Log.LogMessage(
				$"Animation Name {___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name}. Speed {___m_animator.speed}");
			//Log.LogMessage($"Animation Name {___m_animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name}. Speed {___m_animator.speed}");
		}
	}

	public static float ChangeSpeed(Character character, Animator animator, float speed, float speedMod)
	{
		string name = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
		//string name = animator.GetCurrentAnimatorClipInfo(0)[0].get_clip().name;
		if (!baseAnimationSpeeds.ContainsKey(name))
		{
			baseAnimationSpeeds.Add(name, animator.speed);
		}
		if (speedMod < 1f)
		{
			speedMod += 1f;
		}
		if (speed < 1f)
		{
			speed += 1f;
		}
		return baseAnimationSpeeds[name] * speed * speedMod;
	}
}
