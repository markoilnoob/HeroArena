using System.Collections;
using UnityEngine;

namespace HeroArena
{
    public class SplashScreen : MonoBehaviour
    {
        Coroutine fade;
        [SerializeField] private float timeToPass = 5f;

        private void Start()
        {
            UIManager.Instance.OnFadeOutComplete -= ChangeScene;
            UIManager.Instance.OnFadeOutComplete += ChangeScene;
            fade = StartCoroutine(FadeSplash());
        }

        IEnumerator FadeSplash()
        {
            UIManager.Instance.FadeIn();
            yield return new WaitForSecondsRealtime(timeToPass);
            UIManager.Instance.FadeOut();
        }

        private void ChangeScene()
        {
            GameManager.Instance.SetSceneState(SceneState.MainMenu);
            GameManager.Instance.LoadScene("SCN_MainMenu");
            GameManager.Instance.UnloadScene("SCN_SplashScreen");
        }
    }
}
