using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> placedGameObjects = new();
    [SerializeField]
    private SoundFeedback soundFeedback;

    public int PlaceObject(GameObject prefab, Vector3 position)
    {
        //create game object
        GameObject newObject = Instantiate(prefab);
        //matched that grid to the cell
        newObject.transform.position = position;
        placedGameObjects.Add(newObject);
        return placedGameObjects.Count - 1;
    }

    internal void RemoveObjectAt(int gameObjectIndex)
    {
        if(placedGameObjects.Count <= gameObjectIndex || placedGameObjects[gameObjectIndex] == null)
        {
            return;
        }
        Destroy(placedGameObjects[gameObjectIndex]);
        placedGameObjects[gameObjectIndex] = null;
        soundFeedback.PlaySound(SoundFeedback.SoundType.Remove);
    }
}
