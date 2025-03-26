using System;
using UnityEngine;
using UnityEngine.UI;

namespace HeroArena
{
    [RequireComponent(typeof(Button))]
    public class UIButton : MonoBehaviour
    {
        Button baseButton;
        Color disabled = Color.blue;

        public Action onClick;

        private void Awake()
        {
            baseButton = GetComponent<Button>();
            baseButton.onClick.AddListener(OnClick);
        }

        private void Start()
        {
            ColorBlock append = baseButton.colors;
            append.disabledColor = disabled;
            baseButton.colors = append;

            //baseButton.interactable = false;
        }

        public void OnClick()
        {
            onClick?.Invoke();
        }
    }
}
