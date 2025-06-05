using System;
using UnityEngine;

namespace HeroArena
{
    public class GameState : MonoBehaviour
    {
        public static GameState Instance { get; private set; }

        public Action<HeroClass> OnHeroSelected;
        public HeroDescription[] HeroSO; //riferimento allo scriptable object

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
