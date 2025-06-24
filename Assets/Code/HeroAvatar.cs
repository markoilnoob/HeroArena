using UnityEngine;
using System.Collections;

namespace HeroArena
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HeroAvatar : MonoBehaviour
    {
        [Header("Eroe da impostare")]
        [SerializeField] private float duration = 1.2f;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            transform.localScale = Vector3.zero;

            //if (heroToDisplay != HeroClass.NONE)
            //{
            //    SetAvatar(heroToDisplay);
            //}
            //else
            //{
            //    gameObject.SetActive(false);
            //}
        }

        public void SetAvatar(Hero hero)
        {
            // Imposta lo sprite dell'avatar
            spriteRenderer.sprite = hero.GetHeroDescription().heroBigPortrait;
            transform.localScale = Vector3.zero;

            // Avvia l'animazione di comparsa
           StartCoroutine(AnimateAppearance());
        }

        private IEnumerator AnimateAppearance()
        {
            
            float elapsed = 0f;
            Vector3 startScale = Vector3.zero;
            Vector3 endScale = Vector3.one;

            while (elapsed < duration)
            {
                float t = elapsed / duration;
                float easedT = EasingFunctions.EaseOutBounce(t);
                transform.localScale = Vector3.one * easedT;
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localScale = endScale;
        }
    }
}
