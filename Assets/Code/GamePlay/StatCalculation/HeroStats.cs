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

        public void Init(HeroPrimaryAtributes heroPrimaryAtributes)
        {
            primaryAtributes = heroPrimaryAtributes;
        }

        public void SetCalculationStrategy(IStatCalculationStrategy calculationStrategy, bool isPlayer = false)
        {
            strategy = calculationStrategy;
            ReCalculateStats(isPlayer);
        }

        public void ReCalculateStats(bool isPlayer = false)
        {
            float costitution = 1;
            float strength = 1;
            float speed = 1;
            if (isPlayer)
            {
                costitution = ItemManager.Instance.itemCostitution == 0 ? 1 : ItemManager.Instance.itemCostitution;
                strength = ItemManager.Instance.itemStrength == 0 ? 1 : ItemManager.Instance.itemStrength;
                speed = ItemManager.Instance.itemSpeed == 0 ? 1 : ItemManager.Instance.itemSpeed;
            }
           
            CurrentHealth = strategy.CalculateMaxHealth(primaryAtributes) * costitution;
            CurrentStamina = strategy.CalculateMaxStamina(primaryAtributes) * strength;
            CurrentDodge = strategy.CalculateMaxDodge(primaryAtributes) * speed;
        }

        public void ApplyDamage(float damage)
        {
            CurrentHealth -= damage * 5 ;
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
