using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButton : MonoBehaviour
{
    public BaseEvent Event;
    public Text myText;
    public bool successRate;
    public GameObject image;

    public void ButtonStuff()
    {
        if (successRate)
        {
            Event.SuccessEvent();
        }
        else if (!successRate)
        {
            Event.FailEvent();
        }
        
        image.SetActive(false);
    }

    public void SetText(string textString)
    {
        myText.text = textString;
    }
}
