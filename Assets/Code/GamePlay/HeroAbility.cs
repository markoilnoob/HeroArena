using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    [Serializable]
    public class HeroAbility : MonoBehaviour
    {
        public HeroAbilityDescription abilityDescription { get; private set; }
        private List<AbilityEffect> abilityEffects;
        public int level = 1;
        private Hero hero;
        HeroAbilityContext abilityContext;
        public static Action OnEnemyTurn;

        public void Initialized(HeroAbilityDescription inAbilityDescription, Hero inHero)
        {
            hero = inHero;
            abilityDescription = inAbilityDescription;
            abilityEffects = new List<AbilityEffect>();
            abilityEffects = abilityDescription.abilityEffects;
        }

        public void ActivateAbility()
        {
            // TODO: Single controller for each hero
            if (ArenaGameManager.Instance.PlayerHero == hero)
            {
                if (GameModeManager.Instance.GetTurnState() != TurnState.PlayerTurn) return;
                abilityContext.Source = ArenaGameManager.Instance.PlayerHero;
                abilityContext.Target = ArenaGameManager.Instance.EnemyHero;
                GameModeManager.Instance.SetTurnState(TurnState.EnemyTurn);
            }
            else
            {
                if (GameModeManager.Instance.GetTurnState() != TurnState.EnemyTurn) return;
                abilityContext.Source = ArenaGameManager.Instance.EnemyHero;
                abilityContext.Target = ArenaGameManager.Instance.PlayerHero;
                OnEnemyTurn?.Invoke();
                GameModeManager.Instance.SetTurnState(TurnState.PlayerTurn);
            }

            abilityContext.AbilityLevel = level;
            
            foreach (AbilityEffect effect in abilityEffects)
            {
                effect.Execute(abilityContext);
            }
        }
    }
}
