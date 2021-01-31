using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingFishScript : MonoBehaviour
{
    /*
    1) Initiate Fishing Event
    2) Start with "Health" of 5 out of 10, "Line Tension" of 50, and a range of good line tension
    3) User has to repeatedly tap to raise the Line Tension to keep it in the good line range
    4) Range is smaller for harder to achieve stuff
    5) Line tension goes down with time fairly quickly
    6) Whenever the line tension is in a good zone, Health goes up by a variable * time
    7) When its in a bad zone (too loose or too tight), Helath goes down by a variable * time
    8) If Health gets to 10, the fishing is successful!
    9) If it gets to 0, the fishing is a failure
    10) One minute timer overall, just incase people just suck at fishing (?)
    */

    // Variables
    [SerializeField] float health; // if health < 0, you lose
    [SerializeField] float amountReeled; 

    [SerializeField] float lineTension; // tension of line

    [SerializeField] int canFishHereInPercent = 70; // can you fish here?
    [SerializeField] float radiusOfUsedPointSpot = 5; // radius of circle of spot that you cannot fish at

    List<Vector3> usedPoints;
    public string Message = "";

    int choice = 0; // what item you are fishing up

    bool wasAlreadyLoose = false;
    bool wasAlreadyTight = false;
    bool wasAlreadyNormal = false;

    InputComponent input;

    string[] returnedItem = new string[]{
        "Fish", // Least Rare : 30% chance
        "Treasure", // LR : " "
        "Sea Monster", // Rare : 20% chance
        "Crew Member", // Very Rate : 10% chance
        "Treasure Map"}; // VR : " "

    Vector2[] tensionRange = new Vector2[]{ // Range of tension that the line needs to be between to be considered "good"
        new Vector2(30f,70f), 
        new Vector2(35f,65f), 
        new Vector2(37.5f,62.5f), 
        new Vector2(40f,60f),
        new Vector2(40f,60f)};

    // Methods
    public void AttemptToFish ()
    {
        foreach (Vector3 point in usedPoints)
        {
            if (Vector3.Distance(transform.position,point) <= radiusOfUsedPointSpot)
            {
                // ** Be like "No cannot fish here"
            }
        }
        int canFishHereChance = Random.Range(0,100);
        if (canFishHereChance < canFishHereInPercent)
        {
            StartCoroutine(CatchFish());
        }
        else
        {
            usedPoints.Add(transform.position);
        }
    }

    IEnumerator CatchFish()
    {
        health = 8f;
        amountReeled = 0f;
        lineTension = 50f;
        float randomizeChoice = Random.Range(0f,100f);

        if (randomizeChoice < 30f) choice = 0;
        else if (randomizeChoice < 60f) choice = 1;
        else if (randomizeChoice < 80f) choice = 2;
        else if (randomizeChoice < 90f) choice = 3;
        else choice = 5;

        float randomizeRange = Random.Range(-30f,30f);
        float minGoodTension = tensionRange[choice].x + randomizeRange;
        float maxGoodTension = tensionRange[choice].y + randomizeRange;

        while (health > 0f && amountReeled < 8f)
        {
            // if (input.Interact)
            if (Input.GetKey("space"))
            {
                lineTension += 30*Time.deltaTime;
            }
            else
            {
                lineTension -= 30*Time.deltaTime;
            }

            if (lineTension < minGoodTension)
            {
                if (!wasAlreadyLoose)
                {
                    // *** Show that its too loose
                    //Message = "Too Loose!!!";
                    wasAlreadyTight = false;
                    wasAlreadyNormal = false;
                    wasAlreadyLoose = true;
                }
                health -= 0.5f*Time.deltaTime;
            }
            else if (lineTension > maxGoodTension)
            {
                if (!wasAlreadyTight)
                {
                    // *** Show that its too tight
                    //Message = "Too Tight!!!";
                    wasAlreadyTight = true;
                    wasAlreadyNormal = false;
                    wasAlreadyLoose = false;
                }
                health -= 0.5f*Time.deltaTime;
            }
            else
            {
                if (!wasAlreadyNormal)
                {
                    // ** Show that its normal
                    //Message = "OK";
                    wasAlreadyTight = false;
                    wasAlreadyNormal = true;
                    wasAlreadyLoose = false;
                }
                amountReeled += 0.5f*Time.deltaTime;
            }
            yield return null;
        }
        //Debug.Log("DONE");
        if (amountReeled > 5f)
        {
            CaughtItem();
        }
        else
        {
            LostItem();
        }
    }

    IEnumerator CaughtItem()
    {
        // do a lil animation
        //Debug.Log("Ya did it!!!");
        if (choice == 5)
        {
            // ** Create a Treasure Pillar in a random area
        }
        yield return null;
    }

    IEnumerator LostItem()
    {
        //Debug.Log("Failed");
        yield return null;
    }

    IEnumerator CleanPoints()
    {
        if (usedPoints.Count == 0)
        {
            usedPoints.RemoveAt(0);
        }
        yield return new WaitForSeconds(600); // how long before each spot is cleared
    }

    void OnMouseDown()
    {
        StartCoroutine(CatchFish());
    }

    void Start()
    {
        usedPoints = new List<Vector3>();
        input = this.gameObject.GetComponent<InputComponent>();
        StartCoroutine(CleanPoints());
    }

    void Update()
    {
        /*if (input.Fish)
        {

        }*/
    }

}
