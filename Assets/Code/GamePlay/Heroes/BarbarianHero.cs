using UnityEngine;

namespace HeroArena
{
    public class BarbarianHero : Hero
    {
        public override void Init()
        {
            Class = HeroClass.BARBARIAN;
            description = HeroArenaAssetLoader.FetchHeroDescription(Class);
        }
    }
}
