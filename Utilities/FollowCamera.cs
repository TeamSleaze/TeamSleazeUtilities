using TeamSleaze.Internal;
using TeamSleaze.Utilities;
using UnityEngine;

namespace TeamSleaze.Assets.Utilities
{
    public class FollowCamera : MonoBehaviour
    {
        private Camera mainCamera;

        [SerializeField]
        private bool followCamera = true;
        [SerializeField]
        private UpdateTime updateTime = UpdateTime.LateUpdate;


        private void Start()
        {
            mainCamera = Helpers.MainCamera;
        }

        private void Update()
        {
            if (followCamera && updateTime == UpdateTime.Update) 
            {
                transform.position = mainCamera.transform.position;
            }
        }

        void LateUpdate()
        {
            if (followCamera && updateTime == UpdateTime.LateUpdate)
            {
                transform.position = mainCamera.transform.position;
            }
        }

    }
}