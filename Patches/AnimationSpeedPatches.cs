
using HarmonyLib;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Terraheim.ArmorEffects;
using TerraheimItems;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Patches
{
    [HarmonyPatch]
    class AnimationSpeedPatches
    {
        //public static Dictionary<long, string> lastAnimations = new Dictionary<long, string>();
        public static Dictionary<string, float> baseAnimationSpeeds = new Dictionary<string, float>();
        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        [HarmonyPrefix]
        [HarmonyPatch(typeof(CharacterAnimEvent), "FixedUpdate")]
        static void CharacterAnimFixedUpdatePrefix(ref Animator ___m_animator, Character ___m_character)
        {
            //Make sure this is being applied to the right things
            if (Player.m_localPlayer == null || !___m_character.IsPlayer() || ___m_character.IsPlayer() && (___m_character as Player).GetPlayerID() != Player.m_localPlayer.GetPlayerID())
                return;

            //Make sure there is animation playing
            if (___m_animator?.GetCurrentAnimatorClipInfo(0)?.Any() != true || ___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip == null)
                return;

            float twoHandSpeedBns = 0f;
            if (___m_character.GetSEMan().HaveStatusEffect("Two Hand Attack Speed") && (___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_itemType == ItemDrop.ItemData.ItemType.TwoHandedWeapon)
                twoHandSpeedBns = (___m_character.GetSEMan().GetStatusEffect("Two Hand Attack Speed") as SE_TwoHandAttackSpeed).GetSpeed();

            float attackSpeedBns = 0f;
            if (___m_character.GetSEMan().HaveStatusEffect("Adrenaline"))
                attackSpeedBns = (___m_character.GetSEMan().GetStatusEffect("Adrenaline") as SE_Adrenaline).GetAttackSpeed();
            //Check if weapon is a sword
            if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.StartsWith("Bomb"))
            {
                //Log.LogWarning("Throwing Bomb");
                if ((bool)((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("throwingaxe")))
                {
                    //Log.LogWarning("Is throwingaxe");
                    ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, (float)balance["ThrowingAxeAnimationSpeedAdjust"] + attackSpeedBns);
                }
            }
            else if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.StartsWith("BattleAxe1"))
            {
                if ((bool)((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("greatsword")))
                {
                    //Log.LogWarning("Is throwingaxe");
                    ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, (float)balance["GreatswordStartAnimationSpeedAdjust"] + twoHandSpeedBns + attackSpeedBns);
                }
                else if (___m_character.GetSEMan().HaveStatusEffect("Two Hand Attack Speed"))
                {
                    ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, 1 + twoHandSpeedBns + attackSpeedBns);
                }
            }
            else if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.StartsWith("BattleAxe"))
            {
                if ((bool)((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("greatsword")))
                {
                    //Log.LogWarning("Is throwingaxe");
                    ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, (float)balance["GreatswordAnimationSpeedAdjust"] + twoHandSpeedBns + attackSpeedBns);
                }
                else if (___m_character.GetSEMan().HaveStatusEffect("Two Hand Attack Speed"))
                {
                    ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, 1 + twoHandSpeedBns + attackSpeedBns);
                }
            }
            else if(___m_character.GetSEMan().HaveStatusEffect("Two Hand Attack Speed") && (___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_itemType == ItemDrop.ItemData.ItemType.TwoHandedWeapon)
            {
                ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, 1 + twoHandSpeedBns + attackSpeedBns);
            }
            else if (___m_character.GetSEMan().HaveStatusEffect("Adrenaline"))
                ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, 1 + attackSpeedBns);

        }

        public static float ChangeSpeed(Character character, Animator animator, float speed)
        {
            string name = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
            
            if (!baseAnimationSpeeds.ContainsKey(name))
                baseAnimationSpeeds.Add(name, animator.speed);

            return baseAnimationSpeeds[name] * speed;
        }
    }
}
