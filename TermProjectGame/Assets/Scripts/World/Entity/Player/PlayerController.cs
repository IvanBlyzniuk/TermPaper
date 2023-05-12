using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Animator animator;
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
            animator = GetComponent<Animator>();
            interactor.PlayerAnimator = animator;
        }

        public void ResetPosition()
        {
            if(InitialPosition == null)
            {
                Debug.Log(gameObject.name);
                return;
            }
            interactor.TryDropObject();
            transform.position = InitialPosition.position;
        }

        public void StartTeleport()
        {
            audioSource.PlayOneShot(timetravelSound);
            animator.SetBool("IsTeleporting", true);
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

        public void EndTeleport()
        {
            animator.SetBool("IsTeleporting", false);
        }

        public void Jump()
        {
            movement.Jump();
        }

        public void JumpDown()
        {
            movement.JumpDown();
        }

        public void StartInteraction()
        {
            animator.SetBool("IsInteracting", true);
            animator.SetBool("InteractionActivating", false);
        }
    }
}

