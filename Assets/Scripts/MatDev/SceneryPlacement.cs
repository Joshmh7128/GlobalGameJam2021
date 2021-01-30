using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryPlacement : MonoBehaviour
{
    public GameObject terrain;
    public GameObject[] prefabs;
    public int objectsCount;
    public float updateTimeSeconds;

    private List<GameObject> scenery = new List<GameObject>();
    private float lastUpdate;
    
    void Start()
    {
        if (terrain == null) {
            terrain = transform.gameObject;
        }
        PlaceObjects();
        lastUpdate = Time.time;
    }

    void Update()
    {
        if (Time.time - lastUpdate >= updateTimeSeconds) {
            foreach (GameObject sceneryObject in scenery) {
                Destroy(sceneryObject);
            }
            scenery.Clear();
            PlaceObjects();
            lastUpdate = Time.time;
        }
    }

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
                scenery.Add(Instantiate(prefab, hit.point, Quaternion.identity, transform));
            }
        }
    }
}
