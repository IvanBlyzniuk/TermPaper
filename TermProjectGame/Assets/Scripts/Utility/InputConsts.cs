using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class InputConsts
    {
        public const byte MoveRightByte = 1;
        public const byte MoveLeftByte = 1 << 1;
        public const byte JumpByte = 1 << 2;
        public const byte JumpDownByte = 1 << 3;
        public const byte InterractByte = 1 << 4;
    }
}
