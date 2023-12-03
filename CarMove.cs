using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [Header("Car settings")]
    public float driftFactor =0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor =3.5f;
    public float maxSpeed = 20;

    float accelerationInput = 0;
    float steerInput = 0;
    float rotationAngle = 0;
    float velocityVsUp =0;

    Rigidbody2D carRigidbody2D;

    public float GetVelocityMagnitude()
    {
        return carRigidbody2D.velocity.magnitude;
    }

    void Awake(){
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        ApplyEngineForce();
        KillOrthogonalVelicity();
        ApplySteering();
    }

    void ApplyEngineForce(){

        velocityVsUp = Vector2.Dot(transform.up,carRigidbody2D.velocity);

        if (velocityVsUp > maxSpeed && accelerationInput >0){
            return;
        }
        if (velocityVsUp < -maxSpeed * 0.5f && accelerationInput <0){
            return;
        }
        if(carRigidbody2D.velocity.sqrMagnitude>maxSpeed*maxSpeed&& accelerationInput>0){
            return;
        }

        if (accelerationInput == 0){
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag,3.0f, Time.fixedDeltaTime*3);
        }
        else carRigidbody2D.drag =0;

        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;
        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }
    void  ApplySteering(){
        float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.velocity.magnitude/8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);
        rotationAngle -= steerInput * turnFactor * minSpeedBeforeAllowTurningFactor;
        carRigidbody2D.MoveRotation(rotationAngle);
    } 
    void KillOrthogonalVelicity(){
       Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
       Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right); 
       carRigidbody2D.velocity = forwardVelocity+ rightVelocity* driftFactor;
    }

    float GetlateralVelocity(){
        return Vector2.Dot(transform.right, carRigidbody2D.velocity);
    }

    public bool IsTireScreeching(out float lateraVelocity, out bool isBraking){
       lateraVelocity = GetlateralVelocity();
       isBraking =false; 
       if(accelerationInput < 0 && velocityVsUp > 0){
            isBraking = true;
            return true;
       }
       if (Mathf.Abs(GetlateralVelocity())> 4.0f)
        return true;  

     return false;



       
    }

    public void SetInputVector(Vector2 inputVector){
        steerInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
 

}
