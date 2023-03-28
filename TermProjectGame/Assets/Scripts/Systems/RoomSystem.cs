using Cinemachine;
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
        private InputSystem inputSystem;
        private HudSystem hudSystem;
        private Room currentRoom;
        private PlayerController player;
        private CinemachineVirtualCamera mainCamera;
        [SerializeField]
        private float fadeoutTime;

        public Room CurrentRoom
        {
            get { return currentRoom; }
            set
            {
                currentRoom = value;
                player.InitialPosition = currentRoom.CheckPoint;
                player.transform.position = currentRoom.CheckPoint.position;
                cloneSystem.ChangeCheckpoint(currentRoom.CheckPoint);
            }
        }

        public void Init(CloneSystem cloneSystem, InputSystem inputSystem, HudSystem hudSystem, List<Room> rooms, PlayerController player, CinemachineVirtualCamera mainCamera)
        {
            this.cloneSystem = cloneSystem;
            this.inputSystem = inputSystem;
            this.hudSystem = hudSystem;
            this.player = player;
            this.mainCamera = mainCamera;
            foreach (Room room in rooms)
            {
                room.Init(this, cloneSystem);
            }
            CurrentRoom = rooms[0]; //Maybe add firstRoom field for convenience
        }

        public void ResetRoom()
        {
            if(currentRoom != null)
                currentRoom.ResetObjects();
        }

        private IEnumerator ChangeRoom(Room nextRoom)
        {
            inputSystem.gameObject.SetActive(false);
            float timePassed = 0;
            while (timePassed < fadeoutTime)
            {
                timePassed += Time.deltaTime;
                hudSystem.BlackOverlayAlpha = timePassed / fadeoutTime;
                yield return new WaitForSeconds(Time.deltaTime);
            }
            CurrentRoom = nextRoom;
            timePassed = 0;
            yield return new WaitForSeconds(0.5f);
            while (timePassed < fadeoutTime)
            {
                timePassed += Time.deltaTime;
                hudSystem.BlackOverlayAlpha = 1.0f - timePassed / fadeoutTime;
                yield return new WaitForSeconds(Time.deltaTime);
            }
            inputSystem.gameObject.SetActive(true);
            cloneSystem.RemoveClones();
            cloneSystem.ResetInputs();
        }

        public void NotifyRoomChanged(Room nextRoom)
        {
            if(nextRoom == null)
            {
                Debug.Log("Starting next level");
                return;
            }
            StartCoroutine(ChangeRoom(nextRoom));
            
        }
    }
}
