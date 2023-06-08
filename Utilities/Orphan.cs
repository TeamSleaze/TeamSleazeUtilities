using TeamSleaze.Internal;
using UnityEngine;
using UnityEngine.Events;

namespace TeamSleaze.Utilities
{
    public class Orphan : MonoBehaviour
    {
        [SerializeField] 
        private bool ShouldThisOrphan = false;

        [Space(10)] 
        public UpdateTime WhenShouldThisOrphan;

        [SerializeField, HideInInspector] 
        private UnityEvent Event;

        [SerializeField] 
        private bool WorldPositionStays = true;


        private void Awake()
        {
            if (ShouldThisOrphan && WhenShouldThisOrphan == UpdateTime.Awake)
            {
                gameObject.transform.SetParent(null, WorldPositionStays);
            }
        }

        private void Start()
        {
            if (ShouldThisOrphan && WhenShouldThisOrphan == UpdateTime.Start)
            {
                gameObject.transform.SetParent(null, WorldPositionStays);
            }
            else if (ShouldThisOrphan && WhenShouldThisOrphan == UpdateTime.Event)
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