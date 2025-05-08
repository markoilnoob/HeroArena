using UnityEngine;

namespace HeroArena.UI
{
    public class GameHUD : HeroArenaHUD
    {
        [SerializeField] private GameObject canvas;

        private void Start()
        {
            //created controller
            uiController = new GameController();
            uiController.BindCallbacks();
            PropagateController(canvas);
            uiController.BroadcastInitialValues();
        }
    }
}
