using System;
using UnityEngine;

namespace HeroArena
{
    public enum TurnState
    {
        Init,
        PlayerTurn,
        EnemyTurn,
        EndGame
    }
    public class GameModeManager : MonoBehaviour
    {
        /* -initialization 
         *    UI
         *    Stats
         *    Hero
         * -Start Game
         *    Player turn
         *      Wait for player input
         *      Dmg, dodge, UI ...
         *    Enemy turn
         *      Wait for AI input
         *      Dmg, dodge, UI ...
         *    End Game
        */
        public static GameModeManager Instance { get; private set; }

        public TurnState turnState;

        public static Action<TurnState> OnNewTurnState;

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

        public void SetTurnState(TurnState newTurnState)
        {
            turnState = newTurnState;
            OnNewTurnState?.Invoke(turnState);
            Debug.Log($"turnstate {turnState}");
        }

        public TurnState GetTurnState()
        {
            return turnState;
        }
    }
}
