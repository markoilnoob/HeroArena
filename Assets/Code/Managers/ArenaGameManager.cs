using UnityEngine;

namespace HeroArena
{
    public class ArenaGameManager : MonoBehaviour
    {
        [Header("Hero Avatar Options")]
        [SerializeField] private HeroAvatar playerAvatar;
        [SerializeField] private HeroAvatar enemyAvatar;
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
            HeroClass playerHeroClass = GameState.Instance.HeroSelected;
            if (playerHeroClass == HeroClass.NONE)
            {
                playerHeroClass = HeroArenaUtils.GetRandomEnumValue<HeroClass>(1,0);
            }
            playerAvatar.SetAvatar(playerHeroClass);
            
            HeroClass enemyHeroClass = HeroArenaUtils.GetRandomEnumValue<HeroClass>(1, 0);
            enemyAvatar.SetAvatar(enemyHeroClass);

            Debug.Log("Game Started");
        }
    }
}
