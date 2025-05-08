using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    public static class HeroArenaAssetLoader
    {
        public static HeroDescription FetchHeroDescription(HeroClass heroClass)
        {
            //find all assets in ./HeroDescriptions (from resources)
            HeroDescription[] heroDescriptions = Resources.LoadAll<HeroDescription>("HeroDescriptions");

            for (int i = 0; i < heroDescriptions.Length; i++)
            {
                if (heroDescriptions[i].heroClass == heroClass)
                {
                    return heroDescriptions[i];
                }
            }
            return null;
        }

        public static List<HeroAbilityDescription> FetchHeroAbilities(HeroClass heroClass)
        {
            HeroAbilityDescription[] heroAbilities = Resources.LoadAll<HeroAbilityDescription>("HeroAbilities");

            List<HeroAbilityDescription> filteredAbilities = null;

            foreach (HeroAbilityDescription ability in heroAbilities)
            {
                if (ability.availableClasses.Contains(heroClass))
                {
                    filteredAbilities.Add(ability);
                }
            }

            return filteredAbilities;
        }
    }
}
