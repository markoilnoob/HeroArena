using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using HeroArena.UI;
using System.Collections.Generic;
using System.Linq;

namespace HeroArena
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField] private Image IMG_Fade;

        [SerializeField] private float timeToFade = 1.0f;
        //Coroutine fadeInCoroutine;
        //Coroutine fadeOutCoroutine;
        Coroutine fade;
        public Action OnFadeInComplete;
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
            if (IMG_Fade == null)
            {
                StartCoroutine(FakeFade(true));
                return;
            }
            if (fade == null)
                fade = StartCoroutine(Fade(Color.black, true));
            else
                Debug.LogWarning("A Fade is already running");
        }

        public void FadeOut()
        {
            if (IMG_Fade == null)
            {
                StartCoroutine(FakeFade(false));
                return;
            }
            if (fade == null)
                fade = StartCoroutine(Fade(Color.black, false));
            else
                Debug.LogWarning("A Fade is already running");

            //fadeOutCoroutine = StartCoroutine(FadeOutCO());
        }

        private IEnumerator Fade(Color colorFade, bool IsFadeIn)
        {
            //Mouse cannot interact with others canvases
            if (!IsFadeIn)
                IMG_Fade.raycastTarget = true;

            float alphaValue = (IsFadeIn) ? 1f : 0f;
            float targetAlpha = (IsFadeIn) ? 0f : 1f;

            //              FadeOut                                     FadeIn
            while ((alphaValue <= targetAlpha && !IsFadeIn) || (alphaValue >= targetAlpha && IsFadeIn))
            {
                float temp = Time.deltaTime / timeToFade;
                alphaValue += (IsFadeIn) ? -temp : temp;
                colorFade.a = alphaValue;
                IMG_Fade.color = colorFade;
                yield return null;
                Debug.Log(alphaValue);
            }
            fade = null;

            if (IsFadeIn)
            {
                OnFadeInComplete?.Invoke();
                IMG_Fade.raycastTarget = false;
            }
            else
            {
                OnFadeOutComplete?.Invoke();
            }
        }

        IEnumerator FakeFade(bool IsFadeIn)
        {
            yield return new WaitForSeconds(1f);
            if (IsFadeIn)
            {
                OnFadeInComplete?.Invoke();
            }
            else
            {
                OnFadeOutComplete?.Invoke();
            }
        }

        /*
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
        }*/
        #endregion

        #region UI Stack Management

        private List<UIPanel> panelStack = new List<UIPanel>();

        public void PushPanel(UIPanel panel)
        {
            if(panel != null)
            {
                panelStack.Add(panel);
            }
        }

        public void RemovePanel(UIPanel panel)
        {
            if (panelStack.Count > 0 && panelStack.Last() == panel)
            {
                panelStack.Remove(panel);
            }
            else
            {
                Debug.LogWarning("Trying to remove a panel not on top of the stack!");
            }
        }

        #endregion
    }
}
