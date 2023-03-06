using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Level.Room;

public interface IRoomSystem
{
    void NotifyRoomChanged(Room currentRoom);
}
