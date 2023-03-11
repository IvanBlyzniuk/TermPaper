using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Clone;

namespace Systems
{
    public interface ICloneSystem
    {
        void KillClone(CloneController clone);
    }
}
