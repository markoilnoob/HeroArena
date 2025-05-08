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
}
