using System;
using UnityEngine;
using UnityEngine.Events;

namespace AdaptiveLoadingScreen.Base
{
    /// <summary>
    /// Unity Event for Vector3s
    /// </summary>
    [Serializable]
    public class Vector3UnityEvent : UnityEvent<Vector3>
    {
    }
}