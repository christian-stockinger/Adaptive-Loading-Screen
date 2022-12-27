using AdaptiveLoadingScreen.Base;
using UnityEngine;

namespace Service.Loading
{
    public class LoadingServiceListener : MonoBehaviour

    {
        public BoolUnityEvent ActiveChanged;
        

        private void Awake()
        {
            LoadingService.Instance.LoadingActiveChanged += OnLoadingActiveChanged;
        }

        private void OnLoadingActiveChanged(bool active)
        {
            UnityMainThreadDispatcher.Instance.Enqueue(() => ActiveChanged.Invoke(active));
        }
    }
}