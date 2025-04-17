using UnityEngine;

namespace HeroArena 
{ 
    public class Hero : MonoBehaviour
    {
        public HeroClass Class;
        protected HeroDescription description;

        public HeroDescription GetHeroDescription()
        {
            return description;
        }

        virtual public void Init()
        {
            //used by the child classes
            //inizialization
        }
    }         
}
