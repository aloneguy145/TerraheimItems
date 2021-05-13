using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.StatusEffects
{
    class SE_HealthPercentDamage : StatusEffect
    {
        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");
        public float TTL
        {
            get { return m_ttl; }
            set { m_ttl = value; }
        }

        public bool hasTriggered = false;

        public void Awake()
        {
            m_name = "HealthPercentDamage";
            base.name = "HealthPercentDamage";
            m_tooltip = "";
            m_icon = null;
        }

        public override void UpdateStatusEffect(float dt)
        {
            if (m_time >= TTL - 0.1f && !hasTriggered)
            {
                float damageToInflict = (m_character.GetHealth() * (float)balance["AtgeirFire"]["effectVal"]);
                Log.LogMessage($"Inflicting {damageToInflict} damage on expiration");

                m_character.SetHealth(m_character.GetHealth() - damageToInflict);
                HitData hit = new HitData();
                hit.m_damage.m_slash = damageToInflict;
                m_character.Damage(hit);

                var triggerEffect = Object.Instantiate(AssetHelper.VFXAtgeirFireHitPrefab, m_character.GetCenterPoint(), Quaternion.identity);
                ParticleSystem[] children = triggerEffect.GetComponentsInChildren<ParticleSystem>();
                foreach (ParticleSystem particle in children)
                {
                    particle.Play();
                }

                var audioSource = m_character.GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    audioSource = m_character.gameObject.AddComponent<AudioSource>();
                    audioSource.playOnAwake = false;
                }
                audioSource.PlayOneShot(AssetHelper.SFXAtgeirFireHitPrefab);

                hasTriggered = true;
            }
            base.UpdateStatusEffect(dt);
        }

        public override void Setup(Character character)
        {
            TTL = 1.5f;
            Log.LogMessage($"Hit {character.m_name} w/ atgeir secondary. Effect triggered!");
            base.Setup(character);
        }
    }
}
