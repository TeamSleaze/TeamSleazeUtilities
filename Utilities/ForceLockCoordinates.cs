using System;
using TeamSleaze.Internal;
using UnityEngine;

namespace TeamSleaze.Utilities
{
    [Flags]
    public enum Vector3Enum 
    { 
        None = 0, 
        X = 1, 
        Y = 2, 
        Z = 4 
    }

    [RequireComponent(typeof(Transform))]
    public class ForceLockCoordinates : MonoBehaviour
    {
        public Vector3Enum LockCoordinates;
        public UpdateTime UpdateTime;
        public Vector3 lockToValue;


        private void Update()
        {
            if (UpdateTime == UpdateTime.Update) LockPosition();
        }

        private void FixedUpdate()
        {
            if (UpdateTime == UpdateTime.FixedUpdate) LockPosition();
        }

        private void LateUpdate()
        {
            if (UpdateTime == UpdateTime.LateUpdate) LockPosition();
        }

        private void LockPosition()
        {
            if (LockCoordinates.HasFlag(Vector3Enum.X)) transform.LockXPos(lockToValue.x);
            if (LockCoordinates.HasFlag(Vector3Enum.Y)) transform.LockYPos(lockToValue.y);
            if (LockCoordinates.HasFlag(Vector3Enum.Z)) transform.LockZPos(lockToValue.z);
        }
    }
}