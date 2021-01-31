using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    public List<CrewMember> crewMembers;

    private void Awake()
    {
        crewMembers = new List<CrewMember>();
    }

    public void AddCrew(CrewMember member)
    {
        crewMembers.Add(member);
    }

    public void RemoveCrew(string name)
    {
        foreach (CrewMember guy in crewMembers)
        {
            if (guy.name == name)
            {
                crewMembers.Remove(guy);
                break;
            }
        }
    }

    public bool CheckForPerk(string perk)
    {
        foreach (CrewMember guy in crewMembers)
        {
            if (guy.perk == perk)
            {
                return true;
            }
        }
        return false;
    }
}
