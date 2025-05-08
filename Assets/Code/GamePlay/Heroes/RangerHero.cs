using UnityEngine;

namespace HeroArena
{
    public class RangerHero : Hero
    {
        public override void Init()
        {
            Class = HeroClass.RANGER;
            description = HeroArenaAssetLoader.FetchHeroDescription(Class);
            abilitiesFactory = new RangerAbilitiesFactory();
            abilitiesFactory.Init(this);
        }
    }
}
