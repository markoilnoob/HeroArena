using System;
using TMPro;
using UnityEngine;

namespace HeroArena.UI
{
    public class UIHeroName : MonoBehaviour, IUIElement
    {
        [SerializeField] private bool _IsPlayer;
        private TextMeshProUGUI description;

        private void Awake()
        {
            description = GetComponent<TextMeshProUGUI>();
        }

        public void SetController(UIController uiController)
        {
            GameController gameController = uiController as GameController; // = (GameController) uiController
            gameController.OnDescriptionReady -= SetHeroDescription;
            gameController.OnDescriptionReady += SetHeroDescription;
        }

        private void SetHeroDescription(HeroDescription description, bool IsPlayer)
        {
            if (_IsPlayer == IsPlayer)
            {
                this.description.text = description.heroName;
            }
        }
    }
}
