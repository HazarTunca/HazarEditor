using UnityEngine;

namespace RequiredField.Runtime.Scripts
{
    public class RequiredFieldTest : MonoBehaviour
    {
        [RequiredField]
        public GameObject testGameObject;
    }
}