using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Player;

namespace Systems
{
    public class InputSystem : MonoBehaviour
    {
        private CloneSystem cloneSystem;
        private RoomSystem roomSystem;
        private PlayerController player;
        private bool jumpPressed;
        private bool interactPressed;
        private bool resetPressed;
        private bool removeClonesPressed;
        public void Init(PlayerController player, CloneSystem cloneSystem, RoomSystem roomSystem)
        {
            this.player = player;
            this.cloneSystem = cloneSystem;
            this.roomSystem = roomSystem;
            jumpPressed = false;
        }

        private void Update()
        {
            if(Input.GetButtonDown("Jump"))
                jumpPressed = true;
            if(Input.GetButtonDown("Reset"))
                resetPressed = true;
            if (Input.GetButtonDown("Interract"))
                interactPressed = true;
            if (Input.GetButtonDown("Remove Clones"))
                removeClonesPressed = true;
        }

        private void OnDisable()
        {
            player.Move(0);
        }

        private void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput > 0)
            {
                player.Move(1);
                cloneSystem.Move(1);
            }
            else if(horizontalInput < 0)
            {
                player.Move(-1);
                cloneSystem.Move(-1);
            }
            else
            {
                player.Move(0);
                cloneSystem.Move(0);
            }
                
            if (jumpPressed)
            {
                if(Input.GetAxis("Vertical") >= 0)
                {
                    player.Jump();
                    cloneSystem.Jump();
                }
                else
                {
                    player.JumpDown();
                    cloneSystem.JumpDown();
                }
                jumpPressed = false;
            }
            if (resetPressed)
            {
                cloneSystem.ResetClones();
                player.ResetPosition();
                roomSystem.ResetRoom();
                resetPressed = false;
            }
            if (interactPressed)
            {
                player.Interactor.Interract();
                cloneSystem.Interract();
                interactPressed = false;
            }
            if(removeClonesPressed)
            {
                cloneSystem.RemoveClones();
                removeClonesPressed = false;

            }
        }
    }
}

