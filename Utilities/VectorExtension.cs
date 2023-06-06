using UnityEngine;

namespace TeamSleaze.Utilities
{
    public static class VectorExtension
    {
        /// <summary>
        /// Set the x position of this Vector3.
        /// </summary>
        public static Vector3 SetX(this Vector3 pos, float x)
        {
            return new Vector3(x, pos.y, pos.z);
        }

        /// <summary>
        /// Set the y position of this Vector3.
        /// </summary>
        public static Vector3 SetY(this Vector3 pos, float y)
        {
            return new Vector3(pos.x, y, pos.z);
        }

        /// <summary>
        /// Set the z position of this Vector3.
        /// </summary>
        public static Vector3 SetZ(this Vector3 pos, float z)
        {
            return new Vector3(pos.x, pos.y, z);
        }

        /// <summary>
        /// Add vector2 to Vector3.
        /// </summary>
        public static void Add(this Vector3 vector3, Vector2 vector)
        {
            vector3.x += vector.x;
            vector3.y += vector.y;
        }

        /// <summary>
        /// Subtract vector2 from Vector3.
        /// </summary>
        public static void Subtract(this Vector3 vector3, Vector2 vector)
        {
            vector3.x -= vector.x;
            vector3.y -= vector.y;
        }

        /// <summary>
        /// Turn a Vector2 into a Vector3
        /// </summary>
        /// <param name="v">The vector to convert</param>
        /// <returns></returns>
        public static Vector3 ToVector3(this Vector2 v)
        {
            return new Vector3(v.x, v.y, 0);
        }

        /// <summary>
        /// Turn a Vector3 into a Vector2
        /// </summary>
        /// <param name="v">The vector to convert</param>
        /// <returns></returns>
        public static Vector2 ToVector2(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }
    }
}