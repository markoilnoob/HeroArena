using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    public class BarbarianAbilitiesFactory : HeroAbilitiesFactory
    {
        protected override List<HeroAbilityDescription> FetchHeroAbilities()
        {
            return HeroArenaAssetLoader.FetchHeroAbilities(HeroClass.BARBARIAN);
        }
    }
}
