using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventScripto : MonoBehaviour
{
    [System.Serializable]
    public class TestEvent : BaseEvent
    {
        public EventManager manager;
        public ShipHealth health;
        // Put references to whatever systems you're interacting with here.

        public override void Outcome0()
        {
            manager.DoConsequence(Outcome0Text);
            // Here is where you put function calls for each outcome.
        }

        public override void Outcome1()
        {
            manager.DoConsequence(Outcome1Text);
        }

        public override void Outcome2()
        {
            manager.DoConsequence(Outcome2Text);
            health.Heal(1);
        }

        public override void Outcome3()
        {
            manager.DoConsequence(Outcome3Text);
        }

        public override void Outcome4()
        {
            manager.DoConsequence(Outcome4Text);
        }
    }

    // Instantiate whatever class you make.
    public TestEvent theEvent;
    private EventManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Sends the event to the event manager to begin.
            manager.DoEvent(theEvent);
        }
    }
}
