using System;
using UnityEngine;
using UnityEngine.Events;

namespace AdaptiveLoadingScreen.Base
{
    /// <summary>
    /// Unity Event for Textures
    /// </summary>
    [Serializable]
    public class TextureUnityEvent : UnityEvent<Texture>
    {
    }
}