using System;
using UnityEngine;

namespace HeroArena.UI
{
    public class AbilitySelectionButton : UIButton 
    {
        public Action<HeroAbilityDescription> OnSelected;
        private HeroAbilityDescription abilityDescription;
        private Color UnSelectedColor;
        public Color SelectedColor;

        public void Init(HeroAbilityDescription ability)
        {
            abilityDescription = ability;
        }

        public HeroAbilityDescription GetAbilityDescription()
        {
            return abilityDescription;
        }

        public void SetSelectedState(bool selected)
        {
            Debug.Log($"is selected {selected}");
            if (selected)
            {
                SetImageColor(SelectedColor);
            }
            else
            {
                SetImageColor(UnSelectedColor);
            }
        }
    }
}
