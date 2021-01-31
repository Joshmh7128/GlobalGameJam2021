﻿using System.Collections;
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

        public override void SuccessEvent()
        {
            manager.DoConsequence(SuccessText);
            // crew.AddCrew(new CrewMember { name = "Squid", perk = "Tentacles"/*, picture = picture */});
            health.Heal(2);
        }

        public override void FailEvent()
        {
            manager.DoConsequence(FailureText);
            health.TakeDamage(1);
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
