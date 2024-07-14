using System;
using UnityEngine;

namespace InspectorButton.Runtime.Scripts
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : PropertyAttribute
    {
        public string buttonName;

        public ButtonAttribute(string buttonName = "")
        {
            this.buttonName = buttonName;
        }
    }
}