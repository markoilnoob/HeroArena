using UnityEngine;

namespace HeroArena.UI
{
    public class HeroArenaHUD : MonoBehaviour
    {
        protected UIController uiController;

        protected void PropagateController(GameObject rootUI)
        {
            IUIElement[] list = rootUI.GetComponentsInChildren<IUIElement>();
            for (int i = 0; i < list.Length; i++)
            {
                list[i].SetController(uiController);
            }
        }
    }
}
