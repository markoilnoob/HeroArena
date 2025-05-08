using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    public class RangerAbilitiesFactory : HeroAbilitiesFactory
    {
        protected override List<HeroAbilityDescription> FetchHeroAbilities()
        {
            return HeroArenaAssetLoader.FetchHeroAbilities(HeroClass.RANGER);
        }
    }
}
