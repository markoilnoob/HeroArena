using System;
using UnityEngine;

namespace HeroArena
{
    [RequireComponent(typeof(HeroFactory))]
    public class ArenaGameManager : MonoBehaviour
    {
        private HeroFactory heroFactory;
        public Hero PlayerHero { get; private set; }
        public Hero EnemyHero { get; private set; }
        [Header("Hero Avatar Options")]
        [SerializeField] private HeroAvatar playerAvatar;
        [SerializeField] private HeroAvatar enemyAvatar;

        [SerializeField] private GameObject playerGO;
        [SerializeField] private GameObject enemyGO;

        public Action<Hero, bool /* IsPlayer */> OnHeroCreated;

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
            GameModeManager.Instance.SetTurnState(TurnState.Init);
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
            OnHeroCreated?.Invoke(PlayerHero, true);

            EnemyHero = heroFactory.CreateHero(enemyHeroClass, enemyGO);
            OnHeroCreated?.Invoke(EnemyHero, false);

            playerAvatar.SetAvatar(PlayerHero);
            enemyAvatar.SetAvatar(EnemyHero);
            GameModeManager.Instance.SetTurnState(TurnState.PlayerTurn);
        }
    }
}
