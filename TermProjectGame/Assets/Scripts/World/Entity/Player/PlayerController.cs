using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private PlayerMovement movement;

        public float Speed => speed;
        public PlayerMovement Movement => movement;
    }
}

