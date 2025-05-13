using UnityEngine;

namespace HeroArena
{
    [CreateAssetMenu(fileName = "LineratCalculation", menuName = "Scriptable Objects/LineratCalculation")]
    public class LinearCalculation : ScriptableObject, IStatCalculationStrategy
    {
        public int healthPerStrength = 10;
        public int staminaPerAgility = 5;
        public float dodgePerAgility = 0.1f;

        public float CalculateMaxDodge(HeroPrimaryAtributes atributes)
        {
            
        }

        public int CalculateMaxHealth(HeroPrimaryAtributes atributes)
        {
            throw new System.NotImplementedException();
        }

        public int CalculateMaxStamina(HeroPrimaryAtributes atributes)
        {
            throw new System.NotImplementedException();
        }
    }

}