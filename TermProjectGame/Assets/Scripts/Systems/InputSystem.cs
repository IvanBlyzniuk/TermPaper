using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Player;

namespace Systems
{
    public class InputSystem : MonoBehaviour
    {
        private PlayerController player;
        public void Init(PlayerController player)
        {
            this.player = player;
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
        }
    }
}

