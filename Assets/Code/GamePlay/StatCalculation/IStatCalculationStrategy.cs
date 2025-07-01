using UnityEngine;

namespace HeroArena
{
    public interface IStatCalculationStrategy
    {
        int CalculateMaxHealth(HeroPrimaryAtributes atributes);
        int CalculateMaxStamina(HeroPrimaryAtributes atributes);
        float CalculateMaxDodge(HeroPrimaryAtributes atributes);
        float CalculateMaxRange(HeroPrimaryAtributes atributes);
    }
}
