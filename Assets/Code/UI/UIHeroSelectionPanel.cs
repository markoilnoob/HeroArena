using HeroArena.UI;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HeroArena
{
    public class UIHeroSelectionPanel : MonoBehaviour, IUIElement
    {
        [SerializeField] private HeroSelectionButton BTN_heroSelectionPrefab;
        List<HeroSelectionButton> heroButtons;
        private MainMenuController menuController;

        private void Awake() => heroButtons = new List<HeroSelectionButton>();

        private void Start()
        {
            HeroDescription[] heroDescriptions = Resources.LoadAll<HeroDescription>("HeroDescriptions");
            foreach (var hero in heroDescriptions)
            {
                HeroSelectionButton btn_hero = Instantiate(BTN_heroSelectionPrefab, this.transform);
                btn_hero.Init(hero);

                heroButtons.Add(btn_hero);

                btn_hero.OnSelected -= HightlightHeroSelection;
                btn_hero.OnSelected += HightlightHeroSelection;

                // the next code is made by Chatgpt :(
                // i wasnt capable of thinking of a better solution other than taking the child of the btn prefab
                Image[] btn_hero_imgs = btn_hero.GetComponentsInChildren<Image>();
                foreach (Image img in btn_hero_imgs)
                {
                    if (img.gameObject != btn_hero.gameObject)
                    {
                        img.sprite = hero.heroPortrait;
                        break;
                    }
                }

                btn_hero.SetText(hero.heroName);
            }
        }

        private void HightlightHeroSelection(HeroSelectionButton heroSelection)
        {
            foreach (var herobtn in heroButtons)
            {
                if (herobtn != heroSelection)
                {
                    //unselect
                    herobtn.UnSelectThis();
                }
                else
                {
                    //select
                    herobtn.SelectThis();
                    menuController.SetPlayerTempSelection(herobtn.GetHeroClass());
                }
            }
        }

        public void SetController(UIController uIController)
        {
            menuController = uIController as MainMenuController;

        }
    }
}
