using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndicator, cellIndicator;
    [SerializeField]
    private InputManager InputManager;
    [SerializeField]
    private Grid grid;




    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePosition = InputManager.GetSelectedMapPosition();
        // where is highlighted on the grid
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        mouseIndicator.transform.position = mousePosition;
        //matched that grid to the cell
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
