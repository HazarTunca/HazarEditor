using System;
using UnityEngine;

namespace InspectorReadonly.Runtime.Scripts
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InspectorReadonlyAttribute : PropertyAttribute
    {
        
    }
}