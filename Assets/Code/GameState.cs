using UnityEngine;

namespace HeroArena
{
    public class GameState : MonoBehaviour
    {
        public static GameState Instance { get; private set; }

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

            heroSelected = HeroClass.NONE;
        }


    }
}
