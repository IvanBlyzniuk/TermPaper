using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.InteractiveObjects.Activables
{
    public abstract class BaseActivable : MonoBehaviour
    {
        private int inputCount = 0;
        private int activeCount = 0;
        protected abstract void ActivateBehaviour();
        protected abstract void DeactivateBehaviour();

        public void AddActuator()
        {
            inputCount++;
        }

        public void Activate()
        {
            activeCount++;
            if (inputCount == activeCount)
                ActivateBehaviour();
        }

        public void Deactivate()
        {
            if(inputCount == activeCount)
                DeactivateBehaviour();
            activeCount--;
        }
    }
}

