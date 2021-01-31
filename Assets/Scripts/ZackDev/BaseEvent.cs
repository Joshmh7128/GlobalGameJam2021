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
        public bool success = true;
        public string perkNeeded = null;
    }

    [Space(10, order = 0)]

    public Choice[] choices;

    public abstract void SuccessEvent();

    public abstract void FailEvent();

    [Space(10, order = 1)]

    public string SuccessText;
    public string FailureText;
}
