using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    [System.Serializable]
    public class WhirlpoolEvent : BaseEvent
    {
        public EventManager manager;
        public ShipHealth health;
        public MoneyPouch money;
        // Put references to whatever systems you're interacting with here.

        public override void Outcome0()
        {
            manager.DoConsequence(Outcome0Text);
            // Here is where you put function calls for each outcome.
        }

        public override void Outcome1()
        {
            manager.DoConsequence(Outcome1Text);
            health.TakeDamage(1);
        }

        public override void Outcome2()
        {
            manager.DoConsequence(Outcome2Text);
            money.doubloons = money.doubloons - 1;
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
    public WhirlpoolEvent theEvent;
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
