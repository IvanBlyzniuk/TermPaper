using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Player;

namespace Systems
{
    public class InputSystem : MonoBehaviour
    {
        private PlayerController player;
        private bool jumpPressed;
        public void Init(PlayerController player)
        {
            this.player = player;
            jumpPressed = false;
        }

        private void Update()
        {
            if(Input.GetButtonDown("Jump"))
                jumpPressed = true;
        }

        private void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput > 0)
            {
                player.Movement.Move(1,player.Speed);
            }
            else if(horizontalInput < 0)
            {
                player.Movement.Move(-1, player.Speed);
            }
            else
                player.Movement.Move(0, player.Speed);
            if(jumpPressed)
            {
                player.Movement.Jump();
                jumpPressed = false;
            }
        }
    }
}

