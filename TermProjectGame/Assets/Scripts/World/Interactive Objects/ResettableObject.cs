using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.InteractiveObjects.Activables;

namespace World.InteractiveObjects
{
    public class ResettableObject : MonoBehaviour
    {
        private Vector2 intialPosition;
        private Quaternion initialRotation;
        private BaseActivable[] activableComponents;
        private Rigidbody2D myRigidBody;
        
        
        private void Awake()
        {
            intialPosition = transform.position;
            initialRotation = transform.rotation;
            activableComponents = GetComponents<BaseActivable>();
            myRigidBody = GetComponent<Rigidbody2D>();
        }

        public void ResetObject()
        {
            transform.position = intialPosition;
            transform.rotation = initialRotation;
            foreach (var activableComponent in activableComponents)
            {
                activableComponent.OnReset();
            }
        }
    }
}
