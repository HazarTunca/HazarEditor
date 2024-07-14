using System;
using UnityEngine;

namespace InspectorButton.Runtime.Scripts
{
    public class ButtonTest : MonoBehaviour
    {
        public int a;
        
        [Button]
        private void Test()
        {
            a++;
        }
    }
}