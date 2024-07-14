using System;
using UnityEngine;

namespace InspectorTooltip.Runtime.Scripts
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TooltipAttribute : PropertyAttribute
    {
        public readonly string tooltip;

        public TooltipAttribute(string tooltip)
        {
            this.tooltip = tooltip;
        }
    }
}