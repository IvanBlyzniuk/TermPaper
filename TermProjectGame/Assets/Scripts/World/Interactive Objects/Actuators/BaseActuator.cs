using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.InteractiveObjects.Activables;

namespace World.InteractiveObjects.Actuators
{
    public class BaseActuator : MonoBehaviour
    {
        [SerializeField]
        private List<BaseActivable> activables;

        public void Activate()
        {
           foreach (var activable in activables)
           {
                activable.Activate();
           }
        }

        public void Deactivate()
        {
            foreach (var activable in activables)
            {
                activable.Deactivate();
            }
        }
    }
}
