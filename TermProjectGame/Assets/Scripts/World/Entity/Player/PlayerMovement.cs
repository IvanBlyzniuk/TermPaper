using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private int stairsCollisionsCount = 0;
        private List<Collider2D> ignoredPlatforms = new List<Collider2D>();
        private Vector2 changeVelocity = Vector2.zero;

        [SerializeField]
        private PlayerMovementParamsSO movementParams;
        [SerializeField]
        private Rigidbody2D rigidBody;
        [SerializeField]
        private BoxCollider2D playerCollider;

        public void Move(float speedMultiplier)
        {
            Vector2 target;
            RaycastHit2D groundCheckHit = GroundCheck();
            if (speedMultiplier != 0)
            {
                target = new Vector2(movementParams.moveSpeed * speedMultiplier, rigidBody.velocity.y);
                rigidBody.sharedMaterial = movementParams.noFrictionMaterial;
                if (stairsCollisionsCount > 0  && groundCheckHit && groundCheckHit.collider.gameObject.layer == LayerMask.NameToLayer("Stairs"))
                {
                    target = Vector2.Perpendicular(-groundCheckHit.normal).normalized * movementParams.moveSpeed * speedMultiplier;
                    Debug.DrawRay(transform.position, target, Color.green);
                    rigidBody.velocity = target;
                }
                else
                {
                    rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, target, ref changeVelocity, movementParams.smoothTime);
                }
                if (speedMultiplier < 0)
                    gameObject.transform.localScale = new Vector3(-1,1,1);
                else
                    gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                rigidBody.sharedMaterial = movementParams.normalFrictionMaterial;
                if (!groundCheckHit)
                {
                    target = new Vector2(movementParams.moveSpeed * speedMultiplier, rigidBody.velocity.y);
                }
                else if (groundCheckHit.collider.gameObject.layer == LayerMask.NameToLayer("Stairs"))
                {
                    target = new Vector2(0, 0);
                }
                else
                    target = rigidBody.velocity;
                rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, target, ref changeVelocity, movementParams.smoothTime);
            }
            //Debug.Log(rigidBody.velocity.magnitude);
        }

        public void Jump()
        {
            if(GroundCheck())
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, movementParams.jumpSpeed);
            }
                
        }

        public void JumpDown()
        {
            RaycastHit2D raycastHit = GroundCheck();
            if (!raycastHit)
                return;
            GameObject platform = raycastHit.collider.gameObject;
            if (platform.layer != LayerMask.NameToLayer("Platforms"))
                return;
            Physics2D.IgnoreCollision(playerCollider, raycastHit.collider);
            ignoredPlatforms.Add(raycastHit.collider);
        }

        private RaycastHit2D GroundCheck()
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y - 0.45f * playerCollider.size.y);
            Vector2 size = new Vector2(playerCollider.size.x, 0.1f * playerCollider.size.y);
            return Physics2D.BoxCast(pos, size, 0, Vector2.down, movementParams.maxGroundCheckDistance, movementParams.jumpMask);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Stairs") && collision.enabled)
            {
                stairsCollisionsCount++;
            }
            if (ignoredPlatforms.Count > 0)
            {
                foreach (var platform in ignoredPlatforms)
                {
                    Physics2D.IgnoreCollision(playerCollider, platform, false);
                }
                ignoredPlatforms.Clear();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Stairs") && collision.enabled)
            {
                stairsCollisionsCount--;
            }
        }
    }
}

