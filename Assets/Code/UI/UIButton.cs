using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using HeroArena.UI;


namespace HeroArena
{
    [RequireComponent(typeof(Button))]
    public class UIButton : MonoBehaviour, IUIElement
    {
        protected Button baseButton;
        Color disabled = Color.blue;

        public Action onClick;

        public UIController controller;

        public void SetController(UIController uiController)
        {
            controller = uiController;
        }

        protected virtual void Awake()
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

        public virtual void OnClick()
        {
            onClick?.Invoke();
        }

        public void SetButtonActive(bool newActive)
        {
            baseButton.interactable = newActive;
        }

        public void SetSprite(Sprite sprite)
        {
            baseButton.image.sprite = sprite;

            baseButton.GetComponent<RectTransform>().sizeDelta = sprite.textureRect.size;
        }

        public void SetText(string text)
        {
            baseButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        public void SetImageColor(Color color)
        {
            Image img = GetComponent<Image>();
            img.color = color;
        }
    }
}
