using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    #region Input
    private InputComponent input;

    [System.Serializable]
    private class ShipSpeedStats
    {
        [SerializeField]
        private float speed;
        public float Speed { get { return speed; } set { speed = value; } }

        [SerializeField, Range(0.15f, 2)]
        private float acceleration = 0.25f;
        public float Acceleration { get { return acceleration; } set { acceleration = value; } }

        [SerializeField, Range(0, 2)]
        private float drag = 0.15f;
        public float Drag { get { return drag; } set { drag = value; } }

        [SerializeField, Range(0.5f, 50)]
        private float maxSpeed = 5;
        public float MaxSpeed { get { return maxSpeed; } set { maxSpeed = value; } }
    }

    [SerializeField]
    private ShipSpeedStats speedStats;

    [System.Serializable]
    private class ShipTurnStats
    {
        [SerializeField]
        private float turnRate;
        public float TurnRate { get { return turnRate; } set { turnRate = value; } }

        [SerializeField, Range(0.25f, 5)]
        private float acceleration = 0.5f;
        public float Acceleration { get { return acceleration; } set { acceleration = value; } }

        [SerializeField, Range(0.1f, 5)]
        private float drag = 0.25f;
        public float Drag { get { return drag; } set { drag = value; } }

        [SerializeField, Range(1, 10)]
        private float maxTurnRate = 5;
        public float MaxTurnRate { get { return maxTurnRate; } set { maxTurnRate = value; } }
    }

    [SerializeField]
    private ShipTurnStats turnStats;

    #endregion

    #region Movement
    private Rigidbody rb;
    #endregion


    void Start()
    {
        input = gameObject.GetComponent<InputComponent>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ProcessInput();

        MoveShip();
    }

    void ProcessInput()
    {
        float newSpeed = 0;
        if (input.Forward && speedStats.Speed < speedStats.MaxSpeed)
        {
            newSpeed = speedStats.Speed + speedStats.Acceleration;
        }
        else
        {
            newSpeed = speedStats.Speed - (input.Backward ? speedStats.Acceleration : speedStats.Drag);
        }

        speedStats.Speed = Mathf.Clamp(newSpeed, 0, speedStats.MaxSpeed);

        float newTurnRate = 0;
        if (input.RudderLeft ^ input.RudderRight)
        {
            newTurnRate = turnStats.TurnRate + (input.RudderLeft ? -turnStats.Acceleration : turnStats.Acceleration);
        }
        else if (turnStats.TurnRate != 0)
        {
            newTurnRate = turnStats.TurnRate + (turnStats.TurnRate > 0 ? -turnStats.Drag : turnStats.Drag);
            Debug.Log(newTurnRate);
        }

        turnStats.TurnRate = Mathf.Clamp(newTurnRate, -turnStats.MaxTurnRate, turnStats.MaxTurnRate);
    }

    void MoveShip()
    {
        rb.velocity = transform.forward * speedStats.Speed;

        transform.rotation = Quaternion.Euler(0, turnStats.TurnRate + transform.rotation.eulerAngles.y, 0);
    }
}
