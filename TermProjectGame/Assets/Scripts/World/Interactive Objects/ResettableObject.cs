using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.InteractiveObjects
{
    public class ResettableObject : MonoBehaviour
    {
        private Vector2 intialPosition;
        private Quaternion initialRotation;
        private void Awake()
        {
            intialPosition = transform.position;
            initialRotation = transform.rotation;
        }

        public void ResetObject()
        {
            transform.position = intialPosition;
            transform.rotation = initialRotation;
        }
    }
}
