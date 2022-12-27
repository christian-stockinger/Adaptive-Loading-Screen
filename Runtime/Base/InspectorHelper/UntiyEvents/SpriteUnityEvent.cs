using System;
using UnityEngine;
using UnityEngine.Events;

namespace AdaptiveLoadingScreen.Base
{
    /// <summary>
    /// Unity Event for Sprites
    /// </summary>
    [Serializable]
    public class SpriteUnityEvent : UnityEvent<Sprite>
    {
    }
}