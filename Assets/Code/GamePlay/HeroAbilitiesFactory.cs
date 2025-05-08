using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    public class HeroAbilitiesFactory
    {
        protected List<HeroAbility> listOfAbilities = new List<HeroAbility>();
        protected Hero myHero;

        public void Init(Hero hero)
        {
            myHero = hero;
        }

        public List<HeroAbility> CreateAbilities()
        {
            List<HeroAbilityDescription> abilityDescriptions = FetchHeroAbilities();

            foreach (HeroAbilityDescription description in abilityDescriptions)
            {
                HeroAbility newHeroAbility = myHero.gameObject.AddComponent<HeroAbility>();
                newHeroAbility.abilityDescription = description;
                listOfAbilities.Add(newHeroAbility);
            }

            return listOfAbilities;
        }

        protected virtual List<HeroAbilityDescription> FetchHeroAbilities()
        {
            throw new System.NotImplementedException();
        }
    }
}
