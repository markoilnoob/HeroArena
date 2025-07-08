using UnityEngine;

namespace HeroArena
{
    public class VictoryImageTrigger : MonoBehaviour
    {
        private void OnEnable()
        {
           
            if (VictoryManager.Instance != null)
            {
                VictoryManager.Instance.OnVictoryImageShown();
            }
        }
    }
}