using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyController
{
    public Transform Enemy; 
    //HEAD ANIMATION 
    public Rigidbody head; 
    public float headPower = 0.0f;

    //LEG ANIMATION 
    public double limit = 4.5; 
    public ConfigurableJoint LegR; 
    public ConfigurableJoint LegL; 
    private double interval = 0.0; 
    private double strafeInterval = 0.0; 
    private int direction = 1; 
    private int sDirection = 1; 

    //HIP THRUST 
    public Rigidbody hip; 
    public float speed = 0.0f; 

    void FixedUpdate()
    {
        //WALKING & STRAFING 
        // forward and backwards movement
        if(movingFoward) {
            hip.AddForce(-hip.transform.right * speed); // adding a force to the hip 
            interval+=0.1;
            LegR.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 55*direction*-1)); //right leg 
            LegL.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 55*direction)); //left leg 
        } else if (movingBackward) {
            hip.AddForce(hip.transform.right * speed);   //adding a force to the hip 
            interval+=0.1; 
            LegR.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, -55*direction*-1)); //right leg 
            LegL.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, -55*direction)); //left leg 
        } else { LegR.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)); LegL.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)); } //if nothing pressed, snap legs bag into default position 
        Debug.Log(interval); 
        if (interval>limit) {direction*=-1; interval=0.0;}

        // strafe movement
        if(movingLeft) {
            hip.AddForce(-hip.transform.forward * speed);  
            strafeInterval+=0.1;
            LegR.targetRotation = Quaternion.Euler(new Vector3(-35*sDirection*-1, 0f, 0f)); //right leg
            LegL.targetRotation = Quaternion.Euler(new Vector3(-35*sDirection, 0f, 0f)); //left leg 
        }
        if(movingRight) {
            hip.AddForce(hip.transform.forward * speed);
            strafeInterval+=0.1;
            LegR.targetRotation = Quaternion.Euler(new Vector3(35*sDirection*-1, 0f, 0f)); //right leg 
            LegL.targetRotation = Quaternion.Euler(new Vector3(35*sDirection, 0f, 0f)); //right leg 
        }
        if (strafeInterval>limit) {sDirection*=-1; strafeInterval=0.0;}

        // looks towards the player
        transform.LookAt(Enemy);
    }
}
