
namespace Terraheim.StatusEffects
{
    class SE_ChainExplosionListener : StatusEffect
    {
        public float TTL
        {
            get { return m_ttl; }
            set { m_ttl = value; }
        }

        public void Awake()
        {
            m_name = "ChainExplosionListener";
            base.name = "ChainExplosionListener";
            m_tooltip = "";
            m_icon = null;
        }

        public override void Setup(Character character)
        {
            TTL = 0.25f;
            Log.LogMessage($"Hit {character.m_name} w/ axe fire explosion.");
            base.Setup(character);
        }
    }
}
