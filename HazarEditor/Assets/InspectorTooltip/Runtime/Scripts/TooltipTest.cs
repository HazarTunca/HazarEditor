using UnityEngine;

namespace InspectorTooltip.Runtime.Scripts
{
    public class TooltipTest : MonoBehaviour
    {
        [Tooltip("This is a test tooltip for a float.")]
        public float floatTest;
        
        [Tooltip("This is a test tooltip for an int.")]
        public int intTest;
    }
}