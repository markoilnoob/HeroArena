using System;
using UnityEngine;

namespace HeroArena
{
    public class GameState : MonoBehaviour
    {
        public static GameState Instance { get; private set; }

        public Action<HeroClass> OnHeroSelected;

        private HeroClass heroSelected;
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

            HeroSelected = HeroClass.NONE;
        }
    }
}
