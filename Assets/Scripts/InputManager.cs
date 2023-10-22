using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Camera sceneCamera;
    
    private Vector3 lastPosition;

    [SerializeField]
    //to decide which plane takes place in our input detection
    private LayerMask placementLayerMask;

    public event Action OnClicked, OnExit;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnClicked?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnExit?.Invoke();
        }
    }

    public bool IsPointerOverUi()
        => EventSystem.current.IsPointerOverGameObject();

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        // to only select objects in render
        mousePos.z = sceneCamera.nearClipPlane;
        // ray cast from scene camera to mouse position
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        //detect selected position
        if (Physics.Raycast(ray, out hit, 100, placementLayerMask))
        {
            lastPosition = hit.point;
        }
        return lastPosition;
    }
    
}
