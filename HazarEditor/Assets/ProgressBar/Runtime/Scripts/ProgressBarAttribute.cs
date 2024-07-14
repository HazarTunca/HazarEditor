using System;
using UnityEngine;

namespace ProgressBar.Runtime.Scripts
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ProgressBarAttribute : PropertyAttribute
    {
        public readonly float min;
        public readonly float max;

        public ProgressBarAttribute(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }
}