using ProgressBar.Runtime.Scripts;
using UnityEditor;
using UnityEngine;

namespace ProgressBar.Editor.Scripts
{
    [CustomPropertyDrawer(typeof(ProgressBarAttribute))]
    public class ProgressBarDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ProgressBarAttribute progressBar = (ProgressBarAttribute)attribute;

            if (property.propertyType == SerializedPropertyType.Float)
            {
                EditorGUI.LabelField(position, label);
                Rect progressBarRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);
                
                EditorGUI.DrawRect(progressBarRect, Color.gray);

                float progress = Mathf.Clamp((property.floatValue - progressBar.min) / (progressBar.max - progressBar.min), 0, 1);
                EditorGUI.DrawRect(new Rect(progressBarRect.x, progressBarRect.y, progressBarRect.width * progress, progressBarRect.height), new Color(0f, 0.52f, 0f, 0.75f));
                EditorGUI.LabelField(progressBarRect, new GUIContent($"{(progress * 100):F2}%"), new GUIStyle() { alignment = TextAnchor.MiddleCenter, normal = { textColor = Color.white } });

                property.floatValue = EditorGUI.FloatField(new Rect(position.x, progressBarRect.y + EditorGUIUtility.singleLineHeight + 2, position.width, EditorGUIUtility.singleLineHeight), property.floatValue);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use ProgressBar with float.");
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight * 2 + 4;
        }
    }
}