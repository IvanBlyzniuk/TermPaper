using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.InteractiveObjects.Activables
{
    public abstract class BaseActivable : MonoBehaviour
    {
        public abstract void Activate();
        public abstract void Deactivate();
    }
}

