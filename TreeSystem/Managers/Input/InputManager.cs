using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private CameraMainManager _cameraManager;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _cameraManager.SetOrder("CastRayAdd");
        }
        if (Input.GetMouseButtonUp(1))
        {
            _cameraManager.SetOrder("CastRayRemove");
        }
    }
}
