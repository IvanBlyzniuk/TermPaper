using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    public class PlayerController : MonoBehaviour
    {
        private AudioSource audioSource;
        [SerializeField]
        private PlayerMovement movement;
        [SerializeField]
        private PlayerInteractor interactor;
        [SerializeField]
        private Transform initialPosition;
        [SerializeField]
        private AudioClip timetravelSound;
        
        public PlayerInteractor Interactor => interactor;
        public Transform InitialPosition { get => initialPosition; set => initialPosition = value; }

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void ResetPosition()
        {
            if(InitialPosition == null)
            {
                Debug.Log(gameObject.name);
                return;
            }
            audioSource.PlayOneShot(timetravelSound);
            interactor.TryDropObject();
            transform.position = InitialPosition.position;
        }

        public void Move(float speedMultiplier)
        {
            if (movement == null)
                return;
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

