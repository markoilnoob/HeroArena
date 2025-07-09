using System;
using HeroArena;
using UnityEngine;

public class ItemsButton : MonoBehaviour
{
    private UIButton button;
    public float costitution;
    public float strength;
    public float speed;
    public bool isActive;

    public static event Action<ItemsButton> OnAnyItemSelected;

    private void Awake()
    {
        button = GetComponent<UIButton>();
        button.onClick -= SetItemActive;
        button.onClick += SetItemActive;
        OnAnyItemSelected -= OnOtherItemSelected;
        OnAnyItemSelected += OnOtherItemSelected;
    }

    private void SetItemActive()
    {
        OnAnyItemSelected?.Invoke(this);

        isActive = true;

        if (isActive)
        {
            button.SetImageColor(Color.green);
            ItemManager.Instance.PassStats(costitution, strength, speed);
        }
    }

    private void OnOtherItemSelected(ItemsButton selectedButton)
    {
        if (selectedButton != this)
        {
            isActive = false;

            if(isActive == false)
            {
                button.SetImageColor(Color.white);
            }

        }
    }
}