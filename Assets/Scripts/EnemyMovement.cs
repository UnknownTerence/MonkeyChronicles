using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyController
{

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
    public float speed = 40.0f; 
    
    //COLLISION WITH SWORD 
    public float damage = 20.0f; 

    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.gameObject.tag == "Sword" && (swordArmMovement.attacking>0.0)) {
            hip.AddForce(-hip.transform.forward * 50);   
            hip.AddForce(hip.transform.up * 100);
            health -= 20;  
        }     
    }

    void FixedUpdate()
    {
        //WALKING & STRAFING 
        // forward and backwards movement
        if(movingLeft) {
            hip.AddForce(-hip.transform.right * speed); // adding a force to the hip 
            interval+=0.1;
            LegR.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 55*direction*-1)); //right leg 
            LegL.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 55*direction)); //left leg 
            hip.AddForce(hip.transform.up * 80);
        } else if (movingRight) {
            hip.AddForce(hip.transform.right * speed);   //adding a force to the hip 
            interval+=0.1; 
            LegR.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, -55*direction*-1)); //right leg 
            LegL.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, -55*direction)); //left leg 
            hip.AddForce(hip.transform.up * 80);
        } else { LegR.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)); LegL.targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)); } //if nothing pressed, snap legs bag into default position 
        if (interval>limit) {direction*=-1; interval=0.0;}

        // strafe movement
        if(movingBackward) {
            hip.AddForce(-hip.transform.forward * speed);  
            strafeInterval+=0.1;
            LegR.targetRotation = Quaternion.Euler(new Vector3(-35*sDirection*-1, 0f, 0f)); //right leg
            LegL.targetRotation = Quaternion.Euler(new Vector3(-35*sDirection, 0f, 0f)); //left leg 
            hip.AddForce(hip.transform.up * 30);
        }
        if(movingFoward) {
            hip.AddForce(hip.transform.forward * speed);
            strafeInterval+=0.1;
            LegR.targetRotation = Quaternion.Euler(new Vector3(35*sDirection*-1, 0f, 0f)); //right leg 
            LegL.targetRotation = Quaternion.Euler(new Vector3(35*sDirection, 0f, 0f)); //right leg 
            hip.AddForce(hip.transform.up * 80);
        }
        if (strafeInterval>limit) {sDirection*=-1; strafeInterval=0.0;}

        // looks towards the player
        Vector3 targetPosition = new Vector3(target.position.x, hip.transform.position.y, target.position.z);
        hip.transform.LookAt(targetPosition);
        

    }
}
