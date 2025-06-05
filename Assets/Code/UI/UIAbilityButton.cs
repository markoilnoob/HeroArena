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

        private void Start()
        {
            button.onClick -= ActivateAbility;
            button.onClick += ActivateAbility;
        }

        public void Init(HeroAbility ability)
        {
            button.SetSprite(ability.abilityDescription.sprite);
            button.SetText(null);
        }

        private void ActivateAbility()
        {
            Debug.Log("Yippe!!!");
        }
    }
}
