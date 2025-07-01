using UnityEngine;

namespace HeroArena
{
    public class HeroStats : MonoBehaviour
    {
        private HeroPrimaryAtributes primaryAtributes;
        IStatCalculationStrategy strategy;

        //info
        public float CurrentHealth { get; private set; }
        public float CurrentStamina { get; private set; }
        public float CurrentDodge { get; private set; }
        public float CurrentRange { get; private set; }

        public void Init(HeroPrimaryAtributes heroPrimaryAtributes)
        {
            primaryAtributes = heroPrimaryAtributes;
        }

        public void SetCalculationStrategy(IStatCalculationStrategy calculationStrategy)
        {
            strategy = calculationStrategy;
            ReCalculateStats();
        }

        public void ReCalculateStats()
        {
            CurrentHealth = strategy.CalculateMaxHealth(primaryAtributes);
            CurrentStamina = strategy.CalculateMaxStamina(primaryAtributes);
            CurrentDodge = strategy.CalculateMaxDodge(primaryAtributes);
            CurrentRange = strategy.CalculateMaxRange(primaryAtributes);
        }

        public void ApplyDamage(float damage)
        {
            CurrentHealth -= damage;
            //CurrentHealth -= damage/CurrentDodge; //TODO: improve calculation

            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
                return;
            }
        }

        public void UseStamina(float stamina)
        {
            CurrentStamina -= stamina;
        }

        public void RecoverStamina(float stamina)
        {
            CurrentStamina += stamina;
        }

        public void ApplyDodge(float dodge)
        {
            CurrentDodge += dodge;
        }

        public void ApplyHeal(float heal)
        {
            CurrentHealth += heal;
        }
    }
}
