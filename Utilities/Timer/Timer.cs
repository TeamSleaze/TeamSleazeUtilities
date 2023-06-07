using System;
using System.Collections;
using UnityEngine;

namespace TeamSleaze.Utilities.Timer
{
    public abstract class Timer : MonoBehaviour
    {
        public static float currentTime { private set; get; } = 0f;
        public static int currentTimeInt { private set; get; } = 0;


        protected abstract void Start();

        private void Update()
        {
            currentTime += Time.deltaTime;
            currentTimeInt = Mathf.FloorToInt(currentTime);
        }

        protected IEnumerator CallEvent(Delegate e, float time, string uid)
        {
            while (true)
            {
                yield return new WaitForSeconds(time);
               e.DynamicInvoke(uid);
            }
        }

    }
}