using System;
using UnityEngine;
using HeroArena.UI;

namespace HeroArena
{
    public class MainMenuHUD : HeroArenaHUD
    {
        private MainMenuController menuController;
        [SerializeField] private UIContinueHero continueHero;
        [SerializeField] private UIButton continueButton;

        [SerializeField]
        UIPanel mainMenuPanel;
        [SerializeField]
        UIPanel heroSelectionPanel;
        [SerializeField]
        UIPanel heroInfoPanel;


        private void Start()
        {
            UIManager.Instance.FadeIn();
            //AudioManager.Instance.PlayMusic();

            menuController = new MainMenuController();

            menuController.OnHeroChanged -= OnHeroChanged;
            menuController.OnHeroChanged += OnHeroChanged;

            menuController.OnUserNewGameSelected -= OnNewGameSelected;
            menuController.OnUserNewGameSelected += OnNewGameSelected;


            continueHero.SetController(menuController);
            menuController.BroadcastInitialValues();
        }

        private void OnHeroChanged(HeroClass heroClass)
        {
            UpdateContinueButton(heroClass);
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

        private void OnNewGameSelected()
        {
            heroSelectionPanel.gameObject.SetActive(true);
            SetControllers(heroSelectionPanel.gameObject);
        }

    }
}
