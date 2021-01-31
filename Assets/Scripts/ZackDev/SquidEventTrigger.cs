using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidEventTrigger : MonoBehaviour
{
    [System.Serializable]
    public class SquidEvent : BaseEvent
    {
        public EventManager manager;
        public Rigidbody rb;

        public override void SuccessEvent()
        {
            manager.DoConsequence(SuccessText);
            rb.useGravity = true;
        }

        public override void FailEvent()
        {
            manager.DoConsequence(FailureText);
        }
    }

    public SquidEvent theEventInQuestion;
    private EventManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Triggering the event.");
            manager.DoEvent(theEventInQuestion);
        }
    }
}
