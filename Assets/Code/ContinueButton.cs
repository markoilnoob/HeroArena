using HeroArena;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(UIButton))]
public class ContinueButton : MonoBehaviour
{
    UIButton button;


    private void Awake()
    {
        button = GetComponent<UIButton>();
    }

    private void Start()
    {
        if(GameState.Instance.HeroSelected == HeroClass.NONE)
        {
            bool newActive = false;
            button.SetButtonActive(newActive);
        }
    }
}
