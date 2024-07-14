using System.Reflection;
using OnValueChanged.Runtime.Scripts;
using UnityEditor;
using UnityEngine;

namespace OnValueChanged.Editor.Scripts
{
    [CustomPropertyDrawer(typeof(OnValueChangedAttribute))]
    public class OnValueChangedDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, property, label, true);

            if (EditorGUI.EndChangeCheck())
            {
                if (attribute is not OnValueChangedAttribute attr) return;
                
                object target = property.serializedObject.targetObject;
                MethodInfo method = target.GetType().GetMethod(attr.methodName, 
                    BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                if (method != null)
                {
                    property.serializedObject.ApplyModifiedProperties();

                    switch (method.GetParameters().Length)
                    {
                        case 0:
                            method.Invoke(target, null);
                            break;
                        case 1:
                            method.Invoke(target, new object[] { fieldInfo.GetValue(target) });
                            break;
                        default:
                            Debug.LogWarning($"Method {attr.methodName} should have either no parameters or one parameter matching the field type.");
                            break;
                    }
                }
                else
                {
                    Debug.LogWarning($"Method {attr.methodName} not found.");
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}