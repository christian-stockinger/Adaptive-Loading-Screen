using System;
using UnityEngine.Events;

namespace AdaptiveLoadingScreen.Base
{
    /// <summary>
    /// Unity Event for Strings
    /// </summary>
    [Serializable]
    public class StringUnityEvent : UnityEvent<string>
    {
    }
}