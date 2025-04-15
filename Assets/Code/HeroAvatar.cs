using UnityEngine;
using System.Collections;

namespace HeroArena
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HeroAvatar : MonoBehaviour
    {
        [Header("Eroe da impostare")]
        [SerializeField] private HeroClass heroToDisplay = HeroClass.NONE;
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

        public void SetAvatar(HeroClass heroClass)
        {
            heroToDisplay = heroClass;

            // Recupera la descrizione dell'eroe dal GameState
            HeroDescription description = GameState.Instance.GetHeroDescription(heroClass);
            if (description == null || description.heroBigPortrait == null)
            {
                Debug.LogWarning($"Sprite mancante per {heroClass}");
                return;
            }

            // Imposta lo sprite dell'avatar
            spriteRenderer.sprite = description.heroBigPortrait;
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
