using System;
using UnityEngine;

namespace HeroArena.UI
{
    public class EndGameController : UIController
    {
        public Action OnReturnToMainMenu;

        public override void BindCallbacks()
        {
            
        }

        public override void BroadcastInitialValues()
        {
            ReturnToMainMenu();
        }

        public void ReturnToMainMenu()
        {
            OnReturnToMainMenu?.Invoke();
        }
    }
}
