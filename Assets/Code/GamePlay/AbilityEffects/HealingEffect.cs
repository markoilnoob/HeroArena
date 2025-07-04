using System;
using UnityEngine;

namespace HeroArena
{
    [Serializable]
    public class HealingEffect : AbilityEffect
    {
        public float magnitude = 10;

        public override void Execute(HeroAbilityContext context)
        {
            Debug.Log("Launch Ability");
            Debug.Log(context.Source.ToString());

            context.Source.ApplyHeroHeal(magnitude);
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
