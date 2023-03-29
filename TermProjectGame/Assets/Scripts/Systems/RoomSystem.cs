using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        private List<Room> rooms;
        [SerializeField]
        private string nextLevelName;
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
                cloneSystem.MaxClonesCount = currentRoom.MaxClonesCount;
            }
        }

        public void Init(CloneSystem cloneSystem, InputSystem inputSystem, HudSystem hudSystem, List<Room> rooms, PlayerController player)
        {
            this.cloneSystem = cloneSystem;
            this.inputSystem = inputSystem;
            this.hudSystem = hudSystem;
            this.player = player;
            this.rooms = rooms;
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
                StartCoroutine(ChangeScene());
                return;
            }
            Debug.Log($"Room #{rooms.IndexOf(nextRoom)}");
            PlayerPrefs.SetInt("currentRoom", rooms.IndexOf(nextRoom));
            StartCoroutine(ChangeRoom(nextRoom));
        }

        private IEnumerator ChangeScene()
        {
            inputSystem.gameObject.SetActive(false);
            Debug.Log("Starting next level");
            PlayerPrefs.SetString("currentLevel", nextLevelName);
            PlayerPrefs.SetInt("currentRoom", 0);
            float timePassed = 0;
            while (timePassed < fadeoutTime * 2)
            {
                timePassed += Time.deltaTime;
                hudSystem.BlackOverlayAlpha = timePassed / fadeoutTime;
                yield return new WaitForSeconds(Time.deltaTime);
            }
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
