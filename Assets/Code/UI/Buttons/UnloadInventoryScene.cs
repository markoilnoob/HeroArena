using UnityEngine;
using HeroArena.UI;

namespace HeroArena
{
    [RequireComponent(typeof(UIButton))]
    public class UnloadInventoryButton : MonoBehaviour
    {
        UIButton button;

        private void Awake()
        {
            button = GetComponent<UIButton>();
            button.onClick -= CloseInventoryPanel;
            button.onClick += CloseInventoryPanel;
        }

        private void CloseInventoryPanel()
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
