using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using static System.Math;

public class SeagullController : MonoBehaviour
{
    public GameObject seagullPrefab;
    public int initialSpawn;
    public float spawnTime;
    public int maxSpawn;
    public float yDelta;
    public float interestRandomness;
    public float seagullStayTime;
    public float seagullStayTimeHardCap;
    public float seagullSpeed;

    private double t = 0;
    private double spawnProb = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnSeagulls(initialSpawn);
        spawnProb = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        float lambda = 1 / spawnTime;
        if (Exp(-lambda * t) < spawnProb)
        {
            Seagull[] seagulls = GetComponentsInChildren<Seagull>();
            if (seagulls.Length < maxSpawn)
            {
                SpawnSeagulls(1);
            }
            t = 0;
            spawnProb = Random.value;
        }
    }

    void SpawnSeagulls(int n)
    {
        SeagullPOI[] x = FindObjectsOfType<SeagullPOI>();
        List<SeagullPOI> pois = FindObjectsOfType<SeagullPOI>().Where(poi => poi.canSpawn).ToList();
        for (int i = 0; i < n; i++)
        {
            SeagullPOI spawnPoint = pois[Random.Range(0, pois.Count)];
            Vector2 spawnCoordinatesXZ = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.z);
            spawnCoordinatesXZ += Random.insideUnitCircle * spawnPoint.radius;
            Vector3 spawnCoordinates = new Vector3(
                spawnCoordinatesXZ.x,
                Random.Range(transform.position.y - yDelta, transform.position.y + yDelta),
                spawnCoordinatesXZ.y
            );
            Instantiate(seagullPrefab, spawnCoordinates, Quaternion.identity, transform).GetComponent<Seagull>();
        }
    }
}
