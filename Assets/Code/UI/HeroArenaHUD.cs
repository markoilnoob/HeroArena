using UnityEngine;
using HeroArena.UI;

namespace HeroArena
{
    public class HeroArenaHUD : MonoBehaviour
    {
        protected UIController sceneController;

        protected void SetControllers(GameObject gameObject)
        {
            // Get all child elements implementing the IUIElement interface
            // and assign them the controller

            IUIElement[] uIElements = gameObject.GetComponentsInChildren<IUIElement>();
            foreach (var uIElement in uIElements)
            {
                uIElement.SetController(sceneController);
            }
        }
    }
}
