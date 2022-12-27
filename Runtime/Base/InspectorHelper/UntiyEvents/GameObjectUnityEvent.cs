using System;
using UnityEngine;
using UnityEngine.Events;

namespace AdaptiveLoadingScreen.Base
{
    /// <summary>
    /// Unity Event for GameObjects
    /// </summary>
    [Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject>
    {
    }
}