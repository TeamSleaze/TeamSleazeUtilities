 using UnityEngine;
using UnityEngine.Events;

namespace TeamSleaze.Utilities
{
    public class Orphan : MonoBehaviour
    {
        public enum Time
        {
            Awake = 0,
            Start = 1,
            Event = 2
        }

        [SerializeField] 
        private bool ShouldThisOrphan = false;

        [Space(10)] 
        public Time WhenShouldThisOrphan;

        [SerializeField, HideInInspector] 
        private UnityEvent Event;

        [SerializeField] 
        private bool WorldPositionStays = true;


        private void Awake()
        {
            if (ShouldThisOrphan && WhenShouldThisOrphan == Time.Awake)
            {
                gameObject.transform.SetParent(null, WorldPositionStays);
            }
        }

        private void Start()
        {
            if (ShouldThisOrphan && WhenShouldThisOrphan == Time.Start)
            {
                gameObject.transform.SetParent(null, WorldPositionStays);
            }
            else if (ShouldThisOrphan && WhenShouldThisOrphan == Time.Event)
            {
                Event.AddListener(() => ExecuteOnEventCall());
            }
        }

        private void ExecuteOnEventCall()
        {
            gameObject.transform.SetParent(null, WorldPositionStays);
        }

    }
}