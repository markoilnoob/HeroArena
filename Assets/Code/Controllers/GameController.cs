using System;
using UnityEngine;

namespace HeroArena.UI
{
    public class GameController : UIController
    {
        public Action<HeroDescription, bool /* IsPlayer */> OnDescriptionReady;

        public override void BindCallbacks()
        {
            ArenaGameManager.Instance.OnHeroCreated -= HeroCreated;
            ArenaGameManager.Instance.OnHeroCreated += HeroCreated;
        }

        private void HeroCreated(Hero hero, bool IsPlayer)
        {
            OnDescriptionReady?.Invoke(hero.GetHeroDescription(), IsPlayer);
        }

        public override void BroadcastInitialValues()
        {
            if (ArenaGameManager.Instance.PlayerHero)
            {
                OnDescriptionReady?.Invoke(ArenaGameManager.Instance.PlayerHero.GetHeroDescription(), true);
            }

            if (ArenaGameManager.Instance.EnemyHero)
            {
                OnDescriptionReady?.Invoke(ArenaGameManager.Instance.EnemyHero.GetHeroDescription(), false);
            }
        }
    }
}
