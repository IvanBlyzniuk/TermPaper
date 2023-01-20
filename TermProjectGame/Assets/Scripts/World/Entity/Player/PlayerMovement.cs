using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Vector2 changeVelocity = Vector2.zero;
        [SerializeField]
        private PlayerMovementParamsSO movementParams;
        [SerializeField]
        private LayerMask jumpMask;
        [SerializeField]
        private Rigidbody2D rigidBody;
        [SerializeField]
        private BoxCollider2D playerCollider;

        public void Move(float speedMultiplier)
        {
            Vector2 target = new Vector2(movementParams.moveSpeed * speedMultiplier, rigidBody.velocity.y);

            rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, target, ref changeVelocity, movementParams.smoothTime);
        }

        public void Jump()
        {
            if(GoundCheck())
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, movementParams.jumpSpeed);
        }

        private bool GoundCheck()
        {
            return Physics2D.BoxCast(transform.position, playerCollider.size, 0, Vector2.down, movementParams.maxGroundCheckDistance, jumpMask);
        }
    }
}

