using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Player;

namespace World
{
    public class ObjectsContainer : MonoBehaviour
    {
        [SerializeField]
        private PlayerController player;

        public PlayerController Player => player;
    }
}

