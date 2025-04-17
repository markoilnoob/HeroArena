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
    }
}
