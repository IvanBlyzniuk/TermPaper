using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.InteractiveObjects.Actuators
{
    public class PressurePlate : BaseActuator
    {
        private int collisionCount;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Activate();
            collisionCount++;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            collisionCount--;
            if(collisionCount <= 0)
                Deactivate();
        }
    }
}
