using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovement movement;
        [SerializeField]
        private PlayerInteractor interactor;
        [SerializeField]
        private Transform initialPosition;
        
        public PlayerInteractor Interactor => interactor;
        public Transform InitialPosition { get => initialPosition; set => initialPosition = value; }

        public void ResetPosition()
        {
            if(InitialPosition == null)
            {
                Debug.Log(gameObject.name);
                return;
            }
            transform.position = InitialPosition.position;
        }

        public void Move(float speedMultiplier)
        {
            movement.Move(speedMultiplier);
            if(speedMultiplier > 0 && !movement.FacingRight)
            {
                movement.TurnRight();
                interactor.TurnAround();
            }
            else if(speedMultiplier < 0 && movement.FacingRight)
            {
                movement.TurnLeft();
                interactor.TurnAround();
            }

        }

        public void Jump()
        {
            movement.Jump();
        }

        public void JumpDown()
        {
            movement.JumpDown();
        }
    }
}

