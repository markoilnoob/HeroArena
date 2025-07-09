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
            if (ArenaGameManager.Instance.PlayerHeroes[0] == hero)
            {
                if (GameModeManager.Instance.GetTurnState() != TurnState.PlayerTurn) return;
                abilityContext.Source = ArenaGameManager.Instance.PlayerHeroes[0];
                abilityContext.Target = ArenaGameManager.Instance.EnemyHeroes[0];
                GameModeManager.Instance.SetTurnState(TurnState.EnemyTurn);
            }
            else
            {
                if (GameModeManager.Instance.GetTurnState() != TurnState.EnemyTurn) return;
                abilityContext.Source = ArenaGameManager.Instance.EnemyHeroes[0];
                abilityContext.Target = ArenaGameManager.Instance.PlayerHeroes[0];
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
