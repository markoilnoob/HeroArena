using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    public class HeroAbilitiesFactory
    {
        protected List<HeroAbility> listOfAbilities = new List<HeroAbility>();
        public List<HeroAbility> CreateAbilities()
        {
            return listOfAbilities;
        }
    }
}
