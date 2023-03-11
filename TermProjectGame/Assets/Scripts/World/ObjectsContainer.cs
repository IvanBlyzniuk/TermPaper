using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        [SerializeField]
        private Image blackHudOverlay;
        public PlayerController Player => player;
        public List<Room> Rooms => rooms;
        public Image BlackHudOverlay => blackHudOverlay;
    }
}

