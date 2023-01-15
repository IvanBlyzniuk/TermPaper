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
        private Transform initialPosition;
        public PlayerMovement Movement => movement;
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
    }
}

