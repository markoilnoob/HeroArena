using UnityEngine;

namespace HeroArena
{
    [CreateAssetMenu(fileName = "LineratCalculation", menuName = "Scriptable Objects/LineratCalculation")]
    public class LinearCalculation : ScriptableObject, IStatCalculationStrategy
    {
        public int healthPerStrength = 10;
        public int staminaPerConstitution = 5;
        public float dodgePerAgility = 0.1f;
        public float rangePerSpeed = 0.25f;

        public int CalculateMaxHealth(HeroPrimaryAtributes atributes)
        {
            return healthPerStrength * atributes.strength;
        }

        public int CalculateMaxStamina(HeroPrimaryAtributes atributes)
        {
            return staminaPerConstitution * atributes.constitution;
        }

        public float CalculateMaxDodge(HeroPrimaryAtributes atributes)
        {
            return dodgePerAgility * atributes.agility;
        }

        public float CalculateMaxRange(HeroPrimaryAtributes atributes)
        {
            return rangePerSpeed * atributes.speed;
        }
    }
}
