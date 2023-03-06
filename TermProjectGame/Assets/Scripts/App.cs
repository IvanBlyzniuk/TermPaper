using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World;
using Systems;

public class App : MonoBehaviour
{
    [SerializeField]
    private ObjectsContainer objectsContainer;
    [SerializeField]
    private InputSystem inputSystem;
    [SerializeField]
    private CloneSystem cloneSystem;
    [SerializeField]
    private RoomSystem roomSystem;

    private void Awake()
    {
        inputSystem.Init(objectsContainer.Player,cloneSystem,roomSystem);
        roomSystem.Init(cloneSystem,objectsContainer.Rooms, objectsContainer.Player);
        cloneSystem.Init();
    }
}
