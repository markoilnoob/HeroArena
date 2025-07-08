using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField] private GameObject heroPanel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackPanel()
    {
        heroPanel.SetActive(false);
    }
}
