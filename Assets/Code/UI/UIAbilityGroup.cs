using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeroArena.UI
{
    public class UIAbilityGroup : MonoBehaviour, IUIElement
    {
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
                }
            }
        }
    }
}
