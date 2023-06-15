#if UNITY_EDITOR

using System;
using TeamSleaze.Internal;
using UnityEditor;

namespace TeamSleaze.Utilities
{
    [CustomEditor(typeof(Orphan))]
    public class OrphanEditor : Editor
    {
        /*
        SerializedProperty Time;
        SerializedProperty EventField;
        SerializedProperty WorldPositionStays;

        
        private void OnEnable()
        {
            Time = serializedObject.FindProperty("WhenShouldThisOrphan");
            EventField = serializedObject.FindProperty("Event");
            WorldPositionStays = serializedObject.FindProperty("WorldPositionStays");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(Time);

            if (Time.enumValueIndex == (int)UpdateTime.Event)
            {
                EditorGUILayout.PropertyField(EventField);
            }

            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.PrefixLabel("World Position Stays");
            EditorGUILayout.PropertyField(WorldPositionStays);
        }
        */

        SerializedProperty eventProperty;

        Orphan orphanTarget;

        private void OnEnable()
        {
            orphanTarget = (Orphan)target;
            eventProperty = serializedObject.FindProperty("Event");
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (orphanTarget.WhenShouldThisOrphan == UpdateTime.Event)
            {
                EditorGUILayout.PropertyField(eventProperty);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif