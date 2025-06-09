using System;
using UnityEngine;

namespace HeroArena 
{

    [Serializable]
    public abstract class AbilityEffect
    {
        public abstract void Execute(HeroAbilityContext context);
        public abstract void CopyFrom(AbilityEffect other);
    }
}
