using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Player;

namespace Systems
{
    public class InputSystem : MonoBehaviour
    {
        private CloneSystem cloneSystem;
        private PlayerController player;
        private bool jumpPressed;
        private bool interactPressed;
        private bool resetPressed;
        public void Init(PlayerController player, CloneSystem cloneSystem)
        {
            this.player = player;
            this.cloneSystem = cloneSystem;
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
        }

        private void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput > 0)
            {
                player.Movement.Move(1);
                cloneSystem.Move(1);
            }
            else if(horizontalInput < 0)
            {
                player.Movement.Move(-1);
                cloneSystem.Move(-1);
            }
            else
            {
                player.Movement.Move(0);
                cloneSystem.Move(0);
            }
                
            if (jumpPressed)
            {
                if(Input.GetAxis("Vertical") >= 0)
                {
                    player.Movement.Jump();
                    cloneSystem.Jump();
                }
                else
                {
                    player.Movement.JumpDown();
                    cloneSystem.JumpDown();
                }
                jumpPressed = false;
            }
            if (resetPressed)
            {
                cloneSystem.ResetClones();
                player.ResetPosition();
                resetPressed = false;
            }
            if (interactPressed)
            {
                //TODO interact
                interactPressed = false;
            }
        }
    }
}

