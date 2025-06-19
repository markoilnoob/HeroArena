using HeroArena.UI;
using UnityEngine;

namespace HeroArena
{
    [RequireComponent(typeof(UIButton))]
    public class ConfirmButton : MonoBehaviour
    {
        UIButton button;

        private void Awake()
        {
            button = GetComponent<UIButton>();
            button.onClick -= ConfirmChoice;
            button.onClick += ConfirmChoice;
        }

        private void ConfirmChoice()
        {
            MainMenuController menuController = button.controller as MainMenuController;
            if (menuController != null)
            {
                menuController.NewGameConfirmed();
            }
        }
    }
}
