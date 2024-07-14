using System;
using UnityEngine;

namespace RequiredField.Runtime.Scripts
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RequiredFieldAttribute : PropertyAttribute
    {
        public readonly string message;

        public RequiredFieldAttribute(string message = "This field is required!")
        {
            this.message = message;
        }
    }
}