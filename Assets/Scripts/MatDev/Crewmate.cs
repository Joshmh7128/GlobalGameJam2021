using System.Linq;
using UnityEngine;

public class Crewmate
{
    public readonly string name;
    public readonly Sprite sprite;
    public readonly Perk[] perks;

    public Crewmate(string name, Sprite sprite, Perk[] perks)
    {
        this.name = name;
        this.sprite = sprite;
        this.perks = perks;
    }

    public bool hasPerk(Perk query)
    {
        return perks.Contains(query);
    }

    public enum Perk
    {
        Brawny,
        Scholar,
        SilverTongued,
        EagleEyed,
        Acrobat,
        Drunkard,
        Doctor,
        Elder,
        Naturalist,
        Musician
    }

    [System.Serializable]
    private class NameOptions
    {
        public string[] firstName, lastName1, lastName2;
    }
    private static readonly NameOptions nameOptions = JsonUtility.FromJson<NameOptions>(Resources.Load<TextAsset>("CrewmateNames").text);

    public static string generateName()
    {
        return nameOptions.firstName[Random.Range(0, nameOptions.firstName.Length)]
             + nameOptions.lastName1[Random.Range(0, nameOptions.lastName1.Length)]
             + nameOptions.lastName2[Random.Range(0, nameOptions.lastName2.Length)];
    }

}
