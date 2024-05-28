using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // This script is from Ragdoll Tutorial - Ragdoll Movement by Happy Chuck Programming
    // Daniel & Terence | 5/26/2024 4:51 PM
    public float speed = 0.0f; // fwd and bwd
    public float strafeSpeed = 0.0f; // left and right
    public Rigidbody hip; // reference to the rigidbody
    void Start()
    {
        hip = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
            hip.AddForce(-hip.transform.right * strafeSpeed);
        if(Input.GetKey(KeyCode.S))
            hip.AddForce(hip.transform.right * strafeSpeed);           
    }
}
