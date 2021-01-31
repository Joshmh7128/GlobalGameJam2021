using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Crew crew;
    public GameObject image;
    public Text myText;

    public GameObject buttonTemplate;

    private List<GameObject> buttons = new List<GameObject>();

    private GameObject eventButton;
    private EventButton eventButtonScript;

    public void DoEvent<T>(T theEventInQuestion) where T : BaseEvent
    {
        Time.timeScale = 0;

        myText.text = theEventInQuestion.eventText;

        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }

            buttons.Clear();
        }

        for (int i = 0; i < theEventInQuestion.choices.Length; i++)
        {
            if (theEventInQuestion.choices[i].perkNeeded == "" || crew.CheckForPerk(theEventInQuestion.choices[i].perkNeeded))
            {
                eventButton = Instantiate(buttonTemplate) as GameObject;
                eventButton.SetActive(true);

                buttons.Add(eventButton);

                eventButton.transform.SetParent(buttonTemplate.transform.parent, false);

                eventButtonScript = eventButton.GetComponent<EventButton>();

                eventButtonScript.SetText(theEventInQuestion.choices[i].choiceText);
                eventButtonScript.successRate = theEventInQuestion.choices[i].success;
                eventButtonScript.Event = theEventInQuestion;
            }
        }

        image.SetActive(true);
    }

    public GameObject consequence;
    public Text consequenceText;

    public void DoConsequence(string mainText)
    {
        consequenceText.text = mainText;
        
        consequence.SetActive(true);
    }
}
