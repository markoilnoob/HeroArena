using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    public class EnemyAI : MonoBehaviour
    {
        private float waitTime = 3f;
        private int numberOfChoice = 2;
        private Hero heroObj;

        private void Awake()
        {
            GameModeManager.OnNewTurnState -= OnEnemyTurnState;
            GameModeManager.OnNewTurnState += OnEnemyTurnState;
            //HeroAbility.OnEnemyTurn -= ChooseAbility;
            //HeroAbility.OnEnemyTurn += ChooseAbility;

            ArenaGameManager.Instance.OnHeroCreated -= OnEnemyHeroCreated;
            ArenaGameManager.Instance.OnHeroCreated += OnEnemyHeroCreated;
        }

        void OnEnemyTurnState(TurnState turnState)
        {
            if (turnState == TurnState.EnemyTurn)
            {
                StartCoroutine(Thinking());
            }
        }

        void OnEnemyHeroCreated(Hero hero, bool IsPlayer)
        {
            if (!IsPlayer)
            {
                heroObj = hero;
            }
        }

        void ChooseAbility()
        {
            StartCoroutine(Thinking());
        }

        private IEnumerator Thinking()
        {
            yield return new WaitForSeconds(waitTime);
            var rnd = UnityEngine.Random.Range(0, numberOfChoice);

            heroObj.GetHeroAbilities()[rnd].ActivateAbility();

            /*switch (rnd)
            {
                case 0:
                    //dodge();
                    Debug.Log($"Enemy chooses to {heroObj.GetHeroAbilities()[0].abilityDescription.abilityName}");
                    heroObj.GetHeroAbilities()[0].ActivateAbility();
                    break;
                case 1:
                    //attack();
                    Debug.Log($"Enemy chooses to {heroObj.GetHeroAbilities()[1].abilityDescription.abilityName}");
                    heroObj.GetHeroAbilities()[1].ActivateAbility();
                    break;
                default:
                    break;
            }*/
        }
    }
}
