using MinMax.Runtime.Scripts;
using UnityEditor;
using UnityEngine;

namespace MinMaxSlider.Editor.Scripts
{
    [CustomPropertyDrawer(typeof(MinMaxSliderAttribute))]
    public class MinMaxSliderDrawer : PropertyDrawer
    {
        const float FieldWidth = 45f;
        const float Spacing = 5f;

        float minValue, maxValue;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var minMaxAttribute = (MinMaxSliderAttribute)attribute;
            var propertyType = property.propertyType;

            if (propertyType != SerializedPropertyType.Float && propertyType != SerializedPropertyType.Integer)
            {
                EditorGUI.LabelField(position, label.text, "Use MinMaxSlider with float or int");
                return;
            }

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var minFieldRect = new Rect(position.x, position.y, FieldWidth, position.height);
            var sliderRect = new Rect(position.x + FieldWidth + Spacing, position.y, position.width - (FieldWidth + Spacing) * 2, position.height);
            var maxFieldRect = new Rect(position.xMax - FieldWidth, position.y, FieldWidth, position.height);

            maxValue = Mathf.Clamp(maxValue, minMaxAttribute.min, minMaxAttribute.max);
            minValue = Mathf.Clamp(minValue, minMaxAttribute.min, maxValue);
            
            if (propertyType == SerializedPropertyType.Float)
            {
                minValue = EditorGUI.FloatField(minFieldRect, minValue);
                maxValue = EditorGUI.FloatField(maxFieldRect, maxValue);
                EditorGUI.MinMaxSlider(sliderRect, ref minValue, ref maxValue, minMaxAttribute.min, minMaxAttribute.max);
            }
            else
            {
                minValue = EditorGUI.IntField(minFieldRect, (int)minValue);
                maxValue = EditorGUI.IntField(maxFieldRect, (int)maxValue);
                EditorGUI.MinMaxSlider(sliderRect, ref minValue, ref maxValue, minMaxAttribute.min, minMaxAttribute.max);
            }
            
            minValue = Mathf.Round(minValue * 100) / 100;
            maxValue = Mathf.Round(maxValue * 100) / 100;
        }
    }
}