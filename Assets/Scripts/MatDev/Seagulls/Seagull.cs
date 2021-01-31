using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using static System.Math;

using CoroutineMethod = System.Collections.IEnumerator;

public class Seagull : MonoBehaviour
{

    private float lastFindPOITime = 0;
    private float lastNewPOITime = 0;
    private float switchProb = 1;
    private float speed;
    private float parentY;
    private float yDelta;
    private float stayTime;
    private float stayTimeHardCap;

    void Start()
    {
        SeagullController controller = GetComponentInParent<SeagullController>();
        speed = controller.seagullSpeed;
        yDelta = controller.yDelta;
        stayTime = controller.seagullStayTime;
        stayTimeHardCap = controller.seagullStayTimeHardCap;
        parentY = controller.transform.position.y;
        StartCoroutine(FlyAround());
    }

    // Update is called once per frame
    void Update()
    {
    }

    CoroutineMethod FlyAround()
    {
        SeagullPOI poi = findPOI();
        lastFindPOITime = Time.time;
        lastNewPOITime = Time.time;
        float lambda = 1 / stayTime;
        while (true)
        {
            float t = Time.time - lastFindPOITime;
            if (Exp(-lambda * t) < switchProb || t >= stayTimeHardCap)
            {
                if (t > stayTimeHardCap)
                {
                    SeagullPOI next = findPOI();
                    if (poi != next)
                    {
                        lastNewPOITime = Time.time;
                    }
                    poi = next;
                }
                else
                {
                    poi = findPOI(poi);
                }
                lastFindPOITime = Time.time;
                switchProb = Random.value;
            }

            Vector3 poiCenter = poi.transform.position;
            Vector2 targetXZ = new Vector2(poiCenter.x, poiCenter.z) + (Random.insideUnitCircle * poi.radius);
            Vector3 target = new Vector3(
                targetXZ.x,
                Random.Range(parentY - yDelta, parentY + yDelta),
                targetXZ.y
            );
            yield return MoveTo(target);
        }
    }

    CoroutineMethod MoveTo(Vector3 dest, float speed = -1)
    {
        if (speed == -1)
        {
            speed = this.speed;
        }
        while (Vector3.Distance(transform.position, dest) > 0.001)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            transform.LookAt(dest);
            yield return null;
        }
    }

    SeagullPOI findPOI(SeagullPOI exclude = null)
    {
        List<SeagullPOI> pois = FindObjectsOfType<SeagullPOI>().ToList();

        if (exclude != null)
        {
            pois.Remove(exclude);
        }

        return pois.Select(
            poi => (desirability(poi), poi)
        ).Max().Item2;
    }

    float desirability(SeagullPOI poi)
    {
        return poi.interest 
        * (Random.value * GetComponentInParent<SeagullController>().interestRandomness)
        / (transform.position - poi.transform.position).magnitude;
    }

}
