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

        button.onClick -= loadScene;
        button.onClick += loadScene;
    }

    private void loadScene()
    {
        //GameManager.Instance.SetSceneState(SceneState.MainMenu);
        GameManager.Instance.LoadScene("SCN_SplashScreen");
    }
}
