using System.Reflection;
using InspectorButton.Runtime.Scripts;
using UnityEditor;
using UnityEngine;

namespace InspectorButton.Editor.Scripts
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class ButtonAttributeEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            MonoBehaviour targetMB = (MonoBehaviour)target;
            MethodInfo[] methods = targetMB.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (MethodInfo method in methods)
            {
                ButtonAttribute buttonAttr = method.GetCustomAttribute<ButtonAttribute>();
                if (buttonAttr == null) continue;
                
                string buttonName = string.IsNullOrEmpty(buttonAttr.buttonName) ? method.Name : buttonAttr.buttonName;
                if (GUILayout.Button(buttonName))
                {
                    method.Invoke(targetMB, null);
                }
            }
        }
    }
}