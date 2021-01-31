using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsequenceButton : MonoBehaviour
{
    public Text myText;
    public GameObject image;

    public void ButtonStuff()
    {
        Time.timeScale = 1;
        image.SetActive(false);
    }

    public void SetText(string textString)
    {
        myText.text = textString;
    }
}
