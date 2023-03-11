using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;
using World.Entity.Clone;
using World.InteractiveObjects;
using World.InteractiveObjects.Activables;

namespace World.Level.Room
{
    public class Room : MonoBehaviour
    {
        private IRoomSystem roomSystem;
        private ICloneSystem cloneSystem;

        [SerializeField]
        private Transform checkPoint;
        [SerializeField]
        private List<ResettableObject> resettableObjects;
        [SerializeField]
        private RoomExitDoor exitDoor;
        [SerializeField]
        private Room nextRoom;

        public Transform CheckPoint { get => checkPoint; }

        public void Init(IRoomSystem roomSystem, ICloneSystem cloneSystem)
        {
            this.roomSystem = roomSystem;
            this.cloneSystem = cloneSystem;
            exitDoor.Init(this);
        }

        public void ResetObjects()
        {
            foreach(var obj in resettableObjects)
            {
                obj.ResetObject();
            }
        }

        public void ChangeRoom()
        {
            roomSystem.NotifyRoomChanged(nextRoom);
        }

        //public void OnCollisionEnter2D(Collision2D collision)
        //{
        //    CloneController clone = collision.gameObject.GetComponent<CloneController>();
        //    if (clone != null)
        //    {
        //        //cloneSystem.KillClone(clone);
        //        return;
        //    }
        //    //TODO:close door
        //    roomSystem.NotifyRoomChanged(this);
        //}
    }
}
