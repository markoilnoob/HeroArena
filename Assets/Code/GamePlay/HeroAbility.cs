using UnityEngine;

namespace HeroArena
{
    public class HeroAbility : MonoBehaviour
    {
        public HeroAbilityDescription abilityDescription;

        public void ActivateAbility()
        {
            Debug.Log($"{abilityDescription} :D");
        }
    }
}
