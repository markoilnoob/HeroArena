using System;
using UnityEngine;

namespace HeroArena
{
    public class GameState : MonoBehaviour
    {
        public static GameState Instance { get; private set; }

        public Action<HeroClass> OnHeroSelected;
        public HeroDescription[] HeroSO; //riferimento allo scriptable object

        private HeroClass heroSelected = HeroClass.NONE;

        public HeroClass HeroSelected
        {
            get
            {
                return heroSelected;
            }
            private set
            {
                heroSelected = value;
                OnHeroSelected?.Invoke(heroSelected);
            }
        }

        private HeroClass heroTempSelected = HeroClass.NONE;

        public HeroClass HeroTempSelected
        {
            get => heroTempSelected;
            set => heroTempSelected = value;
        }

        //Singleton
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public HeroDescription GetHeroDescription(HeroClass heroClass)
        {
            for (int i = 0; i < HeroSO.Length; i++)
            {
                if (HeroSO[i].heroClass == heroClass)
                {
                    return HeroSO[i];
                }
            }
            return null;
        }

        public void ConfirmHeroSelection()
        {
            HeroSelected = HeroTempSelected;
        }

        public void OnNewGame()
        {
            ConfirmHeroSelection();
        }
    }
}
