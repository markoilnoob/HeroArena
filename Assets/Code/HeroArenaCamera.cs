using UnityEngine;

namespace HeroArena
{
    public class HeroArenaCamera : MonoBehaviour
    {
        public static HeroArenaCamera Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }


    }
}
