using System;
using HeroArena;
using UnityEngine;

namespace HeroArena
{
    [Serializable]
    public class DodgeEffect : AbilityEffect
    {
        public float magnitude = 10;

        public override void Execute(HeroAbilityContext context)
        {
            Debug.Log("Launch Ability");
            Debug.Log(context.Source.ToString());
            
            context.Source.ApplyHeroDodge(magnitude);
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
