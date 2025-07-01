using System;
using HeroArena;
using UnityEngine;

namespace HeroArena
{
    [Serializable]
    public class DamageEffect : AbilityEffect
    {
        public float magnitude = 20;

        public override void Execute(HeroAbilityContext context)
        {
            Debug.Log("Launch Ability");
            Debug.Log(context.Source.ToString());
            
            context.Target.ApplyHeroDamage(magnitude);
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
