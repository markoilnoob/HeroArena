using UnityEngine;

namespace HeroArena
{
    [RequireComponent(typeof(UIButton))]
    public class QuitButton : MonoBehaviour
    {
        UIButton button;

        private void Awake()
        {
            button = GetComponent<UIButton>();
            button.onClick -= QuitApplication;
            button.onClick += QuitApplication;
        }

        private void QuitApplication()
        {
            GameManager.Instance.QuitApplication();
        }
    }
}
