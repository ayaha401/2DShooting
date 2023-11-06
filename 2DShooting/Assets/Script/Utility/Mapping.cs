using UnityEngine;
using MyInput;

namespace Utility
{
    public class Mapping
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Bind()
        {
            Locator<PlayerInput>.Bind(new PlayerInput());
        }
    }
}

