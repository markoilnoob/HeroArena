using UnityEngine;

namespace HeroArena
{
    public class PaladinHero : Hero
    {
        public override void Init()
        {
            Class = HeroClass.PALADIN;
            description = HeroArenaAssetLoader.FetchHeroDescription(Class);
            abilitiesFactory = new PaladinAbilitiesFactory();
        }
    }
}
