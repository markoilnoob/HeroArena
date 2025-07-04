using HeroArena;
using UnityEngine;
using UnityEngine.UI;

namespace HeroArena.UI
{
    [RequireComponent(typeof(UIButton))]
    public class UIAbilityButton : MonoBehaviour
    {
        private UIButton button;

        private void Awake() => button = GetComponent<UIButton>();

        public void Init(HeroAbility ability)
        {
            button.SetSprite(ability.abilityDescription.sprite);
            button.SetText(null);
            
            // TODO: Single controller based for each hero should help to decouple this
            button.onClick -= ability.ActivateAbility;
            button.onClick += ability.ActivateAbility;
        }
    }
}
