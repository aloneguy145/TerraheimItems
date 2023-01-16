using Newtonsoft.Json.Linq;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.StatusEffects;

internal class SE_HealthPercentDamage : StatusEffect
{
	private static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

	public bool hasTriggered = false;

	public float TTL
	{
		get
		{
			return m_ttl;
		}
		set
		{
			m_ttl = value;
		}
	}

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
			float num = m_character.GetHealth() * (float)balance["AtgeirFire"]!["effectVal"];
			Log.LogMessage($"Inflicting {num} damage on expiration");
			m_character.SetHealth(m_character.GetHealth() - num);
			HitData hitData = new HitData();
			hitData.m_damage.m_slash = num;
			m_character.Damage(hitData);
			GameObject gameObject = Object.Instantiate(AssetHelper.VFXAtgeirFireHitPrefab, m_character.GetCenterPoint(), Quaternion.identity);
			ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>();
			ParticleSystem[] array = componentsInChildren;
			foreach (ParticleSystem particleSystem in array)
			{
				particleSystem.Play();
			}
			AudioSource audioSource = m_character.GetComponent<AudioSource>();
			if (audioSource == null)
			{
				audioSource = m_character.gameObject.AddComponent<AudioSource>();
				audioSource.playOnAwake = false;
				//audioSource.set_playOnAwake(false);
			}
			audioSource.PlayOneShot(AssetHelper.SFXAtgeirFireHitPrefab);
			hasTriggered = true;
		}
		base.UpdateStatusEffect(dt);
	}

	public override void Setup(Character character)
	{
		TTL = 1.5f;
		Log.LogMessage("Hit " + character.m_name + " w/ atgeir secondary. Effect triggered!");
		base.Setup(character);
	}
}
