using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
   

    [RequireComponent(typeof(HeroFactory))]
    public class ArenaGameManager : MonoBehaviour
    {
        private HeroFactory heroFactory;
        [Header("Hero Avatar Options")]
        [SerializeField] private HeroAvatar playerAvatar;
        [SerializeField] private HeroAvatar enemyAvatar;
        [SerializeField] private GameObject playerGO;
        [SerializeField] private GameObject enemyGO;
        public List<Hero> PlayerHeroes { get; private set; } = new();
        public List<Hero> EnemyHeroes { get; private set; } = new();

        public Action<Hero, bool /* IsPlayer */> OnHeroCreated;

        public bool isPlayerWinner = false;

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
            if (GameManager.Instance.GetSceneState() != SceneState.ArenaBattle) return;

            Debug.Log("Game Started");

            // Eroi giocatore
            for (int i = 0; i < 2; i++)
            {
                HeroClass heroClass = (i == 0 && GameState.Instance.HeroSelected != HeroClass.NONE)
                    ? GameState.Instance.HeroSelected
                    : HeroArenaUtils.GetRandomEnumValue<HeroClass>(1, 0);

                GameObject playerObj = Instantiate(playerGO, playerGO.transform.parent);
                Hero hero = heroFactory.CreateHero(heroClass, playerObj);
                PlayerHeroes.Add(hero);
                OnHeroCreated?.Invoke(hero, true);
            }

            // Eroi nemici
            for (int i = 0; i < 2; i++)
            {
                HeroClass enemyClass = HeroArenaUtils.GetRandomEnumValue<HeroClass>(1, 0);
                GameObject enemyObj = Instantiate(enemyGO, enemyGO.transform.parent);
                Hero enemy = heroFactory.CreateHero(enemyClass, enemyObj);
                EnemyHeroes.Add(enemy);
                OnHeroCreated?.Invoke(enemy, false);
            }

            // Avatar
            if (PlayerHeroes.Count > 0) playerAvatar.SetAvatar(PlayerHeroes[0]);
            if (EnemyHeroes.Count > 0) enemyAvatar.SetAvatar(EnemyHeroes[0]);

            GameModeManager.Instance.SetTurnState(TurnState.PlayerTurn);
            UIManager.Instance.OnFadeInComplete -= StartGame;
        }


        public void EndGame(bool isPlayerHeroDead)
        {
            isPlayerWinner = !isPlayerHeroDead;
            GameModeManager.Instance.SetTurnState(TurnState.EndGame);
            GameManager.Instance.SetSceneState(SceneState.EndArenaBattle);
            GameManager.Instance.LoadScene("SCN_EndGame");           
        }
    }
}
