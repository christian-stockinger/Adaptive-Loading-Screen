using System;
using UnityEngine;
using UnityEngine.Events;

namespace AdaptiveLoadingScreen.Base
{
    /// <summary>
    /// Unity Event for Colors
    /// </summary>
    [Serializable]
    public class ColorUnityEvent : UnityEvent<Color>
    {
    }
}