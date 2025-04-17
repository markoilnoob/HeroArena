using UnityEngine;

namespace HeroArena
{
    public class RogueHero : Hero
    {
        public override void Init()
        {
            Class = HeroClass.ROGUE;
            description = HeroArenaAssetLoader.FetchHeroDescription(Class);
        }
    }
}
