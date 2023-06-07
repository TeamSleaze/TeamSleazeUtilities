using System.Data;

namespace TeamSleaze.Utilities.Timer
{
    public class AdjustableTimer : Timer
    {
        public float Interval;

        public delegate void AdjustableAmountOfSecondsPassed();
        public static event AdjustableAmountOfSecondsPassed OnAdjustableAmountOfSecondsPassed;


        protected override void Start()
        {
            if (Interval == 0) {
                throw new NoNullAllowedException("Interval can't be null!");
            }
            else StartCoroutine(CallEvent(OnAdjustableAmountOfSecondsPassed, Interval));
        }
    }
}