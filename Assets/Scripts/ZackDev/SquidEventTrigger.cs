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

        public override void SuccessEvent()
        {
            manager.DoConsequence(SuccessText);
            crew.AddCrew(new CrewMember { name = "Squid", perk = "Tentacles"/*, picture = picture */});
        }

        public override void FailEvent()
        {
            manager.DoConsequence(FailureText);
        }
    }

    [Space(10)]

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
