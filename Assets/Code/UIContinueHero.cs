using UnityEngine;
using UnityEngine.UI;

namespace HeroArena.UI
{
    public class UIContinueHero : MonoBehaviour
    {
        private Image IMG_Hero;

        private void Awake()
        {
            IMG_Hero = GetComponent<Image>();
        }

        public void SetHeroImage(HeroClass heroClass)
        {
            switch (heroClass)
            {
                case HeroClass.BARBARIAN:
                    IMG_Hero.color = Color.blue;
                    break;
                case HeroClass.PALADIN:
                    IMG_Hero.color = Color.yellow;
                    break;
                case HeroClass.ROGUE:
                    IMG_Hero.color = Color.gray;
                    break;
                case HeroClass.RANGER:
                    IMG_Hero.color = Color.green;
                    break;
                default:
                    IMG_Hero.color = Color.magenta;
                    break;
            }
        }
    }
}
