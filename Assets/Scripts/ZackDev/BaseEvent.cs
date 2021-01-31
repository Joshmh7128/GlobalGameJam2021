using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseEvent
{
    public string eventText;

    [System.Serializable]
    public class Choice
    {
        public string choiceText = "";
        public string perkNeeded = null;
    }

    [Space(10, order = 0)]

    public Choice[] choices;

    public abstract void Outcome0();

    public abstract void Outcome1();

    public abstract void Outcome2();

    public abstract void Outcome3();

    public abstract void Outcome4();

    [Space(10, order = 1)]

    public string Outcome0Text;
    public string Outcome1Text;
    public string Outcome2Text;
    public string Outcome3Text;
    public string Outcome4Text;
}
