using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.InteractiveObjects;

namespace World.Level.Room
{
    public class Room : MonoBehaviour
    {
        private IRoomSystem roomSystem;

        [SerializeField]
        private Transform checkPoint;
        [SerializeField]
        private List<ResettableObject> resettableObjects;

        public Transform CheckPoint { get => checkPoint; }

        public void Init(IRoomSystem roomSystem)
        {
            this.roomSystem = roomSystem;
        }

        public void ResetObjects()
        {
            foreach(var obj in resettableObjects)
            {
                obj.ResetObject();
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            //TODO:close door
            roomSystem.NotifyRoomChanged(this);
        }
    }
}
