using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Player;

namespace World.InteractiveObjects.Activables
{
    public class MovingPlatform : BaseActivable
    {
        private Vector3 startPosition;
        private Vector3 endPosition;
        private Rigidbody2D myRigidBody;
        private bool isActive = false;

        [SerializeField]
        private float speed;
        [SerializeField]
        private Transform endTransform;

        public void Awake()
        {
            startPosition = transform.position;
            endPosition = endTransform.position;
            myRigidBody = GetComponent<Rigidbody2D>();
        }

        public override void OnReset()
        {
            isActive = false;
            StopAllCoroutines();
            myRigidBody.velocity = Vector3.zero;
        }

        protected override void OnActivate()
        {
            if (isActive)
                return;
            isActive = true;
            StopAllCoroutines();
            Vector3 velocity = (endPosition - startPosition).normalized * speed;
            StartCoroutine(MoveInDirection(velocity, endPosition));
        }

        protected override void OnDeactivate()
        {
            if (!isActive)
                return;
            isActive = false;
            StopAllCoroutines();
            Vector3 velocity = (startPosition - endPosition).normalized * speed;
            StartCoroutine(MoveInDirection(velocity, startPosition));
        }

        private IEnumerator MoveInDirection(Vector3 velocity, Vector3 targetPosition)
        {
            myRigidBody.velocity = velocity;
            float travelTime =  Vector3.Distance(transform.position, targetPosition) / velocity.magnitude;
            yield return new WaitForSeconds(travelTime);
            myRigidBody.velocity = Vector3.zero;
        }
    }
}
