using HeroArena;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(UIButton))]
public class InventoryButton : MonoBehaviour
{
    UIButton button;
     public GameObject inventoryPanel;
    private void Awake()
    {
        button = GetComponent<UIButton>();

        button.onClick -= OpenInventoryPanel;
        button.onClick += OpenInventoryPanel;
    }

    private void OpenInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(true);

    }
}
