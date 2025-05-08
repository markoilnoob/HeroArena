using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    public class PaladinAbilitiesFactory : HeroAbilitiesFactory
    {
        protected override List<HeroAbilityDescription> FetchHeroAbilities()
        {
            return HeroArenaAssetLoader.FetchHeroAbilities(HeroClass.PALADIN);
        }
    }
}
