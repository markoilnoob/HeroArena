using UnityEngine;
using UnityEngine.UI;

namespace HeroArena.UI
{
    public class UIContinueHero : MonoBehaviour
    {
        private Image IMG_Hero;
        private Sprite image;
        private HeroDescription HeroDescriptionSO;
        private UIController controller;
        private HeroClass heroClass1;
        

        private void Awake()
        {
            IMG_Hero = GetComponent<Image>();
            image = GetComponent<Sprite>();
        }

        public void SetController(UIController inController)
        {
            controller = inController; 
            MainMenuController mainmenucontroller = controller as MainMenuController; //1° modo per fare il cast
            // MainMenuController mainmenucontroller = (MainMenuController) controller; un altro modo per fare il cast
            mainmenucontroller.OnHeroChanged += SetHeroImage;
        }


        public void SetHeroImage(HeroClass heroClass)
        {
            if (heroClass == HeroClass.NONE)
            {
                IMG_Hero.enabled = false;
                
            }
            else 
            { 
                HeroDescriptionSO = GameState.Instance.GetHeroDescription(heroClass);
                IMG_Hero.enabled = true;
                IMG_Hero.sprite = HeroDescriptionSO.heroPortrait;

            }

        }
    }
}
