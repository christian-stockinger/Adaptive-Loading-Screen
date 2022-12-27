using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace AdaptiveLoadingScreen.Base
{
    /// <summary>
    /// Unity Event for Float Lists
    /// </summary>
    [Serializable]
    public class FloatListUnityEvent : UnityEvent<List<float>>
    {
    }
}
