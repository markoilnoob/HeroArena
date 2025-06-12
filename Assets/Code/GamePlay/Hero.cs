using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HeroArena 
{ 
    public class Hero : MonoBehaviour
    {
        public HeroClass Class;
        protected HeroDescription description;
        protected HeroAbilitiesFactory abilitiesFactory;
        protected List<HeroAbility> heroAbilities = new List<HeroAbility>();
        HeroStats heroStats;

        public Action<HeroStats, bool> OnHeroStatsUpdated;
        
        public HeroStats HeroStats
        {
            get
            {
                return heroStats;
            }
            private set
            {
                heroStats = value;
            }
        }

        private IStatCalculationStrategy statCalculationStrategy;

        protected void HeroStatsInit()
        {
            HeroStats = gameObject.AddComponent<HeroStats>();
            HeroPrimaryAtributes temp = GameState.Instance.GetHeroDescription(Class).primaryAtributes;
            HeroStats.Init(temp);
        }

        public void SetStrategy (IStatCalculationStrategy strategy)
        {
            statCalculationStrategy = strategy;
            //TODO ricalcolo delle statistiche
        }

        public HeroDescription GetHeroDescription()
        {
            return description;
        }

        public List<HeroAbility> GetHeroAbilities()
        {
            if (heroAbilities.Count > 0)
                return heroAbilities;
            else
            {
                heroAbilities = abilitiesFactory.CreateAbilities();
                return heroAbilities;
            }
        }

        virtual public void Init()
        {
            //used by the child classes
            //inizialization
        }

        // Utility UI Callbacks
        public void HeroStatsUpdated()
        {
            bool IsPlayer = false;
            
            IsPlayer = ArenaGameManager.Instance.PlayerHero == this;
            
            OnHeroStatsUpdated?.Invoke(HeroStats, IsPlayer);
            if(HeroStats.CurrentHealth < 0)
            {
                GameModeManager.Instance.SetTurnState(TurnState.EndGame);
                return;
            }
            if (IsPlayer)
            {
                
                GameModeManager.Instance.SetTurnState(TurnState.EnemyTurn);
            }
            else
            {
                GameModeManager.Instance.SetTurnState(TurnState.PlayerTurn);
            }
        }

        // Stats methods
        // TODO: Create a string based system?
        public void ApplyHeroDamage(float damage)
        {
            HeroStats.ApplyDamage(damage);
            HeroStatsUpdated();
        }

        public void ApplyHeroHeal(float health)
        {
            HeroStats.ApplyHeal(health);
            HeroStatsUpdated();
        }

        public void UseHeroStamina(float stamina)
        {
            HeroStats.UseStamina(stamina);
            HeroStatsUpdated();
        }

        public void ApplyHeroDodge(float dodge)
        {
            HeroStats.ApplyDodge(dodge);
            HeroStatsUpdated();
        }
    }         
}
