
using HarmonyLib;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
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

        /*[HarmonyPatch(typeof(CharacterAnimEvent), "Speed")]
        [HarmonyPostfix]
        static void CharacterAnimSpeedPostfix(ref Animator ___m_animator, Character ___m_character)
        {
            if (___m_character.IsPlayer())
            {
                Log.LogMessage($"TerraheimItems | clearing {lastAnimations[(___m_character as Player).GetPlayerID()]}");
                lastAnimations.Remove((___m_character as Player).GetPlayerID());
            }
        }*/

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

            //Log.LogInfo(___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);

            //Check if weapon is a sword
            if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.StartsWith("Attack"))
            {
                if ((bool)((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("greatsword")) || (bool)((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("folcbrand")))
                {
                    ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, (float)balance["GreatswordAnimationSpeedAdjust"]);
                }
            }
            if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.StartsWith("Bomb"))
            {
                //Log.LogWarning("Throwing Bomb");
                if ((bool)((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("throwingaxe")))
                {
                    //Log.LogWarning("Is throwingaxe");
                    ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, (float)balance["ThrowingAxeAnimationSpeedAdjust"]);
                }
            }
            if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.StartsWith("BattleAxe1"))
            {
                if ((bool)((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("greatsword")))
                {
                    //Log.LogWarning("Is throwingaxe");
                    ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, (float)balance["GreatswordStartAnimationSpeedAdjust"]);
                }
            }
            else if (___m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.StartsWith("BattleAxe"))
            {
                if ((bool)((___m_character as Humanoid).GetCurrentWeapon()?.m_shared?.m_name.Contains("greatsword")))
                {
                    //Log.LogWarning("Is throwingaxe");
                    ___m_animator.speed = ChangeSpeed(___m_character, ___m_animator, (float)balance["GreatswordAnimationSpeedAdjust"]);
                }
            }
        }

        public static float ChangeSpeed(Character character, Animator animator, float speed)
        {
            //long id = (character as Player).GetPlayerID();
            string name = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
            //float adjustedSpeed = animator.speed * speed;

            if (!baseAnimationSpeeds.ContainsKey(name))
                baseAnimationSpeeds.Add(name, animator.speed);

            //adjustedSpeed = baseAnimationSpeeds[name] * speed;

            /*if(!lastAnimations.ContainsKey(id) || lastAnimations[id] != name)
            {
                Log.LogMessage($"TerraheimItems | Setting speed for {name} to {adjustedSpeed}");
                lastAnimations[id] = name;
                return adjustedSpeed;
            }*/

            return baseAnimationSpeeds[name] * speed;
        }
    }
}
