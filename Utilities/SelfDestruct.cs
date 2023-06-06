using System.Collections;
using UnityEngine;

namespace TeamSleaze.Utilities
{
    public class SelfDestruct : MonoBehaviour
    {
        public bool ShouldSelfDestruct;
        public float WaitSeconds;

        private void Awake()
        {
            StartCoroutine(Destruct());
        }

        private IEnumerator Destruct()
        {
            yield return Helpers.GetWaitForSeconds(WaitSeconds);
        }
    }
}