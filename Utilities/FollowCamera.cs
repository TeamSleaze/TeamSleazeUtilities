using TeamSleaze.Utilities;
using UnityEngine;

namespace TeamSleaze.Assets.Utilities
{
    public class FollowCamera : MonoBehaviour
    {
        private Camera mainCamera;

        [SerializeField]
        private bool followCamera = true;


        private void Start()
        {
            mainCamera = Helpers.MainCamera;
        }

        void LateUpdate()
        {
            if (followCamera) transform.position = mainCamera.transform.position;
        }

    }
}