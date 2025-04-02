using UnityEngine;

namespace HeroArena.UI
{
    public abstract class UIController
    {
        public abstract void BindCallbacks();
        public abstract void BroadcastInitialValues();
    }
}
