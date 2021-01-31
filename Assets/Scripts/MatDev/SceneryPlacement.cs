using System.Collections.Generic;
using UnityEngine;

public class SceneryPlacement : MonoBehaviour
{
    public GameObject terrain;
    public GameObject[] prefabs;
    public int objectsCount;
    Bounds boundingBox;

    private List<GameObject> scenery = new List<GameObject>();
    
    void Start()
    {
        if (terrain == null) {
            terrain = transform.gameObject;
        }

        // Get bounding box of the object hierarchy
        boundingBox = new Bounds (terrain.transform.position, Vector3.zero);
        foreach (Renderer child in terrain.GetComponentsInChildren<Renderer>())
        {
            boundingBox.Encapsulate(child.bounds);
        }

        // PlaceObjects();
    }

    void Update()
    {
        // Create scenery objects
        if (scenery.Count < objectsCount)
        {
            // Get random point above bounding box
            Vector3 coordinates = new Vector3(
                Random.Range(boundingBox.min.x, boundingBox.max.x),
                boundingBox.max.y + 1,
                Random.Range(boundingBox.min.z, boundingBox.max.z));
            // Check if point intersects with terrain
            RaycastHit hit;
            if (Physics.Raycast(coordinates, Vector3.down, out hit))
            {
                // Make sure that the collider is in fact taking scenery
                if (hit.collider.CompareTag("SceneryPlaceable"))
                {
                    // Get random prefab
                    GameObject prefab = prefabs[Random.Range(0, prefabs.Length - 1)];
                    // Instantiate prefab
                    scenery.Add(Instantiate(prefab, hit.point, Quaternion.Euler(0, Random.Range(0, 359), 0), transform));
                }
            }
        }
    }


    /*
    void PlaceObjects()
    {
        // Get bounding box of the object hierarchy
        Bounds boundingBox = new Bounds(terrain.transform.position, Vector3.zero);
        foreach (Renderer child in terrain.GetComponentsInChildren<Renderer>()) {
            boundingBox.Encapsulate(child.bounds);
        }

        // Create scenery objects
        while (scenery.Count < objectsCount) {
            // Get random point above bounding box
            Vector3 coordinates = new Vector3(
                Random.Range(boundingBox.min.x, boundingBox.max.x),
                boundingBox.max.y + 1,
                Random.Range(boundingBox.min.z, boundingBox.max.z));
            // Check if point intersects with terrain
            RaycastHit hit;
            if (Physics.Raycast(coordinates, Vector3.down, out hit)) {
                // Get random prefab
                GameObject prefab = prefabs[Random.Range(0, prefabs.Length - 1)];
                // Instantiate prefab
                scenery.Add(Instantiate(prefab, hit.point, Quaternion.Euler(0, Random.Range(0, 359), 0), transform));
            }
        }
    }*/
}
