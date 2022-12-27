using System;
using UnityEngine;
using UnityEngine.Events;

namespace AdaptiveLoadingScreen.Base
{
    /// <summary>
    /// Unity Event for Vector2s
    /// </summary>
    [Serializable]
    public class Vector2UnityEvent : UnityEvent<Vector2>
    {
    }
}