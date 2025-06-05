using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    [Serializable]
    public class HeroAbility : MonoBehaviour
    {
        public HeroAbilityDescription abilityDescription;
        private List<AbilityEffect> abilityEffects;
        


        public void Initialized()
        {
            abilityEffects = new List<AbilityEffect>();
            abilityEffects = abilityDescription.abilityEffects;
        }

        public void ActivateAbility()
        {
            foreach (AbilityEffect effect in abilityEffects)
            {
                //effect.Execute(context);
            }
        }

    }
}
