using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidEventTrigger : MonoBehaviour
{
    [System.Serializable]
    public class SquidEvent : BaseEvent
    {
        public EventManager manager;
        public Crew crew;
        public Sprite picture;
        public ShipHealth health;

        public override void Outcome0()
        {
            manager.DoConsequence(Outcome0Text);
            health.Heal(2);
        }

        public override void Outcome1()
        {
            manager.DoConsequence(Outcome1Text);
            health.TakeDamage(1);
        }

        public override void Outcome2()
        {
            manager.DoConsequence(Outcome2Text);
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
