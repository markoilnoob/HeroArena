using UnityEngine;

namespace HeroArena
{
    public class VictoryImageTrigger : MonoBehaviour
    {
        private void OnEnable()
        {
            // L'immagine � stata mostrata
            if (VictoryManager.Instance != null)
            {
                VictoryManager.Instance.OnVictoryImageShown();
            }
        }
    }
}