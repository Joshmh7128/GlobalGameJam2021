using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ShipCrew : MonoBehaviour
{
    public readonly List<Crewmate> crewmates = new List<Crewmate>();

    public bool hasPerk(Crewmate.Perk query)
    {
        return crewmates.Any(c => c.hasPerk(query));
    }

    public void addCrewmate(Crewmate recruit)
    {
        crewmates.Add(recruit);
    }
}
