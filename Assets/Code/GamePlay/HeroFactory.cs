using System.Collections.Generic;
using UnityEngine;
using System;

namespace HeroArena
{
    public class HeroFactory : MonoBehaviour
    {
        //dictionary <key, value>
        // Mapping from HeroClass to the corresponding Hero-derived type
        private static readonly Dictionary<HeroClass, Type> heroTypeMap = new()
        {
            { HeroClass.BARBARIAN, typeof(BarbarianHero) },
            { HeroClass.PALADIN, typeof(PaladinHero) },
            { HeroClass.ROGUE, typeof(RogueHero) },
            { HeroClass.RANGER, typeof(RangerHero) },
        };

        public Hero CreateHero(HeroClass heroClass, GameObject heroGO)
        {
            /*
            Hero hero; 

            switch (heroClass)
            {
                case HeroClass.BARBARIAN:
                    hero = heroGO.AddComponent<BarbarianHero>();
                    break;

                case HeroClass.PALADIN:
                    hero = heroGO.AddComponent<PaladinHero>();
                    break;

                case HeroClass.RANGER:
                    hero = heroGO.AddComponent<RangerHero>();
                    break;

                case HeroClass.ROGUE:
                    hero = heroGO.AddComponent<RogueHero>();
                    break;

                case HeroClass.NONE:  
                    return null;
                
                default:
                    return null;
            }
            return hero;*/

            // Find the correct Hero type
            if (heroTypeMap.TryGetValue(heroClass, out Type heroType))
            {
                Hero hero = (Hero)gameObject.AddComponent(heroType);

                return hero;
            }
            return null;
        }
    }

}