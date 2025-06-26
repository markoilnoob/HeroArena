using UnityEngine;
using System.Collections.Generic;

namespace HeroArena
{
    public class EffectManager : MonoBehaviour
    {
        public enum EffectTriggerTiming
        {
            OnTurnStart,
            OnTurnEnd,
            OnBoth
        }

        public interface IStatusEffect
        {
            string Name { get; }
            int RemainingTurns { get; }
            void Apply(Hero target);
            void Trigger(Hero target);
            void Remove(Hero target);
            void DecrementTurn();
            bool IsExpired { get; }
        }

        public abstract class StatusEffect : IStatusEffect
        {
            public string Name { get; protected set; }
            public int RemainingTurns { get; protected set; }
            public bool IsExpired => RemainingTurns <= 0;

            public virtual void Apply(Hero target) { }
            public virtual void Trigger(Hero target) { }
            public virtual void Remove(Hero target) { }
            public void DecrementTurn() => RemainingTurns--;
        }

        private class EffectEntry
        {
            public IStatusEffect Effect;
            public EffectTriggerTiming TriggerTiming;
        }

        private List<EffectEntry> activeEffects = new List<EffectEntry>();
        private Hero target;

        public void Initialize(Hero hero)
        {
            target = hero;
        }

        public void ApplyEffect(IStatusEffect effect, EffectTriggerTiming timing)
        {
            effect.Apply(target);
            activeEffects.Add(new EffectEntry { Effect = effect, TriggerTiming = timing });
        }

        public void OnTurnEvent(EffectTriggerTiming timing)
        {
            if (target == null) return;

            for (int i = activeEffects.Count - 1; i >= 0; i--)
            {
                var entry = activeEffects[i];
                if (entry.TriggerTiming == timing || entry.TriggerTiming == EffectTriggerTiming.OnBoth)
                {
                    entry.Effect.Trigger(target);
                    entry.Effect.DecrementTurn();
                }
                if (entry.Effect.IsExpired)
                {
                    entry.Effect.Remove(target);
                    activeEffects.RemoveAt(i);
                }
            }
        }
    }
}