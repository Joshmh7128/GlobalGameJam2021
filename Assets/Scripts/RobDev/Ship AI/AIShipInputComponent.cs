using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipInputComponent : InputComponent
{
    private ShipController controller;

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

    void Start()
    {
        controller = gameObject.GetComponent<ShipController>();
    }

    void Update()
    {
        switch (shipState)
        {
            case State.Travel:
                SetSpeed(true);
                SetDirection();
                SetSails();

                if (Vector3.Distance(transform.position, target.transform.position) < 1)
                {
                    target = null;
                    StartCoroutine(nameof(SwitchTargets));
                }
                break;
            case State.Wait:
                SetSpeed(false);
                break;
        }
    }

    private IEnumerator SwitchTargets()
    {
        shipState = State.Wait;

        yield return new WaitForSeconds(5);

        shipState = State.Travel;
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
            RudderLeft = false;
            RudderRight = false;
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
    }


    void SetSails()
    {
        if (controller.CalculateWind() > 0.6f)
        {
            //Debug.Log(controller.CalculateWind());
            SailsRight = false;
            SailsLeft = false;
            return;
        }

        Vector3 windDirection = controller.WindManager.transform.forward;

        float windDegreeDirection = Mathf.Atan2(windDirection.z, windDirection.x) * 180 / Mathf.PI;

        float sailsDegreeDirection = Mathf.Atan2(transform.forward.z, transform.forward.x) * 180 / Mathf.PI;

        float difference = ((windDegreeDirection - sailsDegreeDirection));

        Debug.Log(difference);


        if (difference > 0 && difference <= 180)
        {
            SailsRight = false;
            SailsLeft = true;
        }

        else
        {
            SailsLeft = false;
            SailsRight = true;
        }
    }
}
