using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HeroArena
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField] private Image IMG_Fade;

        [SerializeField] private float timeToFade = 1.0f;
        Coroutine fadeInCoroutine;
        Coroutine fadeOutCoroutine;
        public Action OnFadeOutComplete;

        //Singleton
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

        #region FadeSystem
        public void FadeIn()
        {
            if (fadeInCoroutine == null)
                fadeInCoroutine = StartCoroutine(FadeInCO());
            else
                Debug.LogWarning("FadeIn is already running");
        }

        public void FadeOut()
        {
            fadeOutCoroutine = StartCoroutine(FadeOutCO());
        }

        private IEnumerator FadeInCO()
        {
            float alphaValue = 1f;
            Color colorIMG = Color.black;

            while (alphaValue >= 0f)
            {
                alphaValue -= Time.deltaTime / timeToFade;
                colorIMG.a = alphaValue;
                IMG_Fade.color = colorIMG;
                yield return null;
                Debug.Log(alphaValue);
            }
            fadeInCoroutine = null;
            IMG_Fade.raycastTarget = false;
        }

        private IEnumerator FadeOutCO()
        {
            IMG_Fade.raycastTarget = true;
            float alphaValue = 0f;
            Color colorIMG = Color.black;
            while (alphaValue <= 1f)
            {
                alphaValue += Time.deltaTime / timeToFade;
                colorIMG.a = alphaValue;
                IMG_Fade.color = colorIMG;
                yield return null;
                Debug.Log(alphaValue);
            }
            fadeOutCoroutine = null;
            OnFadeOutComplete?.Invoke();
        }
        #endregion
    }
}
