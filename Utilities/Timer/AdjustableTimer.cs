using System;
using System.Data;

namespace TeamSleaze.Utilities.Timer
{
    public class AdjustableTimer : Timer
    {
        public float Interval;
        public string UID;

        public delegate void AdjustableAmountOfSecondsPassed(string uid);
        public static event AdjustableAmountOfSecondsPassed OnAdjustableAmountOfSecondsPassed;


        protected override void Start()
        {
            if (String.IsNullOrEmpty(UID))
            {
                throw new NoNullAllowedException("ID cannot be empty!");
            }
            if (Interval == 0)
            {
                throw new NoNullAllowedException("Interval can't be null!");
            }

            else StartCoroutine(CallEvent(OnAdjustableAmountOfSecondsPassed, Interval, UID));
        }
    }
}