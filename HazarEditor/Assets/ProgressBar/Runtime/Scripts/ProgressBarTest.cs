using UnityEngine;

namespace ProgressBar.Runtime.Scripts
{
    public class ProgressBarTest : MonoBehaviour
    {
        [ProgressBar(0, 100)]
        public float health = 50;
    }
}