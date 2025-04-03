using HeroArena;
using UnityEngine;

public class LoadSplashScreen : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.LoadScene("SCN_SplashScreen");
    }
}
