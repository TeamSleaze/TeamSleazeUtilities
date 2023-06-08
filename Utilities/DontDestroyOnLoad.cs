using TeamSleaze.Internal;
using UnityEngine;

namespace TeamSleaze.Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        public bool Preserve;
        [Tooltip("Only supports Awake and Start")]
        public UpdateTime UpdateTime = UpdateTime.Awake;

        private void Awake()
        {
            if (Preserve && UpdateTime == UpdateTime.Awake) DontDestroyOnLoad(this);
        }

        private void Start()
        {
            if (Preserve && UpdateTime == UpdateTime.Start) DontDestroyOnLoad(this);
        }
    }
}