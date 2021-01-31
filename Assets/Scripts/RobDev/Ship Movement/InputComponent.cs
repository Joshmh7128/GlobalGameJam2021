using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputComponent : MonoBehaviour
{
    public bool Pause { get; protected set; }

    public bool Forward { get; protected set; }

    public bool Backward { get; protected set; }

    public bool RudderLeft { get; protected set; }

    public bool RudderRight { get; protected set; }

    public bool SailsLeft { get; protected set; }

    public bool SailsRight { get; protected set; }

    public bool Anchor { get; protected set; }
}
