using NUnit.Framework;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace HeroArena.UI
{
    public class GameController : UIController
    {
        public Action<HeroDescription, bool /* IsPlayer */> OnDescriptionReady;
        public Action<List<HeroAbility>, bool> OnAbilitiesReady;
        public Action<HeroStats, bool> OnHeroStatsCalculated;

        public override void BindCallbacks()
        {
            ArenaGameManager.Instance.OnHeroCreated -= HeroCreated;
            ArenaGameManager.Instance.OnHeroCreated += HeroCreated;
        }

        private void HeroCreated(Hero hero, bool IsPlayer)
        {
            OnDescriptionReady?.Invoke(hero.GetHeroDescription(), IsPlayer);
            OnAbilitiesReady?.Invoke(hero.GetHeroAbilities(), IsPlayer);
            OnHeroStatsCalculated?.Invoke(hero.HeroStats, IsPlayer);
            
            // Bind controller to when hero stats change on our hero
            // TODO: Create a single controller for each hero at runtime
            hero.OnHeroStatsUpdated += OnHeroStatsCalculated;
        }

        public override void BroadcastInitialValues()
        {
            if (ArenaGameManager.Instance.PlayerHero)
            {
                OnDescriptionReady?.Invoke(ArenaGameManager.Instance.PlayerHero.GetHeroDescription(), true);
                OnAbilitiesReady?.Invoke(ArenaGameManager.Instance.PlayerHero.GetHeroAbilities(), true);
                OnHeroStatsCalculated?.Invoke(ArenaGameManager.Instance.PlayerHero.HeroStats, true);
            }

            if (ArenaGameManager.Instance.EnemyHero)
            {
                OnDescriptionReady?.Invoke(ArenaGameManager.Instance.EnemyHero.GetHeroDescription(), false);
                OnAbilitiesReady?.Invoke(ArenaGameManager.Instance.EnemyHero.GetHeroAbilities(), false);
                OnHeroStatsCalculated?.Invoke(ArenaGameManager.Instance.EnemyHero.HeroStats, false);
            }
        }
    }
}
