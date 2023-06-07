using TeamSleaze.Utilities.Timer;
using UnityEngine;

namespace TeamSleaze
{
    public class TestingTimer : MonoBehaviour
    {
        public string TargetUID;

        private void OnEnable()
        {
            AdjustableTimer.OnAdjustableAmountOfSecondsPassed += Test;
        }

        private void OnDisable()
        {
            AdjustableTimer.OnAdjustableAmountOfSecondsPassed -= Test;
        }

        private void Test(string uid)
        {
            if (uid != TargetUID) return;
            
            Debug.Log($"UID: {uid}", gameObject);
        }
    }
}
