using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World;
using Systems;
using Cinemachine;

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
    [SerializeField]
    private HudSystem hudSystem;

    private void Awake()
    {
        inputSystem.Init(objectsContainer.Player,cloneSystem,roomSystem);
        roomSystem.Init(cloneSystem, inputSystem, hudSystem,objectsContainer.Rooms, objectsContainer.Player);
        cloneSystem.Init();
        hudSystem.Init(objectsContainer.BlackHudOverlay);
    }
}
