using System;
using UnityEngine;

namespace HeroArena.UI
{
    public class MainMenuController : UIController
    {
        public Action<HeroClass> OnHeroChanged;
        public Action OnUserNewGameSelected;
        public Action OnNewGameConfirmed;
        public Action OnHeroInfoRequested;

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

        public void NewGameSelected()
        {
            OnUserNewGameSelected?.Invoke();
        }

        public void SetPlayerTempSelection(HeroClass heroClass)
        {
            GameState.Instance.HeroTempSelected = heroClass;
            Debug.Log($"Setting temp selection {heroClass}");
        }
    }
}
