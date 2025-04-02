using System;
using UnityEngine;

namespace HeroArena.UI
{
    public class MainMenuHUD : MonoBehaviour
    {
        private MainMenuController menuController;
        [SerializeField] private UIContinueHero continueHero;
        [SerializeField] private UIButton continueButton;

        private void Start()
        {
            UIManager.Instance.FadeIn();
            AudioManager.Instance.PlayMusic();

            menuController = new MainMenuController();
            menuController.OnHeroChanged -= OnHeroChanged;
            menuController.OnHeroChanged += OnHeroChanged;
            menuController.BroadcastInitialValues();
        }

        private void OnHeroChanged(HeroClass heroClass)
        {
            UpdateContinueButton(heroClass);
            UpdateImageHero(heroClass);
        }

        private void UpdateContinueButton(HeroClass heroClass)
        {
            if (heroClass == HeroClass.NONE)
            {
                continueButton.SetButtonActive(false);
            }
            else
            {
                continueButton.SetButtonActive(true);
            }
        }

        private void UpdateImageHero(HeroClass heroClass)
        {
            continueHero.SetHeroImage(heroClass);
        }
    }
}
