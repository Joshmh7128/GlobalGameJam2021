using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIShipTargetManager
{
    public static List<AIShipTarget> targets = new List<AIShipTarget>();

    private static List<int> openTargets;
    private static List<int> OpenTargets
    {
        get
        {
            if (openTargets == null || openTargets.Count == 0)
            {
                openTargets = new List<int>();
                for (int i = 0; i < targets.Count; i++)
                {
                    openTargets.Add(i);
                }
            }

            return openTargets;
        }
    }
    private static List<int> takenTargets = new List<int>();

    public static AIShipTarget GetTarget()
    {
        if (OpenTargets.Count == 0)
        {
            return null;
        }
        int assignedTarget = Random.Range(0, OpenTargets.Count);
        int assignedTargetIndex = OpenTargets[assignedTarget];
        OpenTargets.Remove(assignedTargetIndex);
        return targets[assignedTargetIndex];
    }

    public static void SetTargetOpen(AIShipTarget target)
    {
        if (targets.Contains(target) && !OpenTargets.Contains(targets.IndexOf(target)))
        {
            OpenTargets.Add(targets.IndexOf(target));
        }
    }
}
