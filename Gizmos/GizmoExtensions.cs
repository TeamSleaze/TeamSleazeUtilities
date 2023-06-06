using UnityEngine;

namespace TeamSleaze.Gizmos
{
    public class GizmoExtensions
    {
        /// <summary>
        /// Thanks to: http://forum.unity3d.com/threads/debug-drawarrow.85980/
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="direction"></param>
        /// <param name="arrowHeadLength"></param>
        /// <param name="arrowHeadAngle"></param>
        public static void DrawArrow(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
        {
            UnityEngine.Gizmos.DrawRay(pos, direction);
            DrawArrowEnd(true, pos, direction, UnityEngine.Gizmos.color, arrowHeadLength, arrowHeadAngle);
        }

        private static void DrawArrowEnd(bool gizmos, Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
        {
            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(arrowHeadAngle, 0, 0) * Vector3.back;
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(-arrowHeadAngle, 0, 0) * Vector3.back;
            Vector3 up = Quaternion.LookRotation(direction) * Quaternion.Euler(0, arrowHeadAngle, 0) * Vector3.back;
            Vector3 down = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -arrowHeadAngle, 0) * Vector3.back;
            UnityEngine.Gizmos.color = color;
            UnityEngine.Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
            UnityEngine.Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
            UnityEngine.Gizmos.DrawRay(pos + direction, up * arrowHeadLength);
            UnityEngine.Gizmos.DrawRay(pos + direction, down * arrowHeadLength);
        }

    }

}