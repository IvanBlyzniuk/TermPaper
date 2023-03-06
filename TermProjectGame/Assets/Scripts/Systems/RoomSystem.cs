using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Player;
using World.Level.Room;

namespace Systems
{
    public class RoomSystem : MonoBehaviour, IRoomSystem
    {
        private CloneSystem cloneSystem;
        private Room currentRoom;
        private PlayerController player;
        public void Init(CloneSystem cloneSystem, List<Room> rooms, PlayerController player)
        {
            this.cloneSystem = cloneSystem;
            this.player = player;
            foreach (Room room in rooms)
            {
                room.Init(this);
            }
        }

        public void ResetRoom()
        {
            currentRoom.ResetObjects();
        }

        public void NotifyRoomChanged(Room currentRoom)
        {
            this.currentRoom = currentRoom;
            player.InitialPosition = currentRoom.CheckPoint;
            cloneSystem.ChangeCheckpoint(currentRoom.CheckPoint);
        }
    }
}
