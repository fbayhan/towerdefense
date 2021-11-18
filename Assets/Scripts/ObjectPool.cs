using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectPreFabs;

    private List<GameObject> pooledObjects = new List<GameObject>();

    public GameObject GetObject(string type)
    {
        foreach (GameObject go in pooledObjects)
        {
            if (go.name == type && !go.activeInHierarchy)
            {
                go.SetActive(true);
                return go;
            }
        }

        for (int i = 0; i < objectPreFabs.Length; i++)
        {
            if (objectPreFabs[i].name == type)
            {
                GameObject newObject = Instantiate(objectPreFabs[i]);

                pooledObjects.Add(newObject);
                newObject.name = type;
                return newObject;
            }

        }
        return null;
    }

    public void ReleaseObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
