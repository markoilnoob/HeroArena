using System;
using UnityEngine;

namespace HeroArena.UI
{
    public class MainMenuController : UIController
    {
        public Action<HeroClass> OnHeroChanged;

        public override void BindCallbacks()
        {
            GameState.Instance.OnHeroSelected -= HeroChanged;
            GameState.Instance.OnHeroSelected += HeroChanged;
        }

        public override void BroadcastInitialValues()
        {
            OnHeroChanged?.Invoke(GameState.Instance.HeroSelected);
        }

        private void HeroChanged(HeroClass heroClass)
        {
            OnHeroChanged?.Invoke(heroClass);
        }
    }
}
