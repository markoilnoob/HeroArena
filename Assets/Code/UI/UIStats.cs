using TMPro;
using UnityEngine;

namespace HeroArena.UI
{
    public class UIStats : MonoBehaviour, IUIElement
    {
        private GameController gameController;
        public bool _IsPlayer;

        [SerializeField] private TextMeshProUGUI health;
        [SerializeField] private TextMeshProUGUI stamina;
        [SerializeField] private TextMeshProUGUI dodge;
        public float itemCostitution;
        public float itemStrength;
        public float itemSpeed;

        public void SetController(UIController uiController)
        {
            gameController = uiController as GameController;
            if (gameController == null)
            {
                Debug.LogWarning("gameController is null");
                return;
            }

            gameController.OnHeroStatsCalculated -= OnHeroStatsUpdate;
            gameController.OnHeroStatsCalculated += OnHeroStatsUpdate;
        }
        
        private void OnHeroStatsUpdate(HeroStats heroStats, bool isPlayer)
        {
            if (_IsPlayer == isPlayer)
            {
                health.text = $"{heroStats.CurrentHealth} hp";
                stamina.text = $"{heroStats.CurrentStamina} hp";
                dodge.text = $"{heroStats.CurrentDodge} hp";
            }
        }
    }
}
