using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Vector2 changeVelocity = Vector2.zero;
        [SerializeField]
        private Rigidbody2D rigidBody;
        [SerializeField]
        private float smoothTime;

        public void Move(float speedMultiplier, float speed)
        {
            Vector2 target = new Vector2(speed * speedMultiplier, rigidBody.velocity.y);

            rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, target, ref changeVelocity, smoothTime);
        }
    }
}

