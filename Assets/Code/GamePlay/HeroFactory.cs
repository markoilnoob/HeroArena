using UnityEngine;

namespace HeroArena
{
    public class HeroFactory : MonoBehaviour
    {

        public Hero CreateHero(HeroClass heroClass, GameObject heroGO)
        {
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
            return hero;









        }
    }

}