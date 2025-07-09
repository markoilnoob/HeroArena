using System;
using JetBrains.Annotations;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
   
    public static ItemManager Instance { get; private set; }
    public float itemCostitution = 1;
    public float itemStrength =1;
    public float itemSpeed = 1;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   

    public void PassStats(float costitution = 1, float strenght = 1, float speed = 1)
    {
        Debug.Log($"constitution{costitution}, strenght{strenght}, speed{speed}");
        itemCostitution = costitution;
        itemStrength = strenght;
        itemSpeed = speed;
    }


}
