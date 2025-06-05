using UnityEngine;

namespace HeroArena
{
    [CreateAssetMenu(fileName = "LineratCalculation", menuName = "Scriptable Objects/LineratCalculation")]
    public class LinearCalculation : ScriptableObject, IStatCalculationStrategy
    {
        public int healthPerStrength = 10;
        public int staminaPerConstitution = 5;
        public float dodgePerAgility = 0.1f;

        public float CalculateMaxDodge(HeroPrimaryAtributes atributes)
        {
            return dodgePerAgility * atributes.agility;
        }

        public int CalculateMaxHealth(HeroPrimaryAtributes atributes)
        {
            return healthPerStrength * atributes.strength;
        }

        public int CalculateMaxStamina(HeroPrimaryAtributes atributes)
        {
            return staminaPerConstitution * atributes.constitution;
        }
    }

}
