using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    [CreateAssetMenu(fileName = "PlayerMovementParamsSO", menuName = "Scriptable Objects/Player/ Player Movement Params")]
    public class PlayerMovementParamsSO : ScriptableObject
    {
        public float smoothTime;
        public float jumpSpeed;
        public float moveSpeed;
        public float maxGroundCheckDistance;
    }
}

