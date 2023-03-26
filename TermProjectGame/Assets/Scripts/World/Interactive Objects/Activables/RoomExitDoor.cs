using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Clone;
using World.Level.Room;

namespace World.InteractiveObjects.Activables
{
    public class RoomExitDoor : BaseActivable
    {
        private Room room;
        [SerializeField]
        private bool isOpen;
        [SerializeField]
        private Animator animator;

        public void Init(Room room)
        {
            this.room = room;
            animator.SetBool("isOpen", isOpen);
        }

        protected override void OnActivate()
        {
            isOpen = true;
            animator.SetBool("isOpen", true);
        }

        protected override void OnDeactivate()
        {
            isOpen = false;
            animator.SetBool("isOpen", false);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (!isOpen)
                return;
            if(collision.gameObject.GetComponent<CloneController>() == null)
            {
                room.ChangeRoom();
            }
        }

    }
}
