using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEventTriggerer : MonoBehaviour
{
    public BaseEvent theEventInQuestion;
    public EventManager manager;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Triggering the event.");
            manager.DoEvent(theEventInQuestion);
        }
    }
}
