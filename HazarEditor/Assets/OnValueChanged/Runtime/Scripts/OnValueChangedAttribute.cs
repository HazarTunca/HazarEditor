using System;
using UnityEngine;

namespace OnValueChanged.Runtime.Scripts
{
    [AttributeUsage(AttributeTargets.Field)]
    public class OnValueChangedAttribute : PropertyAttribute
    {
        public string methodName;

        public OnValueChangedAttribute(string methodName)
        {
            this.methodName = methodName;
        }
    }
}