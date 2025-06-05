using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    [CreateAssetMenu(fileName = "HeroAbilityDescription", menuName = "Scriptable Objects/HeroAbilityDescription")]
    public class HeroAbilityDescription : ScriptableObject
    {
        public List<HeroClass> availableClasses;
        public string abilityID;
        public string abilityName;
        public string abilityDescription;
        public Sprite sprite;
        [SerializeReference] public List<AbilityEffect> abilityEffects;
    }
}
