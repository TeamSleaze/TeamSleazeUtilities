#if UNITY_EDITOR

using UnityEditor;

namespace TeamSleaze.Utilities
{
    [CustomEditor(typeof(Orphan))]
    public class OrphanEditor : Editor
    {
        SerializedProperty Time;
        SerializedProperty EventField;


        private void OnEnable()
        {
            Time = serializedObject.FindProperty("WhenShouldThisOrphan");
            EventField = serializedObject.FindProperty("Event");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(Time);

            if (Time.enumValueIndex == 2)
            {
                EditorGUILayout.PropertyField(EventField);
            }

            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }
    }
}

#endif