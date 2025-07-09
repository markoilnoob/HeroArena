using HeroArena.UI;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace HeroArena
{
    public class UIAbilitySelectionPanel : MonoBehaviour, IUIElement
    {
        [SerializeField] private AbilitySelectionButton BTN_abilitySelectionPrefab;
        List<AbilitySelectionButton> abilityButtons;
        private MainMenuController menuController;
        private HeroAbilityDescription selectedAbility = null;

        private void Awake() => abilityButtons = new List<AbilitySelectionButton>();

        private void Start()
        {
            HeroAbilityDescription[] heroAbilities = Resources.LoadAll<HeroAbilityDescription>("HeroAbilities");
            foreach (var ability in heroAbilities)
            {
                //
                if (ability.abilityID.Equals("5") || ability.abilityID.Equals("6") || ability.abilityID.Equals("7"))
                {
                    AbilitySelectionButton btn_ability = Instantiate(BTN_abilitySelectionPrefab, this.transform);
                    btn_ability.Init(ability);

                    btn_ability.OnSelected -= SelectAbility;
                    btn_ability.OnSelected += SelectAbility;

                    abilityButtons.Add(btn_ability);

                    btn_ability.SetText(ability.abilityName);
                }
            }
        }

        private void SelectAbility(HeroAbilityDescription heroAbility)
        {
            selectedAbility = heroAbility;

            foreach (var abilityBtn in abilityButtons)
            {
                bool isSelected = abilityBtn.GetAbilityDescription() == heroAbility;
                abilityBtn.SetSelectedState(isSelected);
                GameState.Instance.ConfirmAbilitySelection(selectedAbility);
            }

            Debug.Log($"Selected ability: {heroAbility.abilityName}");
        }

        public void SetController(UIController uIController)
        {
            menuController = uIController as MainMenuController;
        }
    }
}
