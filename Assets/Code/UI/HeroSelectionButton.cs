using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HeroArena.UI
{
    public class HeroSelectionButton : UIButton
    {
        public Action<HeroSelectionButton> OnSelected;
        private Color UnSelectedColor;
        public Color SelectedColor;
        //private Image img_hero;
        //private TextMeshProUGUI txt_heroName;
        private HeroClass heroClass;

        protected override void Awake()
        {
            base.Awake();
            UnSelectedColor = GetComponent<Image>().color;
        }

        public void Init(HeroDescription heroDescr)
        {
            heroClass = heroDescr.heroClass;
            // TODO: refactoring
        }

        public override void OnClick()
        {
            base.OnClick();
            OnSelected?.Invoke(this);
        }

        public void SelectThis()
        {
            SetImageColor(SelectedColor);
        }

        public void UnSelectThis()
        {
            SetImageColor(UnSelectedColor);
        }

        public HeroClass GetHeroClass()
        {
            return heroClass;
        }
    }
}
