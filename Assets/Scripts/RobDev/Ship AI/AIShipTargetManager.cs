using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIShipTargetManager
{
    public static List<AIShipTarget> targets = new List<AIShipTarget>();

    public static AIShipTarget GetTarget()
    {
        return targets[Random.Range(0, targets.Count - 1)];
    }
}
