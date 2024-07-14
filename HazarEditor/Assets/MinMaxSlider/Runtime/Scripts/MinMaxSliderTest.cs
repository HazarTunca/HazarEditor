using UnityEngine;

namespace MinMax.Runtime.Scripts
{
    public class MinMaxSliderTest : MonoBehaviour
    {
        [MinMaxSlider(5, 50)]
        public float floatTest;
        
        [MinMaxSlider(5, 50)]
        public int intTest;
    }
}