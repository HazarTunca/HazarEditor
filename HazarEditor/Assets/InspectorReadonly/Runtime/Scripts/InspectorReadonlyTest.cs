using UnityEngine;

namespace InspectorReadonly.Runtime.Scripts
{
    public class InspectorReadonlyTest : MonoBehaviour
    {
        [InspectorReadonly] public int readonlyField = 12;
        public int normalField = 34;
    }
}