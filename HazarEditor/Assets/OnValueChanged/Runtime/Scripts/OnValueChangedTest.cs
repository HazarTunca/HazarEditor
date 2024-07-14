using UnityEngine;

namespace OnValueChanged.Runtime.Scripts
{
    public class OnValueChangedTest : MonoBehaviour
    {
        [OnValueChanged("OnValueChanged")]
        public int value;

        private void OnValueChanged()
        {
            Debug.Log("Value changed to " + value);
        }
    }
}