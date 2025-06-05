using System;
using TMPro;
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
    }
}
