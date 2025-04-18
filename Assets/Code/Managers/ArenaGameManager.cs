using UnityEngine;

namespace HeroArena
{
    [RequireComponent(typeof(HeroFactory))]
    public class ArenaGameManager : MonoBehaviour
    {
        private HeroFactory heroFactory;
        private Hero PlayerHero;
        private Hero EnemyHero;
        [Header("Hero Avatar Options")]
        [SerializeField] private HeroAvatar playerAvatar;
        [SerializeField] private HeroAvatar enemyAvatar;

        [SerializeField] private GameObject playerGO;
        [SerializeField] private GameObject enemyGO;

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

            heroFactory = GetComponent<HeroFactory>();

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
            
            HeroClass enemyHeroClass = HeroArenaUtils.GetRandomEnumValue<HeroClass>(1, 0);

            Debug.Log("Game Started");

            PlayerHero = heroFactory.CreateHero(playerHeroClass, playerGO);
            EnemyHero = heroFactory.CreateHero(enemyHeroClass, enemyGO);

            playerAvatar.SetAvatar(PlayerHero);
            enemyAvatar.SetAvatar(EnemyHero);
        }
    }
}
