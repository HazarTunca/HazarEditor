using RequiredField.Runtime.Scripts;
using UnityEditor;
using UnityEngine;

namespace RequiredField.Editor.Scripts
{
    [CustomPropertyDrawer(typeof(RequiredFieldAttribute))]
    public class RequiredFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RequiredFieldAttribute requiredFieldAttribute = (RequiredFieldAttribute)attribute;

            bool isRequiredFieldMissing = property.objectReferenceValue == null && property.propertyType == SerializedPropertyType.ObjectReference;

            if (isRequiredFieldMissing)
            {
                Color originalColor = GUI.color;
                GUI.color = Color.red;

                GUILayout.Space(16);
                
                EditorGUI.PropertyField(position, property, label);
                Rect helpBoxPosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 1.25f, position.width, EditorGUIUtility.singleLineHeight);
                EditorGUI.HelpBox(helpBoxPosition, requiredFieldAttribute.message, MessageType.Warning);

                GUI.color = originalColor;
                
                GUILayout.Space(8);
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) + (property.objectReferenceValue == null ? EditorGUIUtility.singleLineHeight * 0.25f : 0);
        }
    }
}