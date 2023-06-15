using TeamSleaze.Internal;
using UnityEngine;
using UnityEngine.Events;

namespace TeamSleaze.Utilities
{
    public class Orphan : MonoBehaviour
    {
        [Space(10)] 
        public UpdateTime WhenShouldThisOrphan;

        [HideInInspector]
        public UnityEvent Event;

        public bool WorldPositionStays = true;


        private void Awake()
        {
            if (WhenShouldThisOrphan == UpdateTime.Awake)
            {
                gameObject.transform.SetParent(null, WorldPositionStays);
            }
        }

        private void Start()
        {
            if (WhenShouldThisOrphan == UpdateTime.Start)
            {
                gameObject.transform.SetParent(null, WorldPositionStays);
            }
            else if (WhenShouldThisOrphan == UpdateTime.Event)
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