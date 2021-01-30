using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerInputComponent : InputComponent
{
    /// <summary>
    /// The Rewired Player this input component uses to get input from the player
    /// </summary>
    private Player inputPlayer;

    void Start()
    {
        inputPlayer = ReInput.players.GetSystemPlayer();

        Debug.Log(inputPlayer.descriptiveName);
    }

    private void Update()
    {
        GetPlayerInput();
    }

    private void GetPlayerInput()
    {
        if (inputPlayer != null)
        {
            Pause = inputPlayer.GetButtonDown("Pause");

            Forward = inputPlayer.GetButton("Forwards");

            Backward = inputPlayer.GetButton("Backwards");

            RudderLeft = inputPlayer.GetButton("RudderLeft");

            RudderRight = inputPlayer.GetButton("RudderRight");

            SailsLeft = inputPlayer.GetButton("SailsLeft");

            SailsRight = inputPlayer.GetButton("SailsRight");
        }
    }
}
