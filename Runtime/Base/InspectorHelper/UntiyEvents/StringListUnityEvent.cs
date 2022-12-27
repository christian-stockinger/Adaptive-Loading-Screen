using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace AdaptiveLoadingScreen.Base
{
    /// <summary>
    /// Unity Event for String Lists
    /// </summary>
    [Serializable]
    public class StringListUnityEvent : UnityEvent<List<string>>
    {
    }
}
