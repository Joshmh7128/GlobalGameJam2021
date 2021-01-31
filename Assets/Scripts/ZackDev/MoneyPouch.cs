using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPouch : MonoBehaviour
{
    public int doubloons = 15;
    public Text text;

    public void UpdateMoney(int change)
    {
        doubloons += change;
        if (doubloons < 0)
        {
            doubloons = 0;
        }

        text.text = "x " + doubloons.ToString();
    }
}
