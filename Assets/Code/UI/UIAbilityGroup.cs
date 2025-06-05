using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HeroArena.UI
{
    public class UIAbilityGroup : MonoBehaviour, IUIElement
    {
        [SerializeField] private GameObject btnBasePrefab;
        public bool _IsPlayer;

        public void SetController(UIController uiController)
        {
            GameController gameController = uiController as GameController;
            gameController.OnAbilitiesReady -= AbilityUpdate;
            gameController.OnAbilitiesReady += AbilityUpdate;

        }

        private void AbilityUpdate(List<HeroAbility> list, bool IsPlayer)
        {

            if (_IsPlayer == IsPlayer)
            {
                foreach (HeroAbility ability in list)
                {
                    Debug.Log(ability.abilityDescription.abilityID);
                    GameObject buttonAbility = Instantiate(btnBasePrefab, transform);
                    UIAbilityButton btnAbility = buttonAbility.AddComponent<UIAbilityButton>();
                    btnAbility.Init(ability);
                }
            }
        }
    }
}

//SpriteRenderer spriteButton = null;
//spriteButton = new SpriteRenderer();
//this.gameObject.AddComponent<spriteButton>;
//Instantiate(button);
