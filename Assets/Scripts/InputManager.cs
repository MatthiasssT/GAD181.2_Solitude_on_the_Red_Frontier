using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Camera sceneCamera;
    
    private Vector3 lastPosition;

    [SerializeField]
    //to decide which plane takes place in our input detection
    private LayerMask placementLayerMask;

    
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
