using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using World.Entity.Clone;

namespace Systems
{
    public class CloneSystem : MonoBehaviour, ICloneSystem
    {
        [SerializeField]
        private Transform currentCheckpoint; //TODO remove later

        [SerializeField]
        private GameObject clonePrefab;

        private List<CloneController> clones;
        private List<byte> currentAttemptInputs;
        private byte currentFrameInputs;

        public void Init()
        {
            currentAttemptInputs = new List<byte>();
            clones = new List<CloneController>();
            currentFrameInputs = 0;
        }

        public void JumpDown()
        {
            currentFrameInputs |= InputConsts.JumpDownByte;
        }

        public void Jump()
        {
            currentFrameInputs |= InputConsts.JumpByte;
        }

        public void Move(float speedMultiplier)
        {
            if (speedMultiplier > 0)
                currentFrameInputs |= InputConsts.MoveRightByte;
            else if (speedMultiplier < 0)
                currentFrameInputs |= InputConsts.MoveLeftByte;
        }

        public void Interract()
        {
            currentFrameInputs |= InputConsts.InterractByte;
        }

        public void ResetClones()
        {
            CloneController currentClone = Instantiate(clonePrefab).GetComponent<CloneController>();
            currentClone.Init(currentAttemptInputs, currentCheckpoint);
            clones.Add(currentClone);
            foreach (CloneController clone in clones)
            {
                clone.gameObject.SetActive(true);
                clone.ResetPosition();
            }
            currentAttemptInputs = new List<byte>();
        }

        public void RemoveClones()
        {
            if (clones == null)
                return;
            foreach (CloneController clone in clones)
            {
                GameObject.Destroy(clone.gameObject);
            }
            clones.Clear();
        }

        public void ResetInputs()
        {
            currentAttemptInputs.Clear();
            currentFrameInputs = 0;
        }

        public void ChangeCheckpoint(Transform newCheckpoint)
        {
            currentCheckpoint = newCheckpoint;
            RemoveClones();
        }

        public void KillClone(CloneController clone)
        {
            clone.gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            currentAttemptInputs.Add(currentFrameInputs);
            currentFrameInputs = 0;
        }
    }
}
