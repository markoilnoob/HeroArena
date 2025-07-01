using UnityEngine;

namespace HeroArena
{
    [System.Serializable]
    public class HeroPrimaryAtributes
    {
        public int strength;
        public int agility;
        public int constitution;
        public int speed;
    }

    public class HeroSecondaryAtributes
    {
        public int MaxHealth;
        public int MaxStamina;
        public float MaxDodge;
        public float MaxRange;
    }
}
