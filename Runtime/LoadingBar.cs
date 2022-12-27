using AdaptiveLoadingScreen.Base;
using Service.Loading;
using UnityEngine;

namespace UnityTemplateProjects.Service.Loading
{
    public class LoadingBar : MonoBehaviour
    {
        public FloatUnityEvent LoadingPercentageChanged;
        public StringUnityEvent LoadingInformationChanged;

        private void Awake()
        {
            LoadingService.Instance.LoadingInformationChanged += OnLoadingInformationChanged;
            LoadingService.Instance.CurrentLoadingProgressChanged += OnCurrentLoadingProgressChanged;
        }

        private void OnCurrentLoadingProgressChanged(float percentage)
        {
            GenerateLoadingText();
            UnityMainThreadDispatcher.Instance.Enqueue(() => LoadingPercentageChanged.Invoke(percentage));
        }

        private void OnLoadingInformationChanged(string information)
        {
            GenerateLoadingText();
        }

        private void GenerateLoadingText()
        {
            string loadingText = $"{LoadingService.Instance.LoadingInformation} ({LoadingService.Instance.CurrentLoadingProgress:P2})";
            UnityMainThreadDispatcher.Instance.Enqueue(() => LoadingInformationChanged.Invoke(loadingText));
        }
    }
}