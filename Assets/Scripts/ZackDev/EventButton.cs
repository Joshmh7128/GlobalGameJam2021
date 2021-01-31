using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButton : MonoBehaviour
{
    public BaseEvent Event;
    public Text myText;
    public int outcomeNumber;
    public GameObject image;

    public void ButtonStuff()
    {
        if (outcomeNumber == 0)
        {
            Event.Outcome0();
        }
        else if (outcomeNumber == 1)
        {
            Event.Outcome1();
        }
        else if (outcomeNumber == 2)
        {
            Event.Outcome2();
        }
        else if (outcomeNumber == 3)
        {
            Event.Outcome3();
        }
        else if (outcomeNumber == 4)
        {
            Event.Outcome4();
        }

        image.SetActive(false);
    }

    public void SetText(string textString)
    {
        myText.text = textString;
    }
}
