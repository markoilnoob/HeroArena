using UnityEngine;
using HeroArena.UI;

namespace HeroArena
{
    [RequireComponent(typeof(UIButton))]
    public class NewGameButton : MonoBehaviour
    {
        UIButton button;

        private void Awake()
        {
            button = GetComponent<UIButton>();
            button.onClick -= SelectNewGame;
            button.onClick += SelectNewGame;
        }

        private void SelectNewGame()
        {
            MainMenuController menuController = (MainMenuController)button.controller;
            if (menuController != null)
            {
                menuController.NewGameSelected();
            }
        }
    }
}
