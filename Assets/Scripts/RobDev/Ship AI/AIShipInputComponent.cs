using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipInputComponent : InputComponent
{
    private AIShipTarget target;
    private AIShipTarget Target
    {
        get
        {
            if (target != null)
            {
                return target;
            }
            else
            {
                target = AIShipTargetManager.GetTarget();
                return target;
            }
        }
    }

    private enum State
    {
        Travel,
        Wait
    }
    private State shipState = State.Travel;

    void Update()
    {
        switch (shipState)
        {
            case State.Travel:
                SetSpeed(true);
                SetDirection();
                break;
            case State.Wait:
                SetSpeed(false);
                break;
        }
    }
    void SetSpeed(bool traveling)
    {
        Forward = traveling;
        Backward = !traveling;
    }

    void SetDirection()
    {
        Vector3 directionToTarget = (Target.transform.position - transform.position).normalized;

        directionToTarget.Normalize();

        float targetDegreeDirection = Mathf.Atan2(directionToTarget.z, directionToTarget.x) * 180 / Mathf.PI;

        float forwardDegreeDirection = Mathf.Atan2(transform.forward.z, transform.forward.x) * 180 / Mathf.PI;

        float difference = ((targetDegreeDirection - forwardDegreeDirection));

        if (Mathf.Abs(difference) < 2)
        {
            // Just go forwards
        }
        else if (difference > 0 && difference <= 180)
        {
            RudderLeft = true;
            RudderRight = false;
        }
        else
        {
            RudderRight = true;
            RudderLeft = false;
        }

        Debug.Log(difference);
    }


    void SetSails()
    {

    }
}
