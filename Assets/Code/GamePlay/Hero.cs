using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace HeroArena 
{ 
    public class Hero : MonoBehaviour
    {
        public HeroClass Class;
        protected HeroDescription description;
        protected HeroAbilitiesFactory abilitiesFactory;
        protected List<HeroAbility> heroAbilities = new List<HeroAbility>();

        public HeroDescription GetHeroDescription()
        {
            return description;
        }

        public List<HeroAbility> GetHeroAbilities()
        {
            if (heroAbilities.Count > 0)
                return heroAbilities;
            else
            {
                heroAbilities = abilitiesFactory.CreateAbilities();
                return heroAbilities;
            }
        }

        virtual public void Init()
        {
            //used by the child classes
            //inizialization
        }
    }         
}
