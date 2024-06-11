using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This script is from Ragdoll Tutorial - Ragdoll Movement by Happy Chuck Programming
    // Daniel & Terence | 5/26/2024 4:51 PM

    public Transform target; 
    public float speed = 0.0f; // fwd and bwd
    public Rigidbody hip; // reference to the rigidbody
    private float rotationOffset = 0.0f; 
    public float rotationSpeed = 1.0f; 
    
    private void FixedUpdate()
    {

        if(Input.GetKey(KeyCode.D))
            hip.AddForce(hip.transform.forward * speed);
        if(Input.GetKey(KeyCode.A))
            hip.AddForce(-hip.transform.forward * speed);
        if(Input.GetKey(KeyCode.W))
            hip.AddForce(-hip.transform.right * speed);
        if(Input.GetKey(KeyCode.S))
            hip.AddForce(hip.transform.right * speed);
        if(Input.anyKey)
            hip.AddForce(hip.transform.up * 100);
        // looks towards the enemy 
        //hip.transform.LookAt(mousePositionTranslation());



        float horizontal = Input.mousePosition.x; 
        if (horizontal<Screen.width*0.2) {
            rotationOffset-=rotationSpeed; 
        } else if (horizontal>Screen.width*0.8) {
            rotationOffset+=rotationSpeed; 
        } 
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + rotationOffset, transform.rotation.z);
    }

    //SECONDARY ROTATION METHOD (slightly janky)
    /*private Vector3 mousePositionTranslation() {
        float horizontal = Input.mousePosition.x; 
        if (horizontal<Screen.width*0.2) {
            
            return new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 20);
        } else if (horizontal>Screen.width*0.8) {
            
            return new Vector3(transform.position.x  + 1, transform.position.y, transform.position.z - 20);
        } else return new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    */
    
  
}
