using UnityEngine;

namespace HeroArena
{
    public class ArenaGameManager : MonoBehaviour
    {
        public static ArenaGameManager Instance { get; private set; }

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

        private void Start()
        {
            GameManager.Instance.UnloadScene("SCN_MainMenu");
            UIManager.Instance.OnFadeInComplete -= StartGame;
            UIManager.Instance.OnFadeInComplete += StartGame;
            UIManager.Instance.FadeIn();
        }

        private void StartGame()
        {
            Debug.Log("Game Started");
        }
    }
}
