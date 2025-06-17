using UnityEngine;

namespace HeroArena.UI
{
    public class UIPanel : MonoBehaviour, IUIElement
    {
        UIController controller;

        public void SetController (UIController uiController)
        {
            controller = uiController;
        }

        protected void OnEnable()
        {
            OnPanelEnabled();
        }

        protected virtual void OnPanelEnabled()
        {
            if (UIManager.Instance)
                UIManager.Instance.PushPanel(this);
        }

        protected void OnDisable()
        {
            OnPanelDisabled();
        }

        protected virtual void OnPanelDisabled()
        {
            UIManager.Instance.RemovePanel(this);
        }


    }

}
