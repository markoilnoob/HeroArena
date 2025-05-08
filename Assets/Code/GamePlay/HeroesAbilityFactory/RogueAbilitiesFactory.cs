using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    public class RogueAbilitiesFactory : HeroAbilitiesFactory
    {
        protected override List<HeroAbilityDescription> FetchHeroAbilities()
        {
            return HeroArenaAssetLoader.FetchHeroAbilities(HeroClass.ROGUE);
        }
    }
}
