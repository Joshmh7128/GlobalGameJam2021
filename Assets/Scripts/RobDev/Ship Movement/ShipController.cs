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

    [System.Serializable]
    public class ShipMastStats
    {
        [SerializeField]
        private float mastRotation;
        public float MastRotation { get { return mastRotation; } set { mastRotation = value; } }

        [SerializeField, Range(0.25f, 5)]
        private float mastRotationSpeed = 0.25f;
        public float MastRotationSpeed { get { return mastRotationSpeed; } }

        [SerializeField, Range(45, 90)]
        private float maxMastRotation = 60;
        public float MaxMastRotation { get { return maxMastRotation; } }

        [SerializeField]
        private GameObject mast;
        public GameObject Mast { get { return mast; } }
    }
    [SerializeField]
    private ShipMastStats mastStats;
    public ShipMastStats MastStats { get { return mastStats; } private set { mastStats = value; } }

    #endregion

    #region Movement
    private Rigidbody rb;
    [SerializeField]
    private GameObject windManager;
    public GameObject WindManager { get { return windManager; } }

    #endregion

    #region visuals
    [SerializeField]
    private GameObject shipFlag;

    [SerializeField]
    private GameObject rudder;
    #endregion


    void Start()
    {
        input = gameObject.GetComponent<InputComponent>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        shipFlag.transform.rotation = windManager.transform.rotation;

        ProcessInput();

        MoveShip();

        RotateMast();

        MoveRudder();
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
        }

        turnStats.TurnRate = Mathf.Clamp(newTurnRate, -turnStats.MaxTurnRate, turnStats.MaxTurnRate);

        float newRotation = MastStats.MastRotation;

        newRotation += ((input.SailsLeft ? -1 : 0) * MastStats.MastRotationSpeed) + ((input.SailsRight ? 1 : 0) * MastStats.MastRotationSpeed);
        MastStats.MastRotation = Mathf.Clamp(newRotation, -MastStats.MaxMastRotation, MastStats.MaxMastRotation);
    }

    void MoveShip()
    {
        rb.velocity = transform.forward * CalculateSpeedWithWind(CalculateWind());

        //rb.AddTorque(Vector3.up * turnStats.TurnRate);

        transform.rotation = Quaternion.Euler(0, turnStats.TurnRate + transform.rotation.eulerAngles.y, 0);
    }

    void MoveRudder()
    {
        rudder.transform.localEulerAngles = new Vector3(0, -turnStats.TurnRate * 10, 0);
    }

    void RotateMast()
    {
        MastStats.Mast.transform.localRotation = Quaternion.AngleAxis(MastStats.MastRotation, Vector3.up);
    }

    public float CalculateWind()
    {
        float temp = 0;

        temp = Vector3.Dot(MastStats.Mast.transform.forward, windManager.transform.forward);

        return temp;
    }

    float CalculateSpeedWithWind(float wind)
    {
        wind += 0.9f;

        wind *= 0.6f;

        return speedStats.Speed * wind;
    }
}
