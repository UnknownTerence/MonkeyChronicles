using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This script is from Ragdoll Tutorial - Ragdoll Movement by Happy Chuck Programming
    // Daniel & Terence | 5/26/2024 4:51 PM
    public float speed = 0.0f; // fwd and bwd
    public Rigidbody hip; // reference to the rigidbody
    void Start()
    {
        hip = GetComponent<Rigidbody>();
    }
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
        
    }
}
