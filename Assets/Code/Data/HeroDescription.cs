using UnityEngine;
namespace HeroArena
{
    [CreateAssetMenu(fileName = "HeroDescription", menuName = "Scriptable Objects/HeroDescription")]
    public class HeroDescription : ScriptableObject
    {
        public HeroClass heroClass;
        public string heroName;
        public string heroDescription;
        public Sprite heroPortrait;
        public Sprite heroBigPortrait;

        public HeroPrimaryAtributes primaryAtributes;
    }
}
