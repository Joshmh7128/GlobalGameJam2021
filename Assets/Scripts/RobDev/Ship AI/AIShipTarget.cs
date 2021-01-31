using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipTarget : MonoBehaviour
{
    void Start()
    {
        AIShipTargetManager.targets.Add(this);
    }
}
