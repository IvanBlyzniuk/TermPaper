using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using World.Entity.Player;
using World.HUD;
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
        [SerializeField]
        private PauseHandler pauseScreen;
        [SerializeField]
        private TextMeshProUGUI cloneCountText;
        public PlayerController Player => player;
        public List<Room> Rooms => rooms;
        public Image BlackHudOverlay => blackHudOverlay;
        public PauseHandler PauseScreen => pauseScreen;
        public TextMeshProUGUI CloneCountText => cloneCountText;
    }
}

