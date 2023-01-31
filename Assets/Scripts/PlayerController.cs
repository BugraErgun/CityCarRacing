using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Wheels Colliders")]
    public WheelCollider frontLeftCol;
    public WheelCollider frontRightCol;
    public WheelCollider backLeftCol;
    public WheelCollider backRightCol;
    

    [Header("Wheels Transform")] 
    public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform backLeftWheel;
    public Transform backRightWheel;

    [Header("Car Engine")]
    public float accelerationForce = 300f;
    public float breakingForce = 3000f;
    private float presentBreakForce = 0;
    private float presentAcceleration = 0;

    [Header("Car Steering")]
    public float wheelsTourque = 35f;
    private float presentTurnAngle = 0f;

   /* [Header("Car Sounds")]
    public AudioSource audioSource;
    public AudioClip accelerationSound;
    public AudioClip slowAccelerationSound;
    public AudioClip stopSound;*/

    private void Update()
    {
        MoveCar();
        CarSteering();
       
    }
    private void MoveCar()
    {  //Front Whell Driving System
        frontLeftCol.motorTorque = presentAcceleration;
        frontRightCol.motorTorque = presentAcceleration;
        backLeftCol.motorTorque = presentAcceleration;
        backRightCol.motorTorque = presentAcceleration;


        presentAcceleration = accelerationForce * SimpleInput.GetAxis("Vertical");
      /*  if (presentAcceleration>0)
        {
            audioSource.PlayOneShot(accelerationSound, .2f);

        }
        else if (presentAcceleration<0)
        {
            audioSource.PlayOneShot(slowAccelerationSound,.2f);
        }
        else if (presentAcceleration == 0)
        {
            audioSource.PlayOneShot(stopSound, .1f);
        }*/

    }
    private void CarSteering()
    {
        presentTurnAngle = wheelsTourque * SimpleInput.GetAxis("Horizontal");
        frontLeftCol.steerAngle= presentTurnAngle;
        frontRightCol.steerAngle= presentTurnAngle;

        SteeringWheels(frontLeftCol, frontLeftWheel);
        SteeringWheels(frontRightCol, frontRightWheel);
        SteeringWheels(backLeftCol, backLeftWheel);
        SteeringWheels(backRightCol, backRightWheel);

    }
    void SteeringWheels(WheelCollider wheelCol,Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCol.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;

    }

    public void ApplyBreaks()
    {
        StartCoroutine(CarBreaks());
        
    }
    IEnumerator CarBreaks()
    {
        presentBreakForce = breakingForce;

        frontLeftCol.brakeTorque = presentBreakForce;
        frontRightCol.brakeTorque = presentBreakForce;
        backLeftCol.brakeTorque = presentBreakForce;
        backRightCol.brakeTorque = presentBreakForce;

        yield return new WaitForSeconds(2f);

        presentBreakForce = 0f;

        frontLeftCol.brakeTorque = presentBreakForce;
        frontRightCol.brakeTorque = presentBreakForce;
        backLeftCol.brakeTorque = presentBreakForce;
        backRightCol.brakeTorque = presentBreakForce;

    }


}
