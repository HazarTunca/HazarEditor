using UnityEditor;
using UnityEngine;
using TooltipAttribute = InspectorTooltip.Runtime.Scripts.TooltipAttribute;

namespace InspectorTooltip.Editor.Scripts
{
    [CustomPropertyDrawer(typeof(TooltipAttribute))]
    public class TooltipDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            TooltipAttribute tooltipAttribute = (TooltipAttribute)attribute;
            GUIContent tooltipLabel = new GUIContent(label.text, tooltipAttribute.tooltip);
            EditorGUI.PropertyField(position, property, tooltipLabel);
        }
    }
}