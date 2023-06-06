using UnityEngine;

namespace TeamSleaze.Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        public bool Preserve;

        private void Awake()
        {
            if (Preserve) DontDestroyOnLoad(this);
        }
    }
}