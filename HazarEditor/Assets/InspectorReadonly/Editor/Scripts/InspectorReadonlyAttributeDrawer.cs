using InspectorReadonly.Runtime.Scripts;
using UnityEditor;
using UnityEngine;

namespace InspectorReadonly.Editor.Scripts
{
    [CustomPropertyDrawer(typeof(InspectorReadonlyAttribute))]
    public class InspectorReadonlyAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            bool originalGUIState = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = originalGUIState;
        }
    }
}