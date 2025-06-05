using System;
using UnityEngine;

namespace HeroArena 
{
    public struct HeroAbilityContext
    {
        public Hero target;
        public Hero source;
        public int level;
    };

    [Serializable]
    public abstract class AbilityEffect : MonoBehaviour
    {
        public abstract void Execute(HeroAbilityContext context);
    }
}
