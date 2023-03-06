using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Player;
using World.Level.Room;

namespace World
{
    public class ObjectsContainer : MonoBehaviour
    {
        [SerializeField]
        private PlayerController player;
        [SerializeField]
        private List<Room> rooms;
        public PlayerController Player => player;
        public List<Room> Rooms => rooms;
    }
}

