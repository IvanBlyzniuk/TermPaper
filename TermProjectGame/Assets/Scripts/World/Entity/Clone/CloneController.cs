using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Player;
using Utility;

namespace World.Entity.Clone
{
    public class CloneController : MonoBehaviour
    {
        [SerializeField]
        private PlayerController baseController;
        private byte[] inputs;
        private int frameNum;
        
        public void Init(byte[] inputs, Transform currentCheckpoint)
        {
            this.inputs = inputs;
            frameNum = 0;
            baseController.InitialPosition = currentCheckpoint;
        }

        private void FixedUpdate()
        {
            if(frameNum >= inputs.Length)
            {
                baseController.Move(0);
                return;
            }
            byte fullInput = inputs[frameNum];
            if(ContainsInput(fullInput, InputConsts.MoveRightByte))
                baseController.Move(1);
            else if (ContainsInput(fullInput, InputConsts.MoveLeftByte))
                baseController.Move(-1);
            else
                baseController.Move(0);

            if(ContainsInput(fullInput, InputConsts.JumpByte))
                baseController.Jump();

            if(ContainsInput(fullInput, InputConsts.JumpDownByte))
                baseController.JumpDown();

            if(ContainsInput(fullInput,InputConsts.InterractByte))
                baseController.Interactor.Interract();

            frameNum++;
        }

        private bool ContainsInput(byte fullInput, byte inputToCheck)
        {
            int res = fullInput & inputToCheck;
            return (res != 0);
        }

        public void ResetPosition()
        {
            baseController.ResetPosition();
            frameNum = 0;
        }

        public void DropItem()
        {
            baseController.Interactor.TryDropObject();
        }
    }
}
