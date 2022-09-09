using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour 
{
    Rigidbody carRB;
    public float centerMassY=-0.9f;
    private void Start()
    {
        carRB = GetComponent<Rigidbody>();
        carRB.centerOfMass = new Vector3(0, centerMassY, 0);
    }

    [System.Serializable]
    public class Axilinfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;

        public bool motor;
        public bool steering;
    }

    public List<Axilinfo> axilinfos = new List<Axilinfo>();
    public float maxMotorTorque;
    public float maxSteeringAngles;


    public void CarMovePerf(Vector2 input )
    {
        float motor = maxMotorTorque * input.y;
        float steering = maxSteeringAngles* input.x;
        foreach(Axilinfo axilinfo in axilinfos)
        {
            if (axilinfo.steering == true)
            {
                axilinfo.leftWheel.steerAngle = steering;
                axilinfo.rightWheel.steerAngle = steering;
            }
            if(axilinfo.motor == true)
            {
                axilinfo.leftWheel.motorTorque = motor;
                axilinfo.rightWheel.motorTorque = motor;
            }
        }
        //Debug.Log(input);
    }

    public void CarMoveCancel(Vector2 input)
    {
        float motor = maxMotorTorque * input.y;
        float steering = maxSteeringAngles * input.x;
        foreach (Axilinfo axilinfo in axilinfos)
        {
            if (axilinfo.steering == true)
            {
                axilinfo.leftWheel.steerAngle = -steering;
                axilinfo.rightWheel.steerAngle = -steering;
            }
            if (axilinfo.motor == true)
            {
                axilinfo.leftWheel.motorTorque = motor;
                axilinfo.rightWheel.motorTorque = motor;
            }
        }
    }





}
