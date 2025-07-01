using UnityEngine;

namespace HeroArena
{
    public class StaminaEffect : AbilityEffect
    {
        public float magnitude = 8f;

        public override void Execute(HeroAbilityContext context)
        {
            Debug.Log("Launch Ability");
            Debug.Log(context.Source.ToString());

            context.Source.RecoverHeroStamina(magnitude);
        }

        public override void CopyFrom(AbilityEffect other)
        {
            if (other is DamageEffect damageEffect)
            {
                magnitude = damageEffect.magnitude;
            }
        }
    }
}
