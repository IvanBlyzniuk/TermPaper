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

    private void Awake()
    {
        inputSystem.Init(objectsContainer.Player);
    }
}
