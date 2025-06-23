using HeroArena.UI;
using UnityEngine;

namespace HeroArena
{
    public class EndGameHUD : HeroArenaHUD
    {
        private EndGameController endController;
        [SerializeField] private UIButton returnButton;
        [SerializeField] private GameObject canvasGO;

        private void Start()
        {
            UIManager.Instance.FadeIn();

            //gamecontroller -> Init
            sceneController = new EndGameController();
            endController = (EndGameController)sceneController;

            endController.OnReturnToMainMenu -= OnReturnToMainMenu;
            endController.OnReturnToMainMenu += OnReturnToMainMenu;
            //button -> Init
            returnButton.SetController(endController);
            //endController.BroadcastInitialValues();
        }

        private void OnReturnToMainMenu()
        {
            Debug.Log("Returning to main menu");
            GameManager.Instance.LoadScene("SCN_MainMenu");
            GameManager.Instance.UnloadScene("SCN_EndGame");
        }
    }
}
