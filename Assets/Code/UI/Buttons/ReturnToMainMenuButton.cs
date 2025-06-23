using HeroArena.UI;
using UnityEngine;

namespace HeroArena
{
    [RequireComponent(typeof(UIButton))]
    public class ReturnToMainMenuButton : MonoBehaviour
    {
        UIButton button;

        private void Awake()
        {
            button = GetComponent<UIButton>();
            button.onClick -= MainMenu;
            button.onClick += MainMenu;
        }

        private void MainMenu()
        {
            EndGameController endGameController = (EndGameController)button.controller;
            if (endGameController != null)
            {
                endGameController.ReturnToMainMenu();
            }
        }
    }
}
